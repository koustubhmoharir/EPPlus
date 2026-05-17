# EPPlus Mono Test Results

This document lists the test cases that fail or hang when running EPPlus under Mono on Linux.

## Summary

- **Total Tests:** ~500+
- **Passing:** Majority of core functionality (Cell store, Calculation, Formula parsing, Data validation).
- **Failing/Hanging:** Tests involving specific `System.Drawing` operations or resources.

## Failing Tests

| Test Case | Status | Reason |
| :--- | :--- | :--- |
| `EPPlusTest.Excel.OperatorsTests.OperatorsActingOnDateStrings` | **Ignored** | Returns `#VALUE!`. Likely a culture-specific date parsing issue on Mono. |
| `EPPlusTest.DTS_FailingTests.DeleteWorksheetWithReferencedImage` | **Ignored** | Hangs during `AddPicture` call. Likely an issue with `libgdiplus` or resource loading in Mono. |
| `EPPlusTest.DTS_FailingTests.CopyAndDeleteWorksheetWithImage` | **Ignored** | Same as above. |

## Observations

1.  **GUI/GDI+ Dependency:** Some tests require a display protocol. Running with `xvfb-run` resolves the "Authorization required" error but some drawing tests still hang.
2.  **Resource Loading:** The `DTS_FailingTests` seem to hang when accessing `Properties.Resources.Test1`. This might be due to how Mono handles embedded resources combined with `System.Drawing.Bitmap`.
3.  **Performance:** `WriteReadCompundDoc` is notably slower on Mono/Linux (~1-2 minutes) compared to Windows.

## Recommendations for Linux/Mono Support

- **Drawing Isolation:** Consider mocking `System.Drawing` calls if possible, or ensuring `libgdiplus` is fully compatible with the specific image formats used (WMF, JPG).
- **Path Abstraction:** Continue replacing hardcoded Windows-specific paths with `Environment` or `Path` abstractions.
