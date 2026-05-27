# SheetKraft Export EPPlus Test Plan

Source analysis date: 2026-05-27

Scope:

- SheetKraft entry points:
  - `SheetKraft.net/Shared/DataFunctions.cs::ExportSheets`
  - `SheetKraft.net/Shared/DataFunctions.cs::ExportRangeToExcelXlsx`
  - delegated implementation in `SheetKraft.net/Shared/ExportSheetsImpl.cs`
- EPPlus baseline used by that SheetKraft code: tag `v1.0.22`
- EPPlus port under test: branch `dotnetport`

This document is a plan only. Do not treat it as generated test code.

## Test Strategy

The SheetKraft code exercises EPPlus through high-level workbook export workflows, not just isolated API calls. The port should therefore have:

1. Focused API regression tests for each EPPlus feature touched by SheetKraft.
2. Scenario tests that combine those APIs the same way SheetKraft combines them.
3. Save/reopen assertions for every scenario, because many failures only appear in package XML, relationship parts, encryption streams, shared strings, style ids, or worksheet metadata after serialization.
4. Compatibility assertions against the `v1.0.22` behavior where possible by constructing equivalent workbooks and comparing observable workbook state, not by running the .NET Framework SheetKraft layer in this Linux environment.

Recommended location:

- Add a dedicated test file such as `EPPlusTest/SheetKraftExportUsageTests.cs`.
- Put helpers in the test file unless they become reusable by other tests.
- Use `EPPlusTest/EPPlusTest.Core.csproj` on `dotnetport`.

## Current Coverage Snapshot

Existing EPPlus tests cover many individual primitives:

- Package creation, save, encryption, and password handling: `ExcelPackageTest.cs`, `ExcelPackageTests.cs`, `Encrypt.cs`, `EncryptedPackageHandlerTest.cs`.
- Worksheet insertion, deletion, copying, moving, and addressing: `WorksheetsTests.cs`, `ExcelWorksheetsDivergenceTest.cs`, `Address.cs`, `Issues.cs`.
- Range values, formulas, copy, array formulas, and R1C1 formulas: `ExcelRangeBaseTest.cs`, `Calculation.cs`, `FormulaParsing/*`, `Issues.cs`.
- Styles, colors, borders, named ranges, tables, drawings, charts, conditional formatting, protection, rows, columns: existing topic-specific tests.

The main gap is coverage for SheetKraft-shaped combinations: copy a workbook or worksheet, mutate names/ranges/formulas/styles/merged cells/tables/charts/protection/encryption, insert or delete rows/columns, save, reopen, and assert that all affected package parts remain consistent.

## EPPlus Usage Map

### ExportRangeToExcelXlsx

Core APIs and behavior:

- `new ExcelPackage(FileInfo, tempPath)` and `Save()`.
- `Workbook.Worksheets` enumeration, lookup by name, and `Add(name)`.
- `ExcelAddress` parsing for append references, including full-column and full-row references.
- `Cells.Clear()`, indexed `Cells[row,col]`, range indexing, range enumeration, `LastOrDefault` over populated cells.
- `InsertRow`, `InsertColumn`, and manual adjustment of worksheet drawings based on `drawing.EditAs`, `drawing.From`, and `drawing.To`.
- `Row(index).Height`, `Row(index).CustomHeight`, `Row(index).OutlineLevel`.
- `Column(index).Width`, `Column(index).OutlineLevel`.
- Cell `Value`, formula assignment through `Formula`, formula-like strings, Excel error values, nulls, long strings.
- Style and border transfer through `ExcelStyle`, number formats, fill, font, alignment, wrap, rotation, border style, and border color.
- Theme color to RGB conversion through `Workbook.GetThemeColors()` and `ExcelColor.Theme`/`Tint`.
- `MergedCells`, `ExcelAddress`, and range `Merge = true`.
- Sheet protection through `Protection.IsProtected`, `AllowEditObject`, `AllowEditScenarios`, and `SetPassword`.

### ExportSheets and ExportSheetsImpl

Core APIs and behavior:

- Open destination package with no password, read password, or fallback write password.
- Copy source file to destination for new-book export, then reopen.
- Add copied worksheets with `Worksheets.Add(destName, srcSheet)`.
- Delete existing worksheets and preserve sheet order via `Delete`, `MoveAfter`, and `MoveToStart`.
- Rename retained worksheets.
- Handle hidden worksheets.
- Detect chart sheets and avoid worksheet-only operations on them.
- Pivot table cache XML mutation: set `refreshOnLoad="1"`.
- Named ranges:
  - workbook-level and worksheet-level collections.
  - add formulas with `AddFormula`.
  - update `Formula` or `Address`.
  - remove names, including built-in and SheetKraft names.
  - remove chart series whose named source becomes `#NULL!`.
