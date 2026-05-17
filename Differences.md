# Branch Differences

This file documents the differences identified between the `dotnetport` branch and the `stable` branch.

| File Path | Method/Area | Description of Difference | Status |
|-----------|-------------|---------------------------|--------|
| EPPlus/CellStore.cs | GetPosition(int Row), GetPosition(int Column) | Added performance optimization: direct indexing check before binary search. | Verified on .NET 9 |
| EPPlus/ExcelWorksheet.cs | GetValue<T> | Refactored to delegate type conversion to `ConvertUtil.GetTypedCellValue<T>`. Behavioral difference: `bool` (True) converts to `1` in .NET 9, documented as a change from `stable`. | Verified on .NET 9 |
| Multiple Files | Floating-point Precision | Identified precision differences between Mono and .NET 9 in `double.ToString()` and `TimeSpan` to `double` conversions. | Resolved in tests |
| EPPlus/ExcelPackage.cs | Constructors / Init | Added .NET Core support; refactored stream handling to avoid temp folders; added `appsettings.json` support. | Pending |
| EPPlus/ExcelPackage.cs | Save / SavePart | Switched to `XmlTextWriter` with `Formatting.None`; improved `CopyStream` performance. | Pending |
| EPPlus/ExcelWorksheet.cs | Internal Cleanup | Added `FixSharedFormulas`; improved URI generation for comments/VML. | Pending |
| EPPlus/ExcelWorksheet.cs | Table Support | Added R1C1 translation for calculated column formulas. | Pending |
| EPPlus/ExcelRangeBase.cs | Value Formatting | Replaced `Type.IsPrimitive` with `TypeCompat.IsPrimitive`; added `GetDateText`. | Pending |
| EPPlus/Drawing/ExcelDrawings.cs | AddChart | Added overloads supporting `ExcelPivotTable` as source. | Pending |
| EPPlus/Drawing/ExcelDrawings.cs | Internal State | Switched to `OrdinalIgnoreCase` for drawing names; improved XML part creation. | Pending |
| EPPlus/FormulaParsing/EpplusExcelDataProvider.cs | Address Handling | Added `ConvertToA1C1` and `GetRange` overrides for Table-style addresses. | Pending |
| Multiple Files | String Comparisons | Switched from `InvariantCultureIgnoreCase` to `OrdinalIgnoreCase` in many locations. | Pending |
