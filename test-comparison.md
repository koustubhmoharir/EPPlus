# EPPlus Test Comparison Report

This report compares test execution results between the **stable-released** branch and the **stable-net472** branch.

## Summary Statistics

| Metric | Count |
| :--- | :--- |
| **Total Unique Test Cases** | **1523** |
| Test Cases in **stable-released** | 1252 |
| Test Cases in **stable-net472** | 1523 |
| Unchanged (Passed -> Passed) | 896 |
| Unchanged (Failed -> Failed) | 186 |
| Unchanged (Skipped -> Skipped) | 166 |
| **Regressions (Passed -> Failed)** | <span style="color:red">**1**</span> |
| **Regressions (Passed -> Skipped)** | 2 |
| **Regressions (Passed -> Missing)** | 0 |
| **Improvements (Failed -> Passed)** | <span style="color:green">**0**</span> |
| **Improvements (Skipped -> Passed)** | 0 |
| **Improvements (New Passed)** | 248 |
| New Failed Tests | 22 |
| New Skipped Tests | 1 |
| Other Changes | 1 |

## Detailed Comparison Table

| Class | Test Name | stable-released | stable-net472 | Comparison Status |
| :--- | :--- | :--- | :--- | :--- |
| EPPlusTest.Address | Addresses | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | InsertDeleteTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | IsValidCellAdress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeDoesNotChangeIfRowInsertedBelow | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeExpandsDownIfRowInsertedWithin | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeExpandsToRightIfColInsertedWithin | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeIsUnchangedForOutOfScopeSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeMovesDownIfRowInsertedAbove | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeMovesRightIfColInsertedBefore | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeUnchangedIfColInsertedAfter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeWithWorkbookScopeIsMovedDownIfRowInsertedAbove | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeWithWorkbookScopeIsMovedRightIfColInsertedBefore | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | ShouldHandleWorksheetSpec | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | SplitAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | TestComplexWorkbookAndSheetPrefix | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Address | TestEscapedSingleQuoteInSheetName | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Calculation | CalcTwiceError | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | CalculateDateMath | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | CalculateTest | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | CalculateTestIsFunctions | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Calculation | Calulation4 | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | CalulationTestDatatypes | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | CalulationValidationExcel | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | IfError | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Calculation | IfFunctionTest | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | INTFunctionTest | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | LeftRightFunctionTest | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | TestDataType | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Calculation | TestOneCell | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Calculation | TestPrecedence | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.CellStoreTest | CopyCellsTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | DeleteCells | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | DeleteCellsFirst | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | DeleteInsert | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | EnumCellstore | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | FillInsertTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | Insert1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | Insert2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | Insert3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | InsertRandomTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ComHelperTest | TestComHelperMethods | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.CommentsTest | ReadExcelComments | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.CommentsTest | ReadGoogleComments | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.CommentsTest | VisibilityComments | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | Databar | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | DatabarChangingAddressAddsConditionalFormatNodeInSchemaOrder | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | IconSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | IconSet_GreaterThanOrEqualTo_XmlTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ConditionalFormatting | ReadConditionalFormatting | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ConditionalFormatting | ReadConditionalFormattingError | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoAndThreeColorConditionalFormattingFromFileDoesNotGetOverwrittenWithDefaultValues | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoAndThreeColorScale_XmlTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ConditionalFormatting | TwoAndThreeColorScaleDefaultColors | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ConditionalFormatting | TwoBackColor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoColorScale | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32BasicCalculations | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrc32Combine | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrc32ComputeCrc32 | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrc32GetCrc32AndCopy | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrc32NullInputs | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrc32ReverseBits | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrc32UpdateCrc | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamConstructors | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamLengthLimit | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamPropertiesAndUnsupportedMethods | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamReadWrite | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.DataValidation.CustomValidationTests | CustomValidation_FormulaIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.CustomValidationTests | CustomValidation_ShouldThrowExceptionIfFormulaIsTooLong | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldAcceptOneItemOnly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetErrorFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetErrorTitleFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetOperatorFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetPromptFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetPromptTitleFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetShowErrorMessageFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetShowInputMessageFromExistingXml | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldThrowIfOperatorIsBetweenAndFormula2IsEmpty | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldThrowIfOperatorIsEqualAndFormula1IsEmpty | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | ExcelDataValidation_ShouldReplaceLastPartInWholeColumnRangeWithMaxNumberOfRowsDifferentColumns | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | ExcelDataValidation_ShouldReplaceLastPartInWholeColumnRangeWithMaxNumberOfRowsOneColumn | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DecimaDataValidationTests | DecimalDataValidation_Formula1IsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DecimaDataValidationTests | DecimalDataValidation_Formula2IsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldSetHour | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldSetMinute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldSetSecond | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldThrowIfValueIsEqualToOrGreaterThan1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldThrowIfValueIsLessThan0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Hour_ShouldThrowIfNegativeValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Minute_ShouldThrowIfNegativeValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Minute_ShouldThrowIValueIsGreaterThan59 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Second_ShouldThrowIfNegativeValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Second_ShouldThrowIValueIsGreaterThan59 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ToExcelTime_HourIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ToExcelTime_MinuteIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ToExcelTime_SecondIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.CustomFormulaTests | CustomFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DateTimeFormulaTests | DateTimeFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DateTimeFormulaTests | DateTimeFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DecimalFormulaTests | DecimalFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DecimalFormulaTests | DecimalFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_Constructor_ShouldHandleEmptyOrNullValue | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_SetValue_ShouldUpdateXmlValue | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_SetValueNull_ShouldUpdateXmlValueToEmpty | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.DataValidation.Formulas.ListFormulaTests | ListFormula_FormulasExcelFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.ListFormulaTests | ListFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.ListFormulaTests | ListFormula_FormulaValueIsSetFromXmlNodeInConstructorOrderIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.TimeFormulaTests | TimeFormula_ValueIsSetFromConstructorValidateHour | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.TimeFormulaTests | TimeFormula_ValueIsSetFromConstructorValidateMinute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.TimeFormulaTests | TimeFormula_ValueIsSetFromConstructorValidateSecond | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeDecimal | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeListOfTypeList | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeListOfTypeTime | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeWhole | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_ReadExistingWorkbookWithDataValidations | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | RemoveDataValidation | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.ListDataValidationTests | ListDataValidation_FormulaIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ListDataValidationTests | ListDataValidation_ShouldThrowWhenNoFormulaOrValueIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ListDataValidationTests | ListDataValidation_WhenOneItemIsAddedCountIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDateTimeValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDateTimeValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDecimalValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDecimalValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddIntegerValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddIntegerValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddListValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddListValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddTextLengthValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddTextLengthValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddTimeValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AdTimeValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddDateTime_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddDecimal_ShouldThrowWhenAddressIsNullOrEmpty | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddDecimal_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddInteger_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddTextLength_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_Clear_ShouldBeEmpty | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_Find_ShouldReturnFirstMatchOnly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_FindAll_ShouldReturnValidationInColumnAonly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_Index_ShouldReturnItemAtIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_RemoveAll_ShouldRemoveMatchingEntries | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DotNetZip.ZipDirEntryTest | ZipDirEntry_DuplicateFilesHandling_Ignore | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.DotNetZip.ZipDirEntryTest | ZipDirEntry_DuplicateFilesHandling_Rename | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | CrossesAt_SetTo1EMinus6_Is1EMinus6 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | CrossesAt_SetTo2_Is2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_GetMajor_IsNotNullAndCreatesNode | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_GetMinor_IsNotNullAndCreatesNode | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_RemoveGridlinesDefault_RemovesBoth | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_RemoveGridlinesSelective_RemovesExpected | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MaxValue_SetTo1EMinus6_Is1EMinus6 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MaxValue_SetTo2_Is2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MinValue_SetTo1EMinus6_Is1EMinus6 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MinValue_SetTo2_Is2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_ChartSheetMultipleCharts_ThrowsInvalidOperationException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_DuplicateName_ThrowsException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_DuplicateNameDifferentCase_ThrowsException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_ExistingDrawingPartConflict_ResolvesConflictOnCore | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_UnsupportedStockChartType_ThrowsNotImplementedException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_WithPivotTableSource_CreatesPivotChart | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | RoundedCorners_Default_IsFalse | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | RoundedCorners_SetToTrue_IsTrue | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | SaveAndLoad_ChartWithRoundedCornersAndStyle_PersistsCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | Style_SetAndGet_WorksCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.ExcelPictureTest | ExcelPicture_AddPicture_SetsPropertiesCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.DrawingTest | AllDrawingsInsideMarkupCompatibility | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ChartWorksheet | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | DrawingWidthAdjust | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DrawingTest | DrawingWorksheetCopy | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ReadChartWorksheet | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ReadMultiChartSeries | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ReadWriteSmoothChart | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | RunDrawingTests | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DrawingTest | TestHeaderaddress | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.DTS_FailingTests | CopyAndDeleteWorksheetWithImage | 🟢 Passed | 🟡 Skipped | ⚠️ **Regression (Passed -> Skipped)** |
| EPPlusTest.DTS_FailingTests | DeleteWorksheetWithReferencedImage | 🟢 Passed | 🟡 Skipped | ⚠️ **Regression (Passed -> Skipped)** |
| EPPlusTest.Encrypt | DecrypTest | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | DecrypTestBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | EncrypTest | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | ReadWriteEncrypt | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | WriteEncrypt | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | WriteProtect | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.EncryptedPackageHandlerTest | TestAgileEncryptionDecryption | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.EncryptedPackageHandlerTest | TestStandardEncryptionDecryption | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfo_UnsupportedRC4 | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfo_UnsupportedVersion | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoAgile_PropertyMutations | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoAgile_ReadWrite_ByteArray | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoAgile_ReadWrite_FileStream | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoBinary_ReadWrite_ByteArray | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoBinary_ReadWrite_FileStream | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ArgumentParserFactoryTests | ShouldReturnBoolArgumentParserWhenDataTypeIsBoolean | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParserFactoryTests | ShouldReturnDoubleArgumentParserWhenDataTypeIsDecial | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParserFactoryTests | ShouldReturnIntArgumentParserWhenDataTypeIsInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvert0ToFalse | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvert1ToTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvertNullToFalse | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvertStringValueTrueToBoolValueTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserConvertDateStringToDouble | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserConvertStringToDoubleWithDotSeparator | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserShouldConvertDoubleToDouble | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserShouldConvertIntToDouble | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserShouldThrowIfArgumentIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldConvertADoubleToAnInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldConvertAStringValueToAnInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldConvertToAnInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldThrowIfArgumentIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersTests | ShouldReturnSameInstanceOfIntParserWhenCalledTwice | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DateFunctionShouldMonthFromPrevYearIfMonthIsNegative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DateFunctionShouldReturnACorrectDate | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DateFunctionShouldReturnADate | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldHandleFebWithEuroMethodSpecified | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldHandleFebWithUsMethodSpecified | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldHandleFebWithUsMethodSpecified2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldReturnCorrectResultWithEuroMethodSpecified | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldReturnCorrectResultWithNoMethodSpecified2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DayShouldReturnDayInMonth | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DayShouldReturnMonthOfYearWithStringParam | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | EdateShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | EomonthShouldReturnCorrectResultWithNegativeArg | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | EomonthShouldReturnCorrectResultWithPositiveArg | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | HourShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | HourShouldReturnCorrectResultWithStringArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | IsoWeekShouldReturn1When1StJan | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MinuteShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MinuteShouldReturnCorrectResultWithStringArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MonthShouldReturnMonthOfYear | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MonthShouldReturnMonthOfYearWithStringParam | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdayIntlShouldReduceHoliday | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdayIntlShouldUseWeekendArg | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdayIntlShouldUseWeekendStringArg | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdaysNegativeShouldReturnNumberOfDays | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdaysShouldReturnNumberOfDays | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdaysShouldReturnNumberOfDaysWithHolidayRange | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NowFunctionShouldReturnNow | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | SecondShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | SecondShouldReturnCorrectResultWithStringArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldParseStringCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldReturnACorrectSerialNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldThrowExceptionIfHourIsOutOfRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldThrowExceptionIfMinuteIsOutOfRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldThrowExceptionIfSecondsIsOutOfRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TodayFunctionShouldReturnTodaysDate | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekdayShouldReturnCorrectResultForASundayWhenReturnTypeIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekdayShouldReturnCorrectResultForASundayWhenReturnTypeIs2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekdayShouldReturnCorrectResultForASundayWhenReturnTypeIs3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekNumShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayShouldReturnCorrectResultIfNoHolidayIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayShouldReturnCorrectResultWithFourDaysSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayShouldReturnCorrectResultWithNegativeArg | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayWithNegativeArgShouldReturnCorrectWhenArrayOfHolidayDatesIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayWithNegativeArgShouldReturnCorrectWhenRangeWithHolidayDatesIsSupplied | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearFracActualActual | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearFracShouldReturnCorrectResultWithEuroBasis | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearFracShouldReturnCorrectResultWithUsBasis | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearShouldReturnCorrectYear | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearShouldReturnCorrectYearWithStringParam | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | Equals_ShouldReturnFalse_ForDifferentValues | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | Equals_ShouldReturnTrue_ForSameValueDifferentRow | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | GetHashCode_ShouldReturnSameValue_ForEqualObjects | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | GetHashCode_ShouldReturnSameValue_ForEqualObjectsWithRow | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | ArgToAddress_ShouldReturnAddressForRange | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | ArgToAddress_ShouldReturnStringForNonRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | IsNumeric_ShouldReturnFalseForNonNumericTypes | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | IsNumeric_ShouldReturnTrueForNumericTypes | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelFunctionTests | ArgsToDoubleEnumerableShouldHandleInnerEnumerables | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.FunctionArgumentTests | ExcelStateFlagIsSetShouldReturnFalseWhenNotSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.FunctionArgumentTests | ShouldSetExcelState | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsBlankShouldReturnTrueIfFirstArgIsEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsBlankShouldReturnTrueIfFirstArgIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsErrorShouldReturnFalseIfArgIsNotAnError | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsErrorShouldReturnTrueIfArgIsAnErrorCode | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsEvenShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsLogicalShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNonTextShouldReturnFalseWhenFirstArgIsAString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNonTextShouldReturnTrueWhenFirstArgIsNotAString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNumberShouldReturnfalseWhenArgIsNonNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNumberShouldReturnTrueWhenArgIsNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsOddShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsTextShouldReturnFalseWhenFirstArgIsNotAString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsTextShouldReturnTrueWhenFirstArgIsAString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | NshouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldHandleStringLiteralTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnFalseIfOneArgumentIs0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnFalseIfOneArgumentIsFalse | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnTrueIfAllArgumentsAreTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnTrueIfAllArgumentsAreTrueOr1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfErrorShouldReturnResultOfFormulaIfNoError | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfErrorShouldReturnSecondArgIfCriteriaEvaluatesAsAnError | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfErrorShouldReturnSecondArgIfCriteriaEvaluatesAsAnError2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfNaShouldReturnResultOfFormulaIfNoError | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfNaShouldReturnSecondArgIfCriteriaEvaluatesAsAnError2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfShouldIgnoreCase | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldHandleExcelReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldHandleExcelReferenceToStringFalse | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldHandleExcelReferenceToStringTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldReturnFalseIfArgumentIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldReturnFalseIfArgumentIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldReturnTrueIfArgumentIs0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | OrShouldReturnTrueIfOneArgumentIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | OrShouldReturnTrueIfOneArgumentIsTrueString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AbsShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ACosHShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AcosShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AsinhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AsinShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | Atan2ShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AtanhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AtanShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldCountNumericStringWithValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldCountValueAs0IfNonNumericTextIsSuppliedInArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldIncludeTrueAs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldThrowValueExceptionIfNonNumericTextIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldCalculateCorrectResultWithEnumerableAndBoolMembers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldIgnoreHiddenFieldsIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldThrowDivByZeroExcelErrorValueIfEmptyArgs | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldReturnNumberIfSignificanceIsMultipleOfNumber | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundTowardsZeroIfSignificanceAndNumberIsMinus0point1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundTowardsZeroIfSignificanceAndNumberIsNegative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundUpAccordingToParamsSignificanceIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundUpAccordingToParamsSignificanceIs10 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundUpAccordingToParamsSignificanceLowerThan0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldThrowExceptionIfNumberIsPositiveAndSignificanceIsNegative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CosHShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CosShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountAShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountAShouldIncludeEnumerableMembers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountAShouldReturnNumberOfNonWhitespaceItems | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountIfShouldHandleNegativeCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldIncludeEnumerableMembers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldIncludeNumericStringsAndDatesInArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldReturnNumberOfNumericItems | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ExpShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FactShouldRoundDownAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FactShouldThrowWhenNegativeNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnCorrectResultWhenSignificanceIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnCorrectResultWhenSignificanceIsBetween0And1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnCorrectResultWhenSignificanceIsMinus1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnNumberIfSignificanceIsMultipleOfNumber | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LargeShouldReturnTheLargestNumberIf1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LargeShouldReturnTheSecondLargestNumberIf2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LargeShouldThrowIfIndexOutOfBounds | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LnShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | Log10ShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LogShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LogShouldReturnCorrectResultWithBase | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxaShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxaShouldCalculateCorrectResultUsingBool | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxaShouldCalculateCorrectResultUsingString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldCalculateCorrectlyWithEvenMembers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldCalculateCorrectlyWithOddMembers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldCalculateCorrectlyWithOneMember | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldThrowIfNoArgs | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MinShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MinShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ModShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | PiShouldReturnPIConstant | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldHandleEnumerable | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldHandleFirstItemIsEnumerable | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldIgnoreHiddenValuesIfIgnoreHiddenIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldMultiplyArguments | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | QuotientShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | QuotientShouldThrowWhenDenomIs0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RandBetweenShouldReturnAnIntegerValueBetweenSuppliedValues | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RandBetweenShouldReturnAnIntegerValueBetweenSuppliedValuesWhenLowIsNegative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RandShouldReturnAValueBetween0and1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | Rank | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldHandleNegativeNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldHandleNegativeNumDigits | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldHandleZeroNumDigits | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldReturn0IfNegativeNumDigitsIsTooLarge | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldReturnCorrectResultWithPositiveNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundShouldReturnCorrectResultWhenNbrOfDecimalsIsNegative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundupShouldHandleNegativeNumDigits | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundupShouldHandleZeroNumDigits | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundupShouldReturnCorrectResultWithPositiveNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SignShouldReturn1IfArgIsPositive | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SignShouldReturnMinus1IfArgIsNegative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SinhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SinShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SmallShouldReturnTheSecondSmallestNumberIf2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SmallShouldReturnTheSmallestNumberIf1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SmallShouldThrowIfIndexOutOfBounds | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SqrtPiShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevPShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevPShouldIgnoreHiddenValuesWhenIgnoreHiddenValuesIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevShouldIgnoreHiddenValuesWhenIgnoreHiddenValuesIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumShouldCalculate2Plus3AndReturn5 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumShouldCalculateEnumerableOf2Plus5Plus3AndReturn10 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumShouldIgnoreHiddenValuesWhenIgnoreHiddenValuesIsSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumSqShouldCalculateArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumSqShouldIncludeTrueAsOne | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumSqShouldNoCountTrueTrueInArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | TanhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | TanShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | TruncShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarPShouldIgnoreHiddenValuesIfIgnoreHiddenIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarPShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarShouldIgnoreHiddenValuesIfIgnoreHiddenIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | CIntShouldConvertTextToInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | IntShouldConvertDecimalToInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | IntShouldConvertNegativeDecimalToInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | IntShouldConvertStringToInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | CurrentValueShouldBeFirstCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | GetLookupValueShouldReturnCorrespondingValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | GetLookupValueShouldReturnCorrespondingValueWithOffset | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | HasNextShouldBeTrueIfNotLastCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | MoveNextShouldIncreaseIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | MoveNextShouldNavigateVertically | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | MoveNextShouldReturnFalseIfLastCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldReturnAddressByIndexWithDefaultRefType | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldReturnAddressByIndexWithRelativeType | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldReturnAddressByWithSpecifiedWorksheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldThrowIfR1C1FormatIsSpecified | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ChooseShouldReturnItemByIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ColumnShouldReturnRowFromCurrentScopeIfNoAddressIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ColumnShouldReturnRowSuppliedAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ColumnssShouldReturnNbrOfRowsSuppliedRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | HLookupShouldReturnErrorIfNoMatchingRecordIsFoundWhenRangeLookupIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | HLookupShouldReturnNaErrorIfNoMatchingRecordIsFoundWhenRangeLookupIsFalse | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | HLookupShouldReturnResultFromMatchingRow | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetColIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetRangeAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetRangeLookupToTrueAsDefaultValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetRangeLookupToTrueWhenTrueIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetSearchedValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingRowArrayHorizontal | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingRowArrayVertical | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingSecondArrayHorizontal | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingSecondArrayHorizontalWithOffset | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldHandleAddressOnOtherSheet | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnFirstItemWhenExactMatch_MatchTypeClosestAbove | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValHorizontal_MatchTypeClosestAbove | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValHorizontal_MatchTypeClosestBelow | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValHorizontal_MatchTypeExact | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValVertical_MatchTypeExact | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowShouldReturnRowFromCurrentScopeIfNoAddressIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowShouldReturnRowSuppliedAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowsShouldReturnNbrOfRowsForEntireColumn | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowsShouldReturnNbrOfRowsSuppliedRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | VLookupShouldReturnClosestStringValueBelowWhenRangeLookupIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | VLookupShouldReturnClosestValueBelowWhenRangeLookupIsTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | VLookupShouldReturnResultFromMatchingRow | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldHandleNegativeDigitsCorrectly | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldHandleNegativeNumbersCorrectly | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldReturnCorrectResultForPositiveDigits | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldUseAwayFromZeroRounding | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateAverageWhenCalcTypeIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateAverageWhenCalcTypeIs101 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountAWhenCalcTypeIs103 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountAWhenCalcTypeIs3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountWhenCalcTypeIs102 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountWhenCalcTypeIs2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMaxWhenCalcTypeIs104 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMaxWhenCalcTypeIs4 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMinWhenCalcTypeIs105 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMinWhenCalcTypeIs5 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateProductWhenCalcTypeIs106 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateProductWhenCalcTypeIs6 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevPWhenCalcTypeIs108 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevPWhenCalcTypeIs8 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevWhenCalcTypeIs107 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevWhenCalcTypeIs7 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateSumWhenCalcTypeIs109 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateSumWhenCalcTypeIs9 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarPWhenCalcTypeIs11 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarPWhenCalcTypeIs111 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarWhenCalcTypeIs10 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarWhenCalcTypeIs110 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldThrowIfInvalidFuncNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ConcatenateShouldConcatenateStringWithInt | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ConcatenateShouldConcatenateThreeStrings | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | CStrShouldConvertNumberToString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnFalseWhenStringAndNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnFalseWhenTwoEqualStringsWithDifferentCase | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnTrueWhenEqualStringAndDouble | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnTrueWhenTwoEqualStrings | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | FindShouldReturnIndexOfFoundPhrase | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | FindShouldReturnIndexOfFoundPhraseBasedOnStartIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | HyperLinkShouldReturnArgIfOneArgIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | HyperLinkShouldReturnLastArgIfTwoArgsAreSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | LeftShouldReturnSubstringFromLeft | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | LenShouldReturnStringsLength | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | LowerShouldReturnLowerCaseString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | MidShouldReturnSubstringAccordingToParams | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldHandleEmptyString | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldHandleNumbers | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldHandleOnlySymbols | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldSetFirstLetterToUpperCase | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ReplaceShouldReturnAReplacedStringAccordingToParamsWhenStartIxIs1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ReplaceShouldReturnAReplacedStringAccordingToParamsWhenStartIxIs3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | RightShouldReturnSubstringFromRight | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | SubstituteShouldReturnAReplacedStringAccordingToParamsWhen | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | UpperShouldReturnUpperCaseString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleDate | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleEmptyString | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleNumericString | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandlePercent | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleTime | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldReturnErrorIfInvalid | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.TimeStringParserTests | CanParseShouldHandleValid12HourPatterns | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | CanParseShouldHandleValid24HourPatterns | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldIdentify12HourAMPatternAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldIdentify12HourPMPatternAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldIdentifyPatternAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldThrowExceptionIfMinuteIsOutOfRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldThrowExceptionIfSecondIsOutOfRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatoMultiplyShouldMultiplyNumericStringAndNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorConcatShouldConcatANumberAndAString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorConcatShouldConcatTwoStrings | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldDivideCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldDivideNumericStringAndNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldReturnDivideByZeroIfRightOperandIsZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldReturnValueErrorIfNonNumericOperand | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorEqShouldReturnFalsefSuppliedValuesDiffer | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorEqShouldReturnTruefSuppliedValuesAreEqual | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorExpShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorGreaterThanToShouldReturnTrueIfLeftIs11AndRightIs10 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorGreaterThanToShouldReturnTrueIfLeftIsSetAndRightIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorMinusShouldSubtractNumericStringAndNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorMinusShouldThrowExceptionIfNonNumericOperand | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorMultiplyShouldThrowExceptionIfNonNumericOperand | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorNotEqualToShouldReturnFalsefSuppliedValuesAreEqual | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorNotEqualToShouldReturnTruefSuppliedValuesDiffer | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorPlusShouldAddNumericStringAndNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorPlusShouldThrowExceptionIfNonNumericOperand | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorsActingOnDateStrings | 🔴 Failed | 🟡 Skipped | Change (Failed -> Skipped) |
| EPPlusTest.Excel.OperatorsTests | OperatorsActingOnNumericStrings | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | IsValidAddress_Basic | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | IsValidAddress_MultiAddress | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | TranslateFromR1C1_Basic | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | TranslateFromR1C1_Ranges | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | TranslateFromR1C1_SheetQualified | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | TranslateToR1C1_Basic | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | TranslateToR1C1_Ranges | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | TranslateToR1C1_SheetQualified | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesFullyQualifiedCrossSheetReferenceArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesFullyQualifiedReferenceOnADifferentSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesFullyQualifiedReferenceOnTheSameSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesIgnoresIncorrectSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesOnTheSameSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesReferencingADifferentSheetIsNotUpdated | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferences | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesEmptyNewSheetThrowsException | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesEmptyOldSheetThrowsException | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesNullNewSheetThrowsException | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesNullOldSheetThrowsException | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelColorTest | LookupColorTintRounding | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelColorTest | SetColorTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertDuplicatePictureThrows | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertMissingFileInfoThrows | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertPictureFileInfo | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertPictureImage | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterProperties | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterTextFormatting | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestScaleWithDocumentPersistence | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionAddAndLookup | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionAddValueAndFormula | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionInsertRowsAndColumnsBounds | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionNameValidation | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionRemoveAndClear | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorDefault | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorFileInfo | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorFileInfoTemplate | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorStream | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorStreamTemplate | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageEncryptionSupport | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.ExcelPackageTest | TestExcelPackageSaveAsFileInfo | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageSaveAsStream | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangeCollectionOperations | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangeDuplicateName | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangePropertiesAndSetPassword | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangeSerialization | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRangeBaseTest | ClearAndDeleteTests | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRangeBaseTest | CopyCopiesCommentsFromMultiCellRanges | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | CopyCopiesCommentsFromSingleCellRanges | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | ExcelNamedRangeLocalSheetIdTests | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRangeBaseTest | GetDateTextFormattingTests | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRangeBaseTest | GetValueTypedConversions | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRangeBaseTest | LoadFromTextComprehensiveTests | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRangeBaseTest | SettingAddressHandlesMultiAddresses | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_AllTags_Test | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_BrTag_Test | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_HtmlDecode_Test | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_NonBreakingSpace_Test | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelStylesDivergenceTest | AddNewStyleColumnContiguousRangeTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelStylesDivergenceTest | CreateNamedStyleFromOtherWorkbookTest | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.ExcelStyleTest | ApplyProtectionAndAlignmentTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelStyleTest | QuotePrefixStyle | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ConstructorShouldThrowIfProviderIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateLetterAddressUsingMaxRowsFromProviderLower | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateLetterAddressUsingMaxRowsFromProviderUpper | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateLettersToColumnIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateRowNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.CellReferenceProviderTests | ShouldReturnReferencedMultipleAddresses | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.CellReferenceProviderTests | ShouldReturnReferencedSingleAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | AddressOnSheetShouldBeSameAsAddressIfNoWorksheetIsSpecified | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ParseShouldSetAddressOnSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ParseShouldSetWorksheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ParseShouldThrowIfAddressIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ShouldIndicateMultipleCellsWhenAddressContainsAColon | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ShouldSetEndCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ShouldSetStartCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | WorksheetIsSpecifiedShouldBeTrueWhenWorksheetIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldThrowIfExcelDataProviderIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate1And1ToA1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate27And1ToAA1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate53And1ToBA1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate702And1ToZZ1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate703ToAAA4 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToAbsoluteAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToAbsoluteRowAndRelativeCol | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToEntireColumnWhenRowIsEqualToMaxRows | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToRelativeRowAndAbsoluteCol | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToRelativeRowAndCol | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldHandleTableAddress | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAndInstanceWithColPropertiesSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAndInstanceWithRowPropertiesSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToColSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToColSetWhenARangeAddressIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToRowSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToRowSetWhenARangeAddressIsSupplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithStringAddressSet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithWorksheetSetToEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnEntireColumnRangeWhenNoRowsAreSpecified | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldSetWorksheetNameIfSuppliedInAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldThrowIfSuppliedAddressIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressTests | CollideShouldReturnFalseIfRangesCollidesButWorksheetNameDiffers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressTests | CollideShouldReturnFalseIfRangesDoesNotCollide | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressTests | CollideShouldReturnTrueIfRangesCollides | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenBothParamsAreEqual | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenBothParamsAreNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenParamsAreEqualButDifferentTypes | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenWhenParamsAreEqualStrings | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn1WhenFirstParamIsGreaterThanSecondParam | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn1WhenFirstParamIsSomethingAndSecondParamIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturnMinus1WhenFirstParamIsLessThanSecondParam | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturnMinus1WhenFirstParamIsNullAndSecondParamIsSomething | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturnMînus2WhenTypesDifferAndStringConversionToDoubleFails | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.WildCardValueMatcherTests | IsMatchShouldReturn0WhenMultipleCharWildCardMatches | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.WildCardValueMatcherTests | IsMatchShouldReturn0WhenSingleCharWildCardMatches | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorkbookTest | Workbook_PivotTableNames_CaseSensitive_On_Stable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorkbookTest | Workbook_Properties_CalcMode | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorkbookTest | Workbook_Properties_Date1904 | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorkbookTest | Workbook_TableNames_CaseInsensitive_On_Stable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorkbookTest | Workbook_Worksheets_Access_1Based | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestExtendedPropertiesSyncBaseline | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestNextTableIdInitializationBaseline | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestVBAModuleCreationBaseline | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestWorksheetCopyingWithMergedCells | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestWorksheetCopyingWithPivotTable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestWorksheetIndexingBaseline | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetViewDivergenceTest | TestTabSelectedBaseline | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestBadCrcException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestBadPasswordException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestBadReadException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestBadStateException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestSfxGenerationException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestZipException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateBlankExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateBlankExpressionEqualsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateBlankExpressionEqualsZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsDifferentCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsNumeral | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsSameCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsDifferentCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsNumeral | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsSameCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsNonZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsNonZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateQuotesExpressionEqualsCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateQuotesExpressionEqualsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateQuotesExpressionEqualsZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldEvaluateNumericString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldEvaluateOperator | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldHandleBooleanArg | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldHandleDateArg | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldHandleDateArgWithOperator | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldReturnTrueIfOperandsAreEqual | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldReturnTrueIfOperandsAreMatchingButDifferentTypes | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldThrowIfOperatorIsNotBoolean | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FileSelectorTest | TestFileSelectorComplexCriteria | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FileSelectorTest | TestFileSelectorEvaluate | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FileSelectorTest | TestFileSelectorSimpleName | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FileSelectorTest | TestFileSelectorSizeSuffixes | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FinanceFunctionsTest | TestPmtFunction | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithNormalAddress_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableAddress_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableAll_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableData_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableHeaders_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableThisRow_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableTotals_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleMultipleRangesAndCriterias | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleNullRangeCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleNumericCriteria | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleNumericWildcardCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleRangeCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleStringCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleStringWildcardCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.CriteriaTests | CriteriaShouldIgnoreEmptyFields1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.CriteriaTests | CriteriaShouldIgnoreEmptyFields2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.CriteriaTests | CriteriaShouldReadFieldsAndValues | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | DatabaseShouldReadFields | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | DatabaseShouldReadFieldsInRow | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | HasMoreRowsShouldBeFalseWhenLastRowIsRead | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | HasMoreRowsShouldBeTrueWhenInitialized | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldHandleFieldIndex | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchNumericExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchStrings1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchStrings2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchWildcardStrings | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldReturnFalseIfCriteriasDoesNotMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldReturnTrueIfCriteriasMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.FunctionRepositoryTests | LoadModulePopulatesFunctionsAndCustomCompilers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageAArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageACellReferences | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageALiterals | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageAUnparsableLiteral | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfEqualToEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanOrEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanOrEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNonNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNotEqualToNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNotEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNumericExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageCellReferences | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageLiterals | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageUnparsableLiteral | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfEqualToEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanOrEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanOrEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNonNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNotEqualToNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNotEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNumericExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfEqualToEmptyString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanOrEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfHandleDates | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanOrEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNonNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNotEqualToNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNotEqualToZero | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNumeric | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNumericExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfShouldHandleBooleanArg | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseMultipleValues | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseSingleFormula | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseSingleValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseValueAndFormula | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.IndexTests | Index_Should_Handle_SingleRange | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.IndexTests | Index_Should_Return_Value_By_Index | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.LookupNavigatorFactoryTests | Should_Return_ArrayLookupNavigator_When_Array_Is_Supplied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.LookupNavigatorFactoryTests | Should_Return_ExcelLookupNavigator_When_Range_Is_Set | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.SumIfsTests | ShouldCalculateTwoCriteriaRanges | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.SumIfsTests | ShouldHandleExcelRangesInCriteria | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.SumIfsTests | ShouldIgnoreErrorInCriteriaRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | GetValidName_ShouldFixFirstChar | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | GetValidName_ShouldReplaceInvalidChars | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | GetValidName_ShouldReturnOriginal_IfEmpty | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfContainsInvalidChars | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfFirstCharIsBackslashAndLengthIs2OrLess | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfFirstCharIsInvalid | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfIsAValidCellAddress | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfNameIsEmpty | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnTrue_IfFirstCharIsBackslashAndLengthGreaterThan2 | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnTrue_IfFirstCharIsLetterOrUnderscore | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnTrue_IfIsValid | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.CompileResultFactoryTests | CalculateUsingEuropeanDates | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.CompileResultTests | DateStringCompileResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.CompileResultTests | NumericStringCompileResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.EnumerableExpressionTests | CompileShouldReturnEnumerableOfCompiledChildExpressions | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceAbsolute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceColumnAbsolute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceRowAbsolute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceWithValues | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRangeAbsolute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRangeColumnAbsolute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRangeRowAbsolute | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceWithValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | ConstructorShouldThrowIfExcelDataProviderIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | ConstructorShouldThrowIfParsingContextIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionCompilerTests | CompileShouldCalculateMultipleExpressionsAccordingToPrecedence | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionCompilerTests | CompileShouldMultiplyGroupExpressionWithFollowingIntegerExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionCompilerTests | ShouldCompileTwoInterExpressionsToCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateBooleanExpressionIfCompileResultIsBoolean | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateBooleanExpressionIfCompileResultIsBooleanString | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDate | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDecimal | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDecimalString | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsTime | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateExcelErrorExpressionIfCompileResultIsExcelError | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateExcelErrorExpressionIfCompileResultIsExcelErrorString | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsEmpty | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsInteger | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsIntegerString | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateStringExpressionIfCompileResultIsString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | InstanceShouldReturnAnInstance | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | ToStringExpressionShouldConvertDecimalExpressionToStringExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | ToStringExpressionShouldConvertIntegerExpressionToStringExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | ToStringExpressionShouldCopyOperatorToStringExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnBooleanExpressionWhenTokenIsBoolean | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnDecimalExpressionWhenTokenIsDecimal | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnExcelRangeExpressionWhenTokenIsExcelAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnIntegerExpressionWhenTokenIsInteger | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnNamedValueExpressionWhenTokenIsNamedValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildExcelAddressExpressionSimple | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldAddCommaSeparatedFunctionArgumentsAsChildrenToFunctionExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldAddOperatorToFunctionExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldBuildFunctionExpressionIfFirstTokenIsFunction | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldCreateASingleExpressionOutOfANegatorAndANumericToken | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldHandleEnumerableTokens | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldNotEvaluateExpressionsWithinAString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldNotUseStringIdentifyersWhenBuildingStringExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetChildrenOnFunctionExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetChildrenOnGroupExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetNextOnGroupedExpression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetOperatorOnGroupExpressionCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | RemoveDuplicateOperators1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | RemoveDuplicateOperators2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | ShouldHandleInnerFunctionCall2 | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | ShouldHandleInnerFunctionCall3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesCustomFunctionCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesErrorFunctionCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesLookupFunctionCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesSpecialIfCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesSpecialIfErrorCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesSpecialIfNaCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesStandardFunctionCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.IntegerExpressionTests | MergeWithNextWithPlusOperatorShouldCalulateSumCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.IntegerExpressionTests | MergeWithNextWithPlusOperatorShouldSetNextPointer | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserManagerTests | FunctionsShouldBeCopied | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParseAtShouldCallExcelDataProvider | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParseAtShouldThrowIfAddressIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParserShouldCallCompiler | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParserShouldCallGraphBuilder | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParserShouldCallLexer | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldAddIntegersCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldDivideDecimalWithIntegerCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldDivideIntegersCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleDecimalNumberWhenDividingIntegers | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleExpCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleExpWithDecimalCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleMultiplePercentSigns | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandlePercentageOnFunctionResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandlePercentageOnParantethis | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldIgnoreLeadingPlus | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldMultiplyDecimalWithDecimalCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldMultiplyIntegersCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldNegateExpressionInParenthesis | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldSubtractIntegersCorrectly | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | TenPercentShouldBe0Point1 | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeGreaterThanOrEqualToThreeShouldBeTrue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeGreaterThanTwoShouldBeTrue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeLessThanOrEqualToThreeShouldBeTrue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeLessThanOrEqualToTwoDotThreeShouldBeFalse | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeLessThanTwoShouldBeFalse | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | TwelveAndTwelveShouldBeEqual | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | TwoDotTwoGreaterThanOrEqualToThreeShouldBeFalse | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DAverageShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DcountaShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DcountShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DgetShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DMaxShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DMinShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DSumShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DVarpShouldReturnByFieldIndex | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DVarpShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DVarShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | Calculation5 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateNotEqualToStringShouldBeTrue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateShouldHandleCellReference | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTest1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTestWithoutYear | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTestWithTwoDigitYear | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTestWithTwoDigitYear2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | Day360ShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DayShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | EomonthShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | HourShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | HourShouldReturnCorrectResultWhenParsingString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | HourWithExcelReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | IsoWeekNumShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MinuteShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MinuteShouldReturnCorrectResultWhenParsingString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MinuteWithExcelReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MonthShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | NowShouldReturnAResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | SecondShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | SecondShouldReturnCorrectResultWhenParsingString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | SecondWithExcelReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TimeShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TimeValueTestFullDate | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TimeValueTestPm | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TodayShouldReturnAResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | WorkdayShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | YearfracShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | YearShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AbsShouldReturn3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleLookupRangeStringMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleLookupRangeStringNumericMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleLookupRangeStringWildCardMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleSingleRangeNumericExpressionMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleSingleRangeStringMatch | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageShouldReturn3Point333333 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountAShouldReturn3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountIfShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountShouldReturn2IfACellValueIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountShouldReturn3 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | MaxShouldReturn6 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | MinShouldReturn1 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | ShouldIgnoreNullValues | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SignShouldReturn1WhenRefIsPositive | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SubTotalShouldNotIncludeHiddenRow | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SumProductShouldWorkWithSingleCellArray | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SumProductWithRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SumProductWithRangeAndValues | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ExactShouldReturnTrueWhenEqualValues | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | FindShouldReturnIndexCaseSensitive | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | SearchShouldReturnIndexCaseInSensitive | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandle1000delimiter | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandle1000DelimiterAndDecimal | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleDate | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandlePercent | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleScientificNotation | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleStringWithIntegers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleTime | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.WorksheetRefsTest | ShouldHandleInvalidRef | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.WorksheetRefsTest | ShouldHandleReferenceToOtherSheet | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.WorksheetRefsTest | ShouldHandleReferenceToOtherSheetWithComplexName | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | ErrorTypeShouldReturnCorrectErrorCodes | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsBlankShouldReturnCorrectValue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsErrorShouldReturnTrueWhenDivBy0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsErrShouldReturnFalseIfErrorCodeIsNa | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsNaShouldReturnTrueCodeIsNa | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsNumberShouldReturnCorrectValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsTextShouldReturnTrueWhenReferencedCellContainsText | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | AndShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | FalseShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IfShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IIfShouldReturnCorrectResultWhenFalseConditionIsCoercedFromAString | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IIfShouldReturnCorrectResultWhenInnerFunctionExists | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IIfShouldReturnCorrectResultWhenTrueConditionIsCoercedFromAString | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | NotShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | OrShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | TrueShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AbsShouldHandleEmptyCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | Atan2ShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AtanShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AverageShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AverageShouldReturnDiv0IfEmptyCell | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AverateIfsShouldCaluclateResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CeilingShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CoshShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CosShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountAShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountBlankShouldCalculateEmptyCells | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountIfShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | DegreesShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | ExpShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | FactShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | FloorShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | IntShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | LnShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | Log10ShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | LogShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MaxaShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MaxShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MedianShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MinaShouldCalculateStringAs0 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MinShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | ModShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | PiShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | PowerShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | ProductShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | QuotientShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RandBetweenShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RandShouldReturnAResult | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RounddownShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RoundShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RoundupShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SinhShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SinShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SqrtPiShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SqrtShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | StdevPShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | StdevShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SubtotalShouldNegateExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SubtotalShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumShouldReturnCorrectResultWithDecimals | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumShouldReturnCorrectResultWithEnumerable | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumShouldReturnCorrectResultWithInts | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumsqShouldReturnCorrectResultWithEnumerable | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | TanhShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | TanShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | TruncShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | VarPShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | VarShouldReturnAResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Indirect_ShouldHandleStringAddress | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Indirect_ShouldHandleWorksheetAddress | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Match_ShouldHandleRangeArgument | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Match_ShouldHandleStringAddressArgument | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Offset_ShouldHandleNegativeOffsets | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Offset_ShouldReturnRangeValueForSum | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Offset_ShouldReturnSingleCellValue | ⚪ Missing | 🔴 Failed | Change (New Failed) |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | AddressShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ChooseShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ColumnSholdHandleReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ColumnShouldReturnRowNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ColumnsShouldReturnNbrOfCols | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | HLookupShouldReturnClosestValueBelowIfLastArgIsTrue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | HLookupShouldReturnCorrespondingValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | IndirectShouldReturnARange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | LookupShouldReturnMatchingValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetDirectReferenceToMultiRangeShouldSetValueError | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldCoverMultipleColumns | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnARange | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnARangeAccordingToHeight | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnARangeAccordingToWidth | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnASingleValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | RowSholdHandleReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | RowShouldReturnRowNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | RowsShouldReturnNbrOfRows | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | VLookupShouldHandleNames | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | VLookupShouldReturnClosestValueBelowIfLastArgIsTrue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | VLookupShouldReturnCorrespondingValue | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | ConcatenateShouldReturnAccordingToParams | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | LeftShouldReturnSubstringFromLeft | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | LenShouldAddLengthUsingSuppliedOperator | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | LowerShouldReturnALowerCaseString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | MidShouldReturnSubstringAccordingToParams | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | ReplaceShouldReturnSubstringAccordingToParams | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | ReptShouldConcatenate | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | RightShouldReturnSubstringFromRight | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | SubstituteShouldReturnSubstringAccordingToParams | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | TextShouldConcatenateWithNextExpression | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | TShouldReturnText | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | UpperShouldReturnAnUpperCaseString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Avg | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Count | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_CountA | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Max | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Min | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Product | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Stdev | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_StdevP | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Sum | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Var | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_VarP | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | CharShouldReturnCharValOfNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | ConcatenateShouldHandleRange | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldHandleNegativeDecimals | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldHaveCorrectDefaultValues | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldSetCorrectNumberOfDecimals | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldSetNoCommas | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | HyperlinkShouldHandleReference | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | HyperlinkShouldHandleReference2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | HyperlinkShouldHandleText | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | Logtest1 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.CalcExtensionsTests | CalculateTest | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.CalcExtensionsTests | CalculateTest2 | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.CalcExtensionsTests | ShouldCalculateChainTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | ArrayInclText | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | MultiCell | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | Name | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | NameOnOtherSheet | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | ReferenceError | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | SingleCell | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.OperatorsTests | DivByZeroShouldReturnError | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | Bugfixtest | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCalculateExpressionWithinParenthesisBeforeMultiply | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCalculateTwoGroupsUsingDivideAndMultiplyBeforeSubtract | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCaluclateUsingPrecedenceDivideBeforeAdd | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCaluclateUsingPrecedenceMultiplyBeforeAdd | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldConcatAfterAdd | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnFalseForSingleOperator | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnFalseIfCharIsNotPartOfMultipleCharOperator | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnFalseIfLastTokenIsNotOperator | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnTrueForGreaterThanOrEqualTo | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnTrueForLessThanOrEqualTo | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnTrueForNotEqualTo | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldChangePlusToMinusIfNegatorIsPresent | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnExcelAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnFirstTokenIfFirstCharIsMinus | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnTokenInEnumerable | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnTokenInsideFunctionCall | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnTokenInsideParenthethis | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeAbsoluteR1C1AddressAsNameValueInStable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeRelativeR1C1AddressAsExcelAddressInStable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeWorksheetR1C1AddressAsInvalidInStable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SheetnameHandlerTests | Handle_ShouldHandleEscapedSingleQuote | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SheetnameHandlerTests | Handle_ShouldToggleIsInSheetName | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SheetnameTests | Tokenize_ShouldHandleEscapedSingleQuoteInSheetName | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokenForPercentAfterDecimal | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForEnumerableCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForExcelAddressCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForFunctionCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForStringCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldHandleMultipleCharOperatorCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldHandleWhitespaceCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldIgnoreTwoSubsequentStringIdentifyers | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldIgnoreTwoSubsequentStringIdentifyers2 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldTokenizeStringCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TestBug9_12_14 | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesNegatorPositive | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesNegatorPositiveAsFirstFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesNegatorPositiveAsSecondFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesPositiveNegator | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesPositiveNegatorAsFirstFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesPositiveNegatorAsSecondFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizerShouldHandleWorksheetNameWithMinus | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizerShouldIgnoreOperatorInString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingDoubleNegator | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingDoubleNegatorFromFirstFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingDoubleNegatorFromSecondFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingPlusSign | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingPlusSignFromFirstFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingPlusSignFromSecondFunctionArgument | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldPassIfParenthesisAreWellformed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldPassIfStringIsWellformed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldThrowExceptionIfParenthesesAreNotWellformed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldThrowExceptionIfStringHasNotClosing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldThrowExceptionIfThereIsAnUnrecognizedToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateExcelAddressAsExcelAddressToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateExcelRangeAsExcelAddressToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateExcelRangeOnOtherSheetAsExcelAddressToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateNamedValueAsExcelAddressToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldReadFunctionsFromFuncRepository | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateAStringToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateBooleanAsBooleanToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateDecimalAsDecimalToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateDivideAsOperatorToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateEqualsAsOperatorToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateIntegerAsIntegerToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateMinusAsOperatorToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateMultiplyAsOperatorToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreatePlusAsOperatorToken | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenHandlerTests | HasMoreTokensShouldBeFalseWhenAllAreHandled | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenHandlerTests | HasMoreTokensShouldBeTrueWhenTokensExists | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenHandlerTestsInternal | CharIsTokenSeparator_ShouldReturnTrueForSingleQuote | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Logging.TextFileLoggerTests | ShouldOverwriteLogFileByInStable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Logging.TextFileLoggerTests | ShouldWriteToLogFile | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.ParsingContextTests | ConfigurationShouldBeSetByFactoryMethod | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingContextTests | ScopesShouldBeSetByFactoryMethod | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | CreatedScopeShouldBeCurrentScope | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | CurrentScopeShouldBeNullWhenScopeHasTerminated | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | CurrentScopeShouldHandleNestedScopes | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | LifetimeEventHandlerShouldBeCalled | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | NewScopeShouldSetParentOnCreatedScopeIfParentScopeExisted | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopeTests | ConstructorShouldSetAddress | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopeTests | ConstructorShouldSetParent | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopeTests | ScopeShouldCallKillScopeOnDispose | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNull_ShouldNotThrowIfValueIsSet | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNull_ShouldThrowIfValueIsNull | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNullOrEmpty_ShouldNotThrowIfValueIsSet | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNullOrEmpty_ShouldThrowIfValueIsEmpty | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNullOrEmpty_ShouldThrowIfValueIsNull | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnFalseForNull | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnFalseForString | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForDateTime | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForDecimal | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForDouble | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForFloat | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForInt | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForLong | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForShort | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForTimeSpan | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | BugCommentExceptionOnRemove | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | BugCommentNullAfterRemove | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Chart_From_Cell_Union_Selector_Bug_Test | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue13128 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue13492 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue14788 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue14966 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue14988 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15022 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15031 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15041 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15052 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15056 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15058 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15063 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15097 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15109 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15112 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15113 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15118 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15120 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15123 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15128 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15141 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15145 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15146 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15150 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15154 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15158 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15159 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15167 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15168 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15169 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15172 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15173_1 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15173_2 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15174 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15179 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15188 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15194 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15195 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15198 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15200 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15212 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15213 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15234 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15249 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15252 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15282 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15295 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15300 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15374 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15377 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15378 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15380 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15382 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15397 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15429 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15436 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15438 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15455 | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Issues | Issue15460WithNonStringPrimitive | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15460WithNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15460WithString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15469 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15485 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15548_SumIfsShouldHandleBadData | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15548_SumIfsShouldHandleGaps | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15551 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15564 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15566 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | IssueMergedCells | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issuer14801 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issuer15217 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15228 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15445 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issuer15558 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15560 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15563 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issues14699 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | IssueTranslate | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | LoadFromColIssue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | MergeIssue | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | PictureIssue | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldThrowInvalidCastExceptionIf | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldUseAclassProperties | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldUseAnonymousProperties | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldUseBaseClassProperties | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateBasic | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateClose | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateFlush | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateLeaveOpen | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.SharedTest | GetFileLength_NonExistentFile_ThrowsFileNotFoundException | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.SharedTest | ReadWithRetry_ReadsSuccessfully | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.SharedTest | StringToByteArray_And_StringFromBuffer_Encoding | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryExtractTest | ZipEntry_Extract_IsNotSupportedOnMono | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_Constructor_SetsExpectedDefaults | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_DontEmitLastModified_RoundTrips | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_ReadEntry_ParsesExtendedTimestampExtraField | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_ReadEntry_WithFalsePositiveDescriptorSignature_AccumulatesTrailerLength | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_TypeAttributes_ArePresent | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_WriteCentralDirectoryEntry_WritesCommentBytes | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_WriteCentralDirectoryEntry_WritesSegmentedDiskNumber | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipFileTest | ZipFile_AddEntry_DuplicateCase_AllowedInStable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipFileTest | ZipFile_AddEntry_UsesDefaultEncoding | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_99SegmentLimit | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_ForUpdate_UpdatesSpecificSegment | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_Properties_And_SimpleMethods | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_Read_SpansMultipleSegments | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_TruncateBackward_RemovesInterveningSegments | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_WriteAndRead_SpansSegments | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZlibCodecTest | ZlibCodec_CompressDecompress_Succeeds | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZlibCodecTest | ZlibCodec_Initialize_PropertiesSet | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZlibCodecTest | ZlibCodec_VariousInitializers_Succeed | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.ZipPackageTest | AddPartTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.ZipPackageTest | CreateZipPackageTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.ZipPackageTest | DeletePartTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.ZipPackageTest | RelationshipTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.ZipPackageTest | SaveAndLoadTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ReadTemplate | CondFormatDataValBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | CopyIssue | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | FileStreamSave | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15014 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15030 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15038 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15039 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15043 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | InternalZip | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBlankStream | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug10 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug11 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug12 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug13 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug14 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug15 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug2 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug3 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug4 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug5 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug6 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug7 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug8 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug9 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadConditionalFormatting | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadNameError | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadStyleBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadURL | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | SaveCorruption | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | StreamTest | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | test | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | TestInvalidVBA | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ThreadingTest | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | VBAerror | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ReadTemplate | whitespace | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.StringComparisonTests | TableLookup_ShouldBeCaseInsensitive | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.StringComparisonTests | WorksheetLookup_ShouldBeCaseInsensitive | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameEscapingTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameValidationTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameWithInvalidStartCharShouldFail | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameWithSpacesShouldFail | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.PivotTableTest | PivotTableDefaultNameTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.PivotTableTest | PivotTableSourceRangeCasingTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Table.PivotTableTest | PivotTableSourceRangeTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.AddressUtilityTests | ParseForEntireColumnSelections_ShouldAddMaxRows | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.AddressUtilityTests | ParseForEntireColumnSelections_ShouldAddMaxRowsOnColumnsWithMultipleLetters | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.AddressUtilityTests | ParseForEntireColumnSelections_ShouldHandleMultipleRanges | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_BasicTypes | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_DateTime | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_Nullable | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_TimeSpan | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | InvariantCompareInfoTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | IsNumericTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | TryParseDateString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | TryParseNumericString | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsInRange_ShouldNotThrowIfArgumentIsInRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsInRange_ShouldThrowIfArgumentIsOutOfRange | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNull_ShouldNotThrowIfArgumentIsAnInstance | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNull_ShouldThrowIfArgumentIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNullOrEmpty_ShouldNotThrowIfStringIsNotNullOrEmpty | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNullOrEmpty_ShouldThrowIfStringIsNull | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_FromSqRefAddress_ShouldReplaceSpaceWithComma | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldRemoveCommas | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldRemoveCommasAndInsertSpaceIfNecesary | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldRemoveMultipleSpaces | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldThrowIfAddressIsNullOrEmpty | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | GetRelativeUri_ParentDirectory_ReturnsRelative | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | GetRelativeUri_SourceIsDirectory_ReturnsRelative | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | GetRelativeUri_Standard_ReturnsRelative | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_CurrentDirectory_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_ExternalUri_DivergenceTest | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_ParentDirectory_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_RelativePath_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_RootPath_ReturnsTarget | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_SourceIsDirectory_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBA | Compression | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | CreateUnicodeWsName | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | DecompressionChunkGreaterThan4k | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | ReadVBA | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | ReadVBAUnicodeWsName | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | Resign | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | VbaBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | VbaError | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | WriteLongVBAModule | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | WriteVBA | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBACollectionTest | VBACollection_Exists_ReturnsTrue | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBACollectionTest | VBACollection_Indexer_IsCaseInsensitive | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBACollectionTest | VBACollection_Indexer_ReturnsModule | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBACollectionTest | VBACollection_ReferenceIndexer_ReturnsReference | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBACompressionTest | VBA_CompressionDecompression_LargeBuffer | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBACompressionTest | VBA_CompressionDecompression_Parity | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBASignatureTest | VBASignature_MD5_IsUsed | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.VBASignatureTest | VBASignature_SignAndVerify_Success | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorksheetsTests | ConfirmFileStructure | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteByNameWhereWorkSheetDoesNotExist | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteByNameWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteColumnAfterNormalRangeSheetShouldRemainUnchanged | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteColumnAfterRangeLimitThrowsArgumentException | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteColumnBeforeRangeMimitThrowsArgumentException | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteFirstColumnInRangeColumnShouldBeDeleted | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteFirstTwoColumnsFromRangeColumnsShouldBeDeleted | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteLastColumnInRangeColumnShouldBeDeleted | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | MoveAfterByNameWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | MoveAfterByPositionWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | MoveBeforeByNameWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | MoveBeforeByPositionWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | RangeClearMethodShouldNotClearSurroundingCells | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | ShouldBeAbleToDeleteAndThenAdd | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | TestTableCalculatedColumnFormulaTranslation | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorksheetsTests | TestVmlCommentsPartCleanup | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorkSheetTest | BuildInStyles | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | CloseProblem | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ColumnsTest | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Comment | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CommentShiftsWithColumnInserts | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CommentShiftsWithRowInserts | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesAbsoluteCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesColumnAbsoluteCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesRelativeCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesRowAbsoluteCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyColumnSetsOutlineLevelsCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyPivotTable | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | CopyRowCrossSheetSetsOutlineLevelsCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyRowSetsOutlineLevelsCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopySheetWithSharedFormula | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CreatePivotMultData | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertColumnAfterReferencesHasNoEffect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertColumnsUpdatesReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertRowAfterReferencesHasNoEffect | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertRowsUpdatesReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetReferenceIsUpdatedWhenSheetIsRenamed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | DateFunctionsWorkWithDifferentCultureDateFormats | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.WorkSheetTest | DefColWidthBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | DelCol | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Deletews | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ExcelWorksheetRenameWithEndApostropheThrowsException | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | ExcelWorksheetRenameWithStartApostropheThrowsException | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | FileLockedProblem | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | FormulaArray | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | InsCol | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | InsertColumnsSetsOutlineLevel | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | InsertRowsSetsOutlineLevel | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | InsertRowsUpdatesReferencesCorrectly | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Issue15207 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | LoadEmptyDataTable | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | LoadFromOneCollectionTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | LoadText_Bug15015 | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | LoadText_Bug15015_Negative | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Mergebug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Moveissue | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Nametest | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | OpenProblem | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | OpenXlsm | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | PivotTableTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | ProtectionProblem | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadBug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadPivotTable | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadStreamWithTemplateWorkSheet | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | RowStyle | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | RunSample0 | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | RunWorksheetTests | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | SaveToStream | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | SetBackground | 🟢 Passed | 🔴 Failed | ⚠️ **Regression (Passed -> Failed)** |
| EPPlusTest.WorkSheetTest | SetHeaderFooterImage | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Sort | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Stylebug | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | TableDeleteTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TableTotalsRowFunctionEscapesSpecialCharactersInColumnName | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TableWithSubtotalsParensInColumnName | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904SetAndRemoveSetting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904SetAndSetSetting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904WithoutSetting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904WithSetting | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDelete | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | TestRepeatRowsAndColumnsTest | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanNotContainWhiteSpaces | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanNotStartsWithNumber | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanStartsWithBackSlash | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanStartsWithUnderscore | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | URL | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ValueText | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.XmlHelperTest | XmlHelper_CreateNode_CreatesNewNode | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.XmlHelperTest | XmlHelper_CreateNode_DoesNotDuplicateExistingNode | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.XmlHelperTest | XmlHelper_GetXmlNodeInt_ParsesCorrectly | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