- Range processing:
  - clear ranges.
  - set formulas plus cached values.
  - create array formulas with `CreateArrayFormula`.
  - remove continued array formulas using `GetArrayFormulaRange` and `Clear(true)`.
  - fill formulas down/right through `FormulaR1C1`.
  - set scalar and array values with error conversion and blank conversion.
- Copy number formats from row/column patterns.
- Apply tables with `Worksheet.Tables.Add`, table style names, header/filter/stripe/total flags, and duplicate table-name handling.
- Remove SheetKraft conditional formatting by editing `WorksheetXml` for both `xm:f` and `d:formula` namespace forms.
- Copy column widths and hidden flags up to source `Dimension.End.Column`.
- Fix chart series source formulas by setting `HeaderAddress`, `XSeries`, and `Series`.
- Footer handling through range `Copy`, `DeleteRow`, and `DeleteColumn`.
- Workbook calculation and encryption:
  - `Workbook.CalcMode = Automatic`
  - `Workbook.FullCalcOnLoad = false`
  - `Encryption.Password = writePassword or null`
  - selected sheet via `Select()`

## Exhaustive Test Plan

### A. Package Open, Save, Encryption

1. Create a new `.xlsx` package through `ExcelPackage(FileInfo, tempPath)`, save, reopen, and assert workbook integrity.
2. Reopen an existing unencrypted workbook with no password, save, reopen again.
3. Save with `Encryption.Password`, assert reopening without password fails and reopening with the password succeeds.
4. Simulate SheetKraft fallback semantics: existing encrypted workbook opens with write password when read password is empty.
5. Clear encryption by setting `Encryption.Password = null`, save, and assert the package opens without a password.
6. Save workbook with `CalcMode = Automatic` and `FullCalcOnLoad = false`; reopen and assert workbook XML state.

### B. Worksheet Lifecycle and Ordering

1. Copy source workbook to destination, delete non-exported sheets, rename exported sheets, save, reopen, and assert only expected sheets remain.
2. Add copied worksheets into an existing destination workbook using `Worksheets.Add(name, srcSheet)`.
3. Replace an existing destination sheet with the same name and assert the replacement occupies the original position.
4. Replacement at first position uses `MoveToStart`; replacement after another sheet uses `MoveAfter`.
5. Preserve hidden sheet state for hidden and very-hidden worksheets.
6. Select the initial sheet by name, save, reopen, and assert selected/active sheet metadata.
7. Include a chart sheet in the source/destination mix and assert worksheet-only logic does not corrupt it.

### C. Cell Values and Error Values

1. Write and reopen strings, doubles, integers, booleans, dates, nulls, and empty strings.
2. Write all SheetKraft mapped Excel errors: `#DIV/0!`, `#VALUE!`, `#REF!`, `#NAME?`, `#NUM!`, `#N/A`, `#GETTING_DATA`, plus `#NULL!` as blank.
3. Verify `#N/A` can be written as either error or blank depending on caller option.
4. Verify empty string can be written as either empty string or blank depending on caller option.
5. Write a string longer than 32767 characters and assert it is truncated to 32767 characters after save/reopen.
6. Write a 2D object array through range `Value` and assert cell-by-cell values after reopen.
7. Overwrite existing values with null/error/blank values and assert previous values are removed only when expected.

### D. Formulas and Array Formulas

1. Set `Formula` on a scalar range and assert formula and cached value after reopen.
2. Set formula on a merged range and assert only the top-left cell holds the formula.
3. Use `CreateArrayFormula` on a rectangular range and assert array formula metadata after reopen.
4. Clear an existing array formula with `Clear(true)` and assert formula and values are gone across the full range.
5. Clear continued SheetKraft array formula ranges whose formulas start with `_xll.ContinueArray.SK(`.
6. Fill formulas down using source cell `FormulaR1C1`; assert translated formulas and cached values.
7. Fill formulas right using source cell `FormulaR1C1`; assert translated formulas and cached values.
8. In `ExportRangeToExcelXlsx` semantics, write a string beginning with `=` as a formula only when formula copying is enabled; otherwise preserve it as a value.

### E. Append, Overwrite, Insert, and Dimensions

1. Append down from a normal address and find last populated row inside the reference columns.
2. Append right from a normal address and find last populated column inside the reference rows.
3. Full-column append reference chooses append-down unless insert semantics invert it.
4. Full-row append reference chooses append-right unless insert semantics invert it.
5. Overwrite starts at the append reference start cell.
6. Insert rows with pre-gap, post-gap, and transverse pre-gap; assert values, formulas, merged cells, rows, and drawings shift correctly.
7. Insert columns with pre-gap, post-gap, and transverse pre-gap; assert values, formulas, merged cells, columns, and drawings shift correctly.
8. Clear existing sheet cells when exporting to a new sheet name without append reference and without groups.
9. Create missing destination sheet with a truncated sheet name longer than 31 characters.
10. Preserve row heights and column widths copied from source format areas.

