# Porting Progress

## Current Status
- [x] Initialize project documentation (`GEMINI.md`)
- [ ] Perform branch diff and populate `Differences.md`
- [ ] Create test cases for differences
- [ ] Verify parity and resolve platform differences

## Task Log
- **2026-05-17:** Initialized `GEMINI.md` and `PortingProgress.md`. Starting branch comparison.
- **2026-05-17:** Picked up `EPPlus/ExcelNamedRange.cs` -> `LocalSheetId` from `Differences.md`. Added tests in `EPPlus-stable` (`ExcelRangeBaseTest.cs`), verified they pass under Mono, committed and cherry-picked to `dotnetport`, successfully passing under .NET 9.
- **2026-05-17:** Picked up `EPPlus/ExcelNamedRangeCollection.cs` -> `Name Validation & Bounds` from `Differences.md`. Wrote tests in `EPPlus-stable` (`ExcelNamedRangeCollectionTest.cs`), verified they pass under Mono, committed and cherry-picked to `dotnetport`, successfully passing under .NET 9.
- **2026-05-17:** Picked up `EPPlus/ExcelHeaderFooter.cs` -> `Header/Footer Features` from `Differences.md`. Ported test suite `ExcelHeaderFooterTest.cs` from `stable` to `dotnetport`. Identified and resolved a platform-specific infinite loop on Linux where Windows-style backslashes in `Resources.Designer.cs` caused type initialization to hang in multithreaded vstest; fixed path resolution using `Path.Combine`/`Directory.GetParent` and resolved P/Invoke dynamic loading by symlinking `libdl.so`. All 7 tests in `ExcelHeaderFooterTest` now pass flawlessly on .NET 9.
- **2026-05-18:** Picked up `EPPlus/ExcelCellBase.cs` -> `Formula & Address Parsing` from `Differences.md`. Wrote comprehensive tests covering `TranslateFromR1C1`, `TranslateToR1C1`, and `IsValidAddress` in `EPPlus-stable` (`ExcelCellBaseTest.cs`), verified they pass under Mono, committed and cherry-picked to `dotnetport`, successfully passing under .NET 9. Used conditional compilation (`#if Core`) to support the improved address and formula validation in the dotnetport branch.