### F. Drawing Anchor Adjustment

1. Insert rows before a one-cell anchored drawing and assert `From.Row` and `To.Row` shift when `EditAs` is not `Absolute`.
2. Insert columns before a one-cell anchored drawing and assert `From.Column` and `To.Column` shift when `EditAs` is not `Absolute`.
3. Insert rows/columns through the middle of a two-cell drawing and assert only `To` shifts when `EditAs == TwoCell`.
4. Assert absolute drawings do not shift.
5. Save/reopen each drawing-anchor case and assert drawing XML and object model agree.

### G. Styles, Number Formats, Borders, and Theme Colors

1. Copy number format only from row-above, first-row, second-row, column, and row-column patterns.
2. Copy cell content formats without number formats: fill, font, alignment, indent, text rotation, vertical alignment, and wrap.
3. Copy number formats without content formats.
4. Copy both content and number formats.
5. Skip copying styles for cells filtered out by a boolean condition matrix.
6. Apply dynamic formats where target areas intersect source data, including modulo repetition of source style areas.
7. Copy direct RGB fill/font/border colors.
8. Copy theme/tint colors using workbook theme colors and assert resulting RGB after save/reopen.
9. Copy borders from a single source cell to a larger range.
10. Copy borders from one-column, two-row source patterns to a larger range.
11. Copy equal-area borders cell by cell with condition matrix.
12. Copy outer and inner borders for rectangular ranges larger than one row and one column.
13. Assert no unintended style changes occur when source style is `General` or fill pattern is `None`.

### H. Merged Cells

1. Copy merged cells from a non-columnar source format area to destination, including partially intersecting merges clipped to the export area.
2. Copy header merged cells from an options sheet while omitting non-exported columns.
3. Copy footer merged cells from an options sheet while omitting non-exported columns.
4. Template-cell export with `isMerged = true` merges the destination print area and writes the top-left value.
5. Merge-format function merges variable row groups.
6. Merge-format function merges variable column groups.
7. Save/reopen every merge scenario and assert `MergedCells` addresses.

### I. Rows, Columns, Groups, and Footers

1. Set row outline levels from SheetKraft group metadata and assert level is one less than input level.
2. Set column outline levels from SheetKraft group metadata and assert level is one less than input level.
3. Copy row heights from source rows for data, headers, footers, and template cells.
4. Copy column widths from source columns for data, headers, footers, and template cells.
5. Preserve source column `Hidden` flags during `ExportSheets`.
6. Footer rows: copy first rows to the bottom and delete them from the top; assert formulas, styles, merged cells, and row heights.
7. Footer columns: copy first columns to the right and delete them from the left; assert formulas, styles, merged cells, and column widths.
8. Combined row and column footer handling in one worksheet.

### J. Named Ranges

1. Add workbook-level named formula when name is missing.
2. Add worksheet-level named formula when name is missing.
3. Update an existing formula name through `Formula`.
4. Update an existing address name through `Address`.
5. Remove names marked as removed.
6. Remove built-in and SheetKraft transient names listed in `NamedVarsToRemove`.
7. Remove `SheetKraftFormula`, `SheetKraftPicker`, `SheetKraftInput`, `SheetKraftOutput`, and `SheetKraftFormat` names for their special formulas.
8. Convert a `Slicer_` name with `""` formula to `#N/A`.
9. Save/reopen and assert workbook and worksheet name collections, formulas, scopes, and addresses.

### K. Tables

1. Add a table with every SheetKraft-controlled display flag: header, filter, first column, last column, row stripes, column stripes, total row.
2. Apply a table style name and assert it survives save/reopen.
3. Add two tables whose generated names would collide and assert suffixing produces unique names.
4. Attempt overlapping table creation and assert an `ArgumentException` is translated by the caller in integration-level tests, or at least raised at the EPPlus level.

### L. Conditional Formatting XML Cleanup

1. Create conditional formatting using `xm:f` with formula beginning `IF(SheetKraftFormat,`; invoke equivalent XML cleanup and assert only matching conditional formatting nodes are removed.
2. Create conditional formatting using standard `d:formula` with the same formula and assert cleanup works.
3. Include non-SheetKraft conditional formatting rules and assert they remain.
4. Remove all matching conditional formatting nodes and assert the empty parent collection node is removed.
5. Save/reopen and assert worksheet XML remains valid.

### M. Charts, Chart Sheets, and Pivot Tables

1. Copy a worksheet containing chart series, then update `HeaderAddress`, `XSeries`, and `Series`; save/reopen and assert formulas point to the expected renamed sheets/ranges.
2. Remove chart series whose named source was converted to `#NULL!`.
3. Preserve chart sheets in exported workbooks without applying worksheet-only mutations.
4. Copy worksheet with charts into an existing workbook and assert drawing relationships are valid after save/reopen.
5. For worksheets containing pivot tables, set cache definition `refreshOnLoad="1"` and assert the pivot cache XML after save/reopen.

### N. Protection

1. Protect a sheet with no explicit password and assert `IsProtected`, `AllowEditObject=false`, and `AllowEditScenarios=false`.
2. Protect a sheet with password and assert the sheet protection hash is present and can be reopened.
3. Do not protect when SheetKraft map says `Protect=false`.
4. Protect output range sheet in `ExportRangeToExcelXlsx` with password and assert same flags.
5. Combine sheet protection with workbook encryption to catch save/reopen interactions.

### O. Range Copy, Delete Row, Delete Column

1. Range `Copy` used by footer rows preserves values, formulas, styles, merged cells, and dimensions.
2. Range `Copy` used by footer columns preserves values, formulas, styles, merged cells, and dimensions.
3. `DeleteRow` after row footer copy updates formulas, merged cells, tables, drawings, and named ranges.
4. `DeleteColumn` after column footer copy updates formulas, merged cells, tables, drawings, and named ranges.
5. Combined delete row and delete column in a workbook with charts and tables.

### P. Template Export Shapes

1. Template print area applies cell styles from a format area and borders from a template area.
2. Multiple template print elements are processed in reverse order and land at expected destination addresses.
3. Template print with insert mode inserts the print area size plus gaps before styling.
4. Template cells copy styles, borders, row heights, column widths, and values.
5. Overlapping template-cell row-height metadata chooses the final expected height for merged and non-merged cells.
6. Overlapping template-cell column-width metadata chooses the final expected width for merged and non-merged cells.
7. Template cells with multi-cell data write a 2D object array; merged template cells write a scalar.

### Q. ExportRange Columnar Options

1. Columnar export with headers and footers writes option sheet values above and below data.
2. Header/footer styles and borders come from the options sheet.
3. Per-column `ExportCol=false` omits columns and adjusts merge projection.
4. Per-column `treatNAasBlank=false` preserves `#N/A`.
5. Per-column explicit number formats from options override source number formats.
6. `colIndices` maps output columns to non-sequential source format columns.
7. `rowIndices` maps output rows to non-sequential source format rows.
8. Negative `colIndices` skips source format copying but still exports values where applicable.

### R. Overwrite Options

1. Default path copies values, number formats, content formats, and borders.
2. `overwrite` with no suboptions copies values, all formats, borders, and converts `#N/A` to blanks.
3. `Values` only leaves existing formulas and formats intact except overwritten values.
4. `Formulas` writes formula strings and does not write non-formula values unless `Values` is also set.
5. `Formats`, `NumberFormats`, `ContentFormats`, and `Borders` independently affect only their intended style parts.
6. `SkipBlanks` leaves existing cell values and styles where incoming value is null.
7. `SkipNAs` leaves existing cell values and styles where incoming value is `#N/A`.
8. `NAsToBlanks` writes blanks for `#N/A`.
9. Insert mode uses pre-gap, transverse pre-gap, and post-gap correctly for both row and column insertion.

## Priority Order

1. Package open/save/encryption, worksheet lifecycle, values/errors, formulas/array formulas.
2. Insert/delete/copy behavior, merges, row/column dimensions, protection.
3. Styles/borders/theme colors, named ranges, tables.
4. Drawings/charts/pivot tables/conditional-format cleanup.
5. Full SheetKraft-shaped scenario tests that combine the above.

## Suggested Scenario Test Bundles

After focused tests exist, add a smaller set of broad scenarios:

1. New-book export from a template workbook containing normal sheets, hidden sheets, names, formulas, array formulas, styles, tables, charts, conditional formatting, footers, and protection.
2. Existing-destination export replacing sheets while preserving destination sheet order and password behavior.
3. Range export append-down into existing sheet with columnar headers/footers, omitted columns, styles, borders, merges, and protection.
4. Range export insert-right into a sheet containing drawings and formulas, validating drawing anchors and formula/range updates.
5. Template export with print and cell templates, merged output, row heights, column widths, and mixed value types.

## Notes for Future Implementation

- Prefer creating workbooks in memory or under test temp directories; avoid hardcoded Windows paths.
- Always save and reopen before final assertions unless the test is intentionally object-model-only.
- Where XML cleanup or pivot-cache refresh is asserted, inspect package XML directly as well as the EPPlus object model.
- For drawing/image tests on Linux, use the existing resource strategy and be mindful of `FAILING_TESTS.md` notes about image handling. Anchor tests can use shapes or charts when possible to avoid bitmap decoder dependencies.
- The `/tmp/epplus-v1.0.22` worktree is available for comparing old implementation details during this analysis session, but the durable plan belongs on `dotnetport`.
