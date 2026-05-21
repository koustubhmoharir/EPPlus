# EPPlus Three-Way Test Comparison Report

This report compares test results across three branches: **stable-released** (older Framework), **stable-net472** (.NET Framework 4.7.2 baseline), and **dotnetport** (.NET 9 port).

## Branch Test Summary Counts

| Branch | Passed | Failed | Skipped | Total Tests |
| :--- | :---: | :---: | :---: | :---: |
| **stable-released** | 899 | 187 | 166 | 1,252 |
| **stable-net472** | 1,144 | 209 | 170 | 1,523 |
| **dotnetport (.NET 9)** | 1,408 | 7 | 211 | 1,626 |

## Porting Transition Stats (stable-net472 ➡️ dotnetport .NET 9)

| Transition Category | Metric | Count |
| :--- | :--- | :---: |
| **Overall** | **Total Unique Test Cases** | **1645** |
| **Consistency** | Unchanged (Passed -> Passed) | 1123 |
| | Unchanged (Failed -> Failed) | 3 |
| | Unchanged (Skipped -> Skipped) | 169 |
| **Regressions** | **Regressions (Passed -> Failed)** | <span style="color:red">**4**</span> |
| | Regressions (Passed -> Skipped) | 2 |
| | Regressions (Passed -> Missing) | 15 |
| **Improvements** | **Improvements (Failed -> Passed)** | <span style="color:green">**201**</span> |
| | Improvements (Skipped -> Passed) | 0 |
| | Improvements (New Passed in .NET 9) | 84 |
| **New Tests** | New Failed in .NET 9 | 0 |
| | New Skipped in .NET 9 | 38 |
| **Removals** | Old Failed Missing in .NET 9 | 3 |
| | Old Skipped Missing in .NET 9 | 1 |
| **Other transitions** | Failed -> Skipped | 2 |
| | Skipped -> Failed | 0 |

## Detailed Three-Way Comparison Table

| Class | Test Name | stable-released | stable-net472 | dotnetport (.NET 9) | Transition (net472 ➡️ .NET 9) |
| :--- | :--- | :---: | :---: | :---: | :--- |
| EPPlusTest.Address | Addresses | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | InsertDeleteTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | IsValidAddress | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Address | IsValidCellAdress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | IsValidName | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Address | NamedRangeDoesNotChangeIfRowInsertedBelow | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeExpandsDownIfRowInsertedWithin | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeExpandsToRightIfColInsertedWithin | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeIsUnchangedForOutOfScopeSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeMovesDownIfRowInsertedAbove | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeMovesRightIfColInsertedBefore | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeUnchangedIfColInsertedAfter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeWithWorkbookScopeIsMovedDownIfRowInsertedAbove | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | NamedRangeWithWorkbookScopeIsMovedRightIfColInsertedBefore | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | ShouldHandleWorksheetSpec | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | SplitAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | TestComplexWorkbookAndSheetPrefix | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Address | TestDotNetPortSpecificAddressFeatures | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Address | TestEscapedSingleQuoteInSheetName | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Calculation | CalcTwiceError | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Calculation | CalculateDateMath | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Calculation | CalculateTest | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Calculation | CalculateTestIsFunctions | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Calculation | Calulation4 | 🔴 Failed | 🔴 Failed | 🟡 Skipped | Change (Failed -> Skipped) |
| EPPlusTest.Calculation | CalulationTestDatatypes | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Calculation | CalulationValidationExcel | 🔴 Failed | 🔴 Failed | 🟡 Skipped | Change (Failed -> Skipped) |
| EPPlusTest.Calculation | IfError | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Calculation | IfFunctionTest | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Calculation | INTFunctionTest | 🔴 Failed | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.Calculation | LeftRightFunctionTest | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Calculation | TestDataType | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Calculation | TestOneCell | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Calculation | TestPrecedence | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.CellStoreTest | CopyCellsTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | DeleteCells | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | DeleteCellsFirst | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | DeleteInsert | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | EnumCellstore | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | FillInsertTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | Insert1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | Insert2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | Insert3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CellStoreTest | InsertRandomTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ComHelperTest | TestComHelperMethods | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CommentsTest | ReadExcelComments | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.CommentsTest | ReadGoogleComments | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.CommentsTest | VisibilityComments | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.CompoundDoc | Issue131 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | Read | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | ReadEncLong | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | ReadPerfTest | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | ReadVba | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | ReadVbaIssue107 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | Sample7EncrLargeTest | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.CompoundDoc | WriteReadCompundDoc | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ConditionalFormatting | Databar | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | DatabarChangingAddressAddsConditionalFormatNodeInSchemaOrder | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | IconSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | IconSet_GreaterThanOrEqualTo_XmlTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | ReadConditionalFormatting | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ConditionalFormatting | ReadConditionalFormattingError | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoAndThreeColorConditionalFormattingFromFileDoesNotGetOverwrittenWithDefaultValues | 🔴 Failed | 🔴 Failed | ⚪ Missing | Change (Failed -> Missing) |
| EPPlusTest.ConditionalFormatting | TwoAndThreeColorScale_XmlTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoAndThreeColorScaleDefaultColors | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoBackColor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ConditionalFormatting | TwoColorScale | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32BasicCalculations | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32Combine | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32ComputeCrc32 | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32GetCrc32AndCopy | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32NullInputs | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32ReverseBits | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrc32UpdateCrc | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamConstructors | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamLengthLimit | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamPropertiesAndUnsupportedMethods | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Crc32Test | TestCrcCalculatorStreamReadWrite | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.CustomValidationTests | CustomValidation_FormulaIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.CustomValidationTests | CustomValidation_ShouldThrowExceptionIfFormulaIsTooLong | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldAcceptOneItemOnly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetErrorFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetErrorTitleFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetOperatorFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetPromptFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetPromptTitleFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetShowErrorMessageFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldSetShowInputMessageFromExistingXml | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldThrowIfOperatorIsBetweenAndFormula2IsEmpty | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | DataValidations_ShouldThrowIfOperatorIsEqualAndFormula1IsEmpty | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | ExcelDataValidation_ShouldReplaceLastPartInWholeColumnRangeWithMaxNumberOfRowsDifferentColumns | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DataValidationTests | ExcelDataValidation_ShouldReplaceLastPartInWholeColumnRangeWithMaxNumberOfRowsOneColumn | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DecimaDataValidationTests | DecimalDataValidation_Formula1IsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.DecimaDataValidationTests | DecimalDataValidation_Formula2IsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldSetHour | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldSetMinute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldSetSecond | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldThrowIfValueIsEqualToOrGreaterThan1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ConstructorWithValue_ShouldThrowIfValueIsLessThan0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Hour_ShouldThrowIfNegativeValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Minute_ShouldThrowIfNegativeValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Minute_ShouldThrowIValueIsGreaterThan59 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Second_ShouldThrowIfNegativeValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_Second_ShouldThrowIValueIsGreaterThan59 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ToExcelTime_HourIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ToExcelTime_MinuteIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ExcelTimeTests | ExcelTimeTests_ToExcelTime_SecondIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.CustomFormulaTests | CustomFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DateTimeFormulaTests | DateTimeFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DateTimeFormulaTests | DateTimeFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DecimalFormulaTests | DecimalFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.DecimalFormulaTests | DecimalFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_Constructor_ShouldHandleEmptyOrNullValue | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_FormulasFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_SetValue_ShouldUpdateXmlValue | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.IntegerFormulaTests | IntegerFormula_SetValueNull_ShouldUpdateXmlValueToEmpty | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.ListFormulaTests | ListFormula_FormulasExcelFormulaIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.ListFormulaTests | ListFormula_FormulaValueIsSetFromXmlNodeInConstructor | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.ListFormulaTests | ListFormula_FormulaValueIsSetFromXmlNodeInConstructorOrderIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.TimeFormulaTests | TimeFormula_ValueIsSetFromConstructorValidateHour | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.TimeFormulaTests | TimeFormula_ValueIsSetFromConstructorValidateMinute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.Formulas.TimeFormulaTests | TimeFormula_ValueIsSetFromConstructorValidateSecond | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeDecimal | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeListOfTypeList | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeListOfTypeTime | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_AddOneValidationOfTypeWhole | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | DataValidations_ReadExistingWorkbookWithDataValidations | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.IntegrationTests.IntegrationTests | RemoveDataValidation | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DataValidation.ListDataValidationTests | ListDataValidation_FormulaIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ListDataValidationTests | ListDataValidation_ShouldThrowWhenNoFormulaOrValueIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ListDataValidationTests | ListDataValidation_WhenOneItemIsAddedCountIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDateTimeValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDateTimeValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDecimalValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddDecimalValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddIntegerValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddIntegerValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddListValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddListValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddTextLengthValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddTextLengthValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AddTimeValidation_AddressIsCorrect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.RangeBaseTests | RangeBase_AdTimeValidation_ValidationIsAdded | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddDateTime_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddDecimal_ShouldThrowWhenAddressIsNullOrEmpty | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddDecimal_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddInteger_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_AddTextLength_ShouldThrowWhenNewValidationCollidesWithExisting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_Clear_ShouldBeEmpty | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_Find_ShouldReturnFirstMatchOnly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_FindAll_ShouldReturnValidationInColumnAonly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_Index_ShouldReturnItemAtIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DataValidation.ValidationCollectionTests | ExcelDataValidationCollection_RemoveAll_ShouldRemoveMatchingEntries | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DotNetZip.ZipDirEntryTest | ZipDirEntry_DuplicateFilesHandling_Ignore | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.DotNetZip.ZipDirEntryTest | ZipDirEntry_DuplicateFilesHandling_Rename | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | CrossesAt_SetTo1EMinus6_Is1EMinus6 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | CrossesAt_SetTo2_Is2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_GetMajor_IsNotNullAndCreatesNode | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_GetMinor_IsNotNullAndCreatesNode | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_RemoveGridlinesDefault_RemovesBoth | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | Gridlines_RemoveGridlinesSelective_RemovesExpected | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MaxValue_SetTo1EMinus6_Is1EMinus6 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MaxValue_SetTo2_Is2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MinValue_SetTo1EMinus6_Is1EMinus6 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartAxisTest | MinValue_SetTo2_Is2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartDataTableTest | DataTableFile | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_ChartSheetMultipleCharts_ThrowsInvalidOperationException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_DuplicateName_ThrowsException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_DuplicateNameDifferentCase_ThrowsException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_ExistingDrawingPartConflict_ResolvesConflictOnCore | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_UnsupportedStockChartType_ThrowsNotImplementedException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | AddChart_WithPivotTableSource_CreatesPivotChart | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | RoundedCorners_Default_IsFalse | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | RoundedCorners_SetToTrue_IsTrue | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | SaveAndLoad_ChartWithRoundedCornersAndStyle_PersistsCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.Chart.ExcelChartTest | Style_SetAndGet_WorksCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Drawing.ExcelPictureTest | ExcelPicture_AddPicture_SetsPropertiesCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DrawingTest | AllDrawingsInsideMarkupCompatibility | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ChartWorksheet | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | DrawingWidthAdjust | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DrawingTest | DrawingWorksheetCopy | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ReadChartWorksheet | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ReadMultiChartSeries | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | ReadWriteSmoothChart | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DrawingTest | RunDrawingTests | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.DrawingTest | TestHeaderaddress | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.DTS_FailingTests | CopyAndDeleteWorksheetWithImage | 🟢 Passed | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.DTS_FailingTests | DeleteWorksheetWithReferencedImage | 🟢 Passed | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | DecrypTest | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | DecrypTestBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | EncrypTest | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | ReadWriteEncrypt | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | WriteEncrypt | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Encrypt | WriteProtect | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.EncryptedPackageHandlerTest | TestAgileEncryptionDecryption | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.EncryptedPackageHandlerTest | TestStandardEncryptionDecryption | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfo_UnsupportedRC4 | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfo_UnsupportedVersion | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoAgile_PropertyMutations | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoAgile_ReadWrite_ByteArray | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoAgile_ReadWrite_FileStream | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoBinary_ReadWrite_ByteArray | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.EncryptionInfoTest | TestEncryptionInfoBinary_ReadWrite_FileStream | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.Excel.Functions.ArgumentParserFactoryTests | ShouldReturnBoolArgumentParserWhenDataTypeIsBoolean | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParserFactoryTests | ShouldReturnDoubleArgumentParserWhenDataTypeIsDecial | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParserFactoryTests | ShouldReturnIntArgumentParserWhenDataTypeIsInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvert0ToFalse | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvert1ToTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvertNullToFalse | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | BoolParserShouldConvertStringValueTrueToBoolValueTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserConvertDateStringToDouble | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserConvertStringToDoubleWithDotSeparator | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserShouldConvertDoubleToDouble | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserShouldConvertIntToDouble | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | DoubleParserShouldThrowIfArgumentIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldConvertADoubleToAnInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldConvertAStringValueToAnInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldConvertToAnInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersImplementationsTests | IntParserShouldThrowIfArgumentIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ArgumentParsersTests | ShouldReturnSameInstanceOfIntParserWhenCalledTwice | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DateFunctionShouldMonthFromPrevYearIfMonthIsNegative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DateFunctionShouldReturnACorrectDate | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DateFunctionShouldReturnADate | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldHandleFebWithEuroMethodSpecified | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldHandleFebWithUsMethodSpecified | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldHandleFebWithUsMethodSpecified2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldReturnCorrectResultWithEuroMethodSpecified | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | Days360ShouldReturnCorrectResultWithNoMethodSpecified2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DayShouldReturnDayInMonth | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | DayShouldReturnMonthOfYearWithStringParam | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | EdateShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | EomonthShouldReturnCorrectResultWithNegativeArg | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | EomonthShouldReturnCorrectResultWithPositiveArg | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | HourShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | HourShouldReturnCorrectResultWithStringArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | IsoWeekShouldReturn1When1StJan | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MinuteShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MinuteShouldReturnCorrectResultWithStringArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MonthShouldReturnMonthOfYear | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | MonthShouldReturnMonthOfYearWithStringParam | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdayIntlShouldReduceHoliday | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdayIntlShouldUseWeekendArg | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdayIntlShouldUseWeekendStringArg | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdaysNegativeShouldReturnNumberOfDays | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdaysShouldReturnNumberOfDays | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NetworkdaysShouldReturnNumberOfDaysWithHolidayRange | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | NowFunctionShouldReturnNow | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | SecondShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | SecondShouldReturnCorrectResultWithStringArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeAddition | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldParseStringCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldReturnACorrectSerialNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldThrowExceptionIfHourIsOutOfRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldThrowExceptionIfMinuteIsOutOfRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TimeShouldThrowExceptionIfSecondsIsOutOfRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | TodayFunctionShouldReturnTodaysDate | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekdayShouldReturnCorrectResultForASundayWhenReturnTypeIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekdayShouldReturnCorrectResultForASundayWhenReturnTypeIs2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekdayShouldReturnCorrectResultForASundayWhenReturnTypeIs3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WeekNumShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayShouldReturnCorrectResultIfNoHolidayIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayShouldReturnCorrectResultWithFourDaysSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayShouldReturnCorrectResultWithNegativeArg | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayWithNegativeArgShouldReturnCorrectWhenArrayOfHolidayDatesIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | WorkdayWithNegativeArgShouldReturnCorrectWhenRangeWithHolidayDatesIsSupplied | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearFracActualActual | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearFracShouldReturnCorrectResultWithEuroBasis | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearFracShouldReturnCorrectResultWithUsBasis | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearShouldReturnCorrectYear | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.DateTimeFunctionsTests | YearShouldReturnCorrectYearWithStringParam | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | Equals_ShouldReturnFalse_ForDifferentValues | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | Equals_ShouldReturnTrue_ForSameValueDifferentRow | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | GetHashCode_ShouldReturnSameValue_ForEqualObjects | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelDoubleCellValueTests | GetHashCode_ShouldReturnSameValue_ForEqualObjectsWithRow | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | ArgToAddress_ShouldReturnAddressForRange | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | ArgToAddress_ShouldReturnFullAddressForRange | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | ArgToAddress_ShouldReturnStringForNonRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | IsNumeric_ShouldReturnFalseForNonNumericTypes | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelFunctionDivergenceTests | IsNumeric_ShouldReturnTrueForNumericTypes | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.ExcelFunctionTests | ArgsToDoubleEnumerableShouldHandleInnerEnumerables | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.FunctionArgumentTests | ExcelStateFlagIsSetShouldReturnFalseWhenNotSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.FunctionArgumentTests | ShouldSetExcelState | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsBlankShouldReturnTrueIfFirstArgIsEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsBlankShouldReturnTrueIfFirstArgIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsErrorShouldReturnFalseIfArgIsNotAnError | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsErrorShouldReturnTrueIfArgIsAnErrorCode | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsEvenShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsLogicalShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNonTextShouldReturnFalseWhenFirstArgIsAString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNonTextShouldReturnTrueWhenFirstArgIsNotAString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNumberShouldReturnfalseWhenArgIsNonNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsNumberShouldReturnTrueWhenArgIsNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsOddShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsTextShouldReturnFalseWhenFirstArgIsNotAString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | IsTextShouldReturnTrueWhenFirstArgIsAString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.InformationFunctionsTests | NshouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldHandleStringLiteralTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnFalseIfOneArgumentIs0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnFalseIfOneArgumentIsFalse | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnTrueIfAllArgumentsAreTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | AndShouldReturnTrueIfAllArgumentsAreTrueOr1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfErrorShouldReturnResultOfFormulaIfNoError | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfErrorShouldReturnSecondArgIfCriteriaEvaluatesAsAnError | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfErrorShouldReturnSecondArgIfCriteriaEvaluatesAsAnError2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfNaShouldReturnResultOfFormulaIfNoError | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfNaShouldReturnSecondArgIfCriteriaEvaluatesAsAnError2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfShouldIgnoreCase | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | IfShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldHandleExcelReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldHandleExcelReferenceToStringFalse | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldHandleExcelReferenceToStringTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldReturnFalseIfArgumentIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldReturnFalseIfArgumentIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | NotShouldReturnTrueIfArgumentIs0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | OrShouldReturnTrueIfOneArgumentIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.LogicalFunctionsTests | OrShouldReturnTrueIfOneArgumentIsTrueString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AbsShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ACosHShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AcosShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AsinhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AsinShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | Atan2ShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AtanhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AtanShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldCountNumericStringWithValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldCountValueAs0IfNonNumericTextIsSuppliedInArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldIncludeTrueAs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageAShouldThrowValueExceptionIfNonNumericTextIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldCalculateCorrectResultWithEnumerableAndBoolMembers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldIgnoreHiddenFieldsIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | AverageShouldThrowDivByZeroExcelErrorValueIfEmptyArgs | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingBugTest1 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingBugTest2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldReturnNumberIfSignificanceIsMultipleOfNumber | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundTowardsZeroIfSignificanceAndNumberIsMinus0point1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundTowardsZeroIfSignificanceAndNumberIsNegative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundUpAccordingToParamsSignificanceIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundUpAccordingToParamsSignificanceIs10 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldRoundUpAccordingToParamsSignificanceLowerThan0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CeilingShouldThrowExceptionIfNumberIsPositiveAndSignificanceIsNegative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CosHShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CosShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountAShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountAShouldIncludeEnumerableMembers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountAShouldReturnNumberOfNonWhitespaceItems | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountIfShouldHandleNegativeCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldIncludeEnumerableMembers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldIncludeNumericStringsAndDatesInArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | CountShouldReturnNumberOfNumericItems | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ExpShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FactShouldRoundDownAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FactShouldThrowWhenNegativeNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorBugTest1 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorBugTest2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnCorrectResultWhenSignificanceIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnCorrectResultWhenSignificanceIsBetween0And1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnCorrectResultWhenSignificanceIsMinus1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | FloorShouldReturnNumberIfSignificanceIsMultipleOfNumber | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LargeShouldReturnTheLargestNumberIf1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LargeShouldReturnTheSecondLargestNumberIf2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LargeShouldThrowIfIndexOutOfBounds | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LnShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | Log10ShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LogShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | LogShouldReturnCorrectResultWithBase | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxaShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxaShouldCalculateCorrectResultUsingBool | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxaShouldCalculateCorrectResultUsingString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MaxShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldCalculateCorrectlyWithEvenMembers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldCalculateCorrectlyWithOddMembers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldCalculateCorrectlyWithOneMember | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MedianShouldThrowIfNoArgs | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MinShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | MinShouldIgnoreHiddenValuesIfIgnoreHiddenValuesIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ModShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | PiShouldReturnPIConstant | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldHandleEnumerable | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldHandleFirstItemIsEnumerable | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldIgnoreHiddenValuesIfIgnoreHiddenIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | ProductShouldMultiplyArguments | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | QuotientShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | QuotientShouldThrowWhenDenomIs0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RandBetweenShouldReturnAnIntegerValueBetweenSuppliedValues | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RandBetweenShouldReturnAnIntegerValueBetweenSuppliedValuesWhenLowIsNegative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RandShouldReturnAValueBetween0and1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | Rank | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldHandleNegativeNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldHandleNegativeNumDigits | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldHandleZeroNumDigits | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldReturn0IfNegativeNumDigitsIsTooLarge | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RounddownShouldReturnCorrectResultWithPositiveNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundShouldReturnCorrectResultWhenNbrOfDecimalsIsNegative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundupShouldHandleNegativeNumDigits | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundupShouldHandleZeroNumDigits | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | RoundupShouldReturnCorrectResultWithPositiveNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SignShouldReturn1IfArgIsPositive | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SignShouldReturnMinus1IfArgIsNegative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SinhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SinShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SmallShouldReturnTheSecondSmallestNumberIf2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SmallShouldReturnTheSmallestNumberIf1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SmallShouldThrowIfIndexOutOfBounds | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SqrtPiShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevPShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevPShouldIgnoreHiddenValuesWhenIgnoreHiddenValuesIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevShouldCalculateCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | StdevShouldIgnoreHiddenValuesWhenIgnoreHiddenValuesIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumShouldCalculate2Plus3AndReturn5 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumShouldCalculateEnumerableOf2Plus5Plus3AndReturn10 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumShouldIgnoreHiddenValuesWhenIgnoreHiddenValuesIsSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumSqShouldCalculateArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumSqShouldIncludeTrueAsOne | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | SumSqShouldNoCountTrueTrueInArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | TanhShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | TanShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | TruncShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarPShouldIgnoreHiddenValuesIfIgnoreHiddenIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarPShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarShouldIgnoreHiddenValuesIfIgnoreHiddenIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.MathFunctionsTests | VarShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | CIntShouldConvertTextToInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | IntShouldConvertDecimalToInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | IntShouldConvertNegativeDecimalToInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.NumberFunctionsTests | IntShouldConvertStringToInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | CurrentValueShouldBeFirstCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | GetLookupValueShouldReturnCorrespondingValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | GetLookupValueShouldReturnCorrespondingValueWithOffset | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | HasNextShouldBeTrueIfNotLastCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | MoveNextShouldIncreaseIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | MoveNextShouldNavigateVertically | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookup.LookupNavigatorTests | MoveNextShouldReturnFalseIfLastCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldReturnAddressByIndexWithDefaultRefType | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldReturnAddressByIndexWithRelativeType | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldReturnAddressByWithSpecifiedWorksheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | AddressShouldThrowIfR1C1FormatIsSpecified | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ChooseShouldReturnItemByIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ColumnShouldReturnRowFromCurrentScopeIfNoAddressIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ColumnShouldReturnRowSuppliedAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | ColumnssShouldReturnNbrOfRowsSuppliedRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | HLookupShouldReturnErrorIfNoMatchingRecordIsFoundWhenRangeLookupIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | HLookupShouldReturnNaErrorIfNoMatchingRecordIsFoundWhenRangeLookupIsFalse | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | HLookupShouldReturnResultFromMatchingRow | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetColIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetRangeAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetRangeLookupToTrueAsDefaultValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetRangeLookupToTrueWhenTrueIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupArgumentsShouldSetSearchedValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingRowArrayHorizontal | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingRowArrayVertical | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingSecondArrayHorizontal | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | LookupShouldReturnResultFromMatchingSecondArrayHorizontalWithOffset | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldHandleAddressOnOtherSheet | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnFirstItemWhenExactMatch_MatchTypeClosestAbove | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValHorizontal_MatchTypeClosestAbove | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValHorizontal_MatchTypeClosestBelow | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValHorizontal_MatchTypeExact | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValVertical_MatchTypeExact | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowShouldReturnRowFromCurrentScopeIfNoAddressIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowShouldReturnRowSuppliedAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowsShouldReturnNbrOfRowsForEntireColumn | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | RowsShouldReturnNbrOfRowsSuppliedRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | VLookupShouldReturnClosestStringValueBelowWhenRangeLookupIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | VLookupShouldReturnClosestValueBelowWhenRangeLookupIsTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RefAndLookupTests | VLookupShouldReturnResultFromMatchingRow | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RoundTests | RoundNegativeMidwayLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundNegativeToTensDownLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundNegativeToTensUpLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundNegativeToTenthsDownLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundNegativeToTenthsUpLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveMidwayLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveToOnesDownLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveToOnesUpLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveToTensDownLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveToTensUpLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveToTenthsDownLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundPositiveToTenthsUpLiteral | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldHandleNegativeDigitsCorrectly | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldHandleNegativeNumbersCorrectly | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldReturnCorrectResultForPositiveDigits | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.RoundTests | RoundShouldUseAwayFromZeroRounding | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateAverageWhenCalcTypeIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateAverageWhenCalcTypeIs101 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountAWhenCalcTypeIs103 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountAWhenCalcTypeIs3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountWhenCalcTypeIs102 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateCountWhenCalcTypeIs2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMaxWhenCalcTypeIs104 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMaxWhenCalcTypeIs4 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMinWhenCalcTypeIs105 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateMinWhenCalcTypeIs5 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateProductWhenCalcTypeIs106 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateProductWhenCalcTypeIs6 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevPWhenCalcTypeIs108 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevPWhenCalcTypeIs8 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevWhenCalcTypeIs107 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateStdevWhenCalcTypeIs7 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateSumWhenCalcTypeIs109 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateSumWhenCalcTypeIs9 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarPWhenCalcTypeIs11 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarPWhenCalcTypeIs111 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarWhenCalcTypeIs10 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldCalculateVarWhenCalcTypeIs110 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.SubtotalTests | ShouldThrowIfInvalidFuncNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ConcatenateShouldConcatenateStringWithInt | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ConcatenateShouldConcatenateThreeStrings | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | CStrShouldConvertNumberToString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnFalseWhenStringAndNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnFalseWhenTwoEqualStringsWithDifferentCase | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnTrueWhenEqualStringAndDouble | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ExactShouldReturnTrueWhenTwoEqualStrings | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | FindShouldReturnIndexOfFoundPhrase | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | FindShouldReturnIndexOfFoundPhraseBasedOnStartIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | HyperLinkShouldReturnArgIfOneArgIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | HyperLinkShouldReturnLastArgIfTwoArgsAreSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | LeftShouldReturnSubstringFromLeft | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | LenShouldReturnStringsLength | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | LowerShouldReturnLowerCaseString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | MidShouldReturnSubstringAccordingToParams | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldHandleEmptyString | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldHandleNumbers | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldHandleOnlySymbols | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ProperShouldSetFirstLetterToUpperCase | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ReplaceShouldReturnAReplacedStringAccordingToParamsWhenStartIxIs1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ReplaceShouldReturnAReplacedStringAccordingToParamsWhenStartIxIs3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | RightShouldReturnSubstringFromRight | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | SubstituteShouldReturnAReplacedStringAccordingToParamsWhen | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | UpperShouldReturnUpperCaseString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleDate | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleEmptyString | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleNumericString | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandlePercent | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldHandleTime | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.Text.TextFunctionsTests | ValueShouldReturnErrorIfInvalid | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | CanParseShouldHandleValid12HourPatterns | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | CanParseShouldHandleValid24HourPatterns | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldIdentify12HourAMPatternAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldIdentify12HourPMPatternAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldIdentifyPatternAndReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldThrowExceptionIfMinuteIsOutOfRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.Functions.TimeStringParserTests | ParseShouldThrowExceptionIfSecondIsOutOfRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatoMultiplyShouldMultiplyNumericStringAndNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorConcatShouldConcatANumberAndAString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorConcatShouldConcatTwoStrings | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldDivideCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldDivideNumericStringAndNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldReturnDivideByZeroIfRightOperandIsZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorDivideShouldReturnValueErrorIfNonNumericOperand | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorEqShouldReturnFalsefSuppliedValuesDiffer | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorEqShouldReturnTruefSuppliedValuesAreEqual | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorExpShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorGreaterThanToShouldReturnTrueIfLeftIs11AndRightIs10 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorGreaterThanToShouldReturnTrueIfLeftIsSetAndRightIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorMinusShouldSubtractNumericStringAndNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorMinusShouldThrowExceptionIfNonNumericOperand | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorMultiplyShouldThrowExceptionIfNonNumericOperand | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorNotEqualToShouldReturnFalsefSuppliedValuesAreEqual | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorNotEqualToShouldReturnTruefSuppliedValuesDiffer | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorPlusShouldAddNumericStringAndNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorPlusShouldThrowExceptionIfNonNumericOperand | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorsActingOnDateStrings | 🔴 Failed | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Excel.OperatorsTests | OperatorsActingOnNumericStrings | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | IsValidAddress_Basic | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | IsValidAddress_MultiAddress | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | TranslateFromR1C1_Basic | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | TranslateFromR1C1_Ranges | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | TranslateFromR1C1_SheetQualified | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | TranslateToR1C1_Basic | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | TranslateToR1C1_Ranges | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | TranslateToR1C1_SheetQualified | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesFullyQualifiedCrossSheetReferenceArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesFullyQualifiedReferenceOnADifferentSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesFullyQualifiedReferenceOnTheSameSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesIgnoresIncorrectSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesOnTheSameSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaReferencesReferencingADifferentSheetIsNotUpdated | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferences | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesEmptyNewSheetThrowsException | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesEmptyOldSheetThrowsException | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesNullNewSheetThrowsException | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelCellBaseTest | UpdateFormulaSheetReferencesNullOldSheetThrowsException | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelColorTest | LookupColorTintRounding | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelColorTest | SetColorTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertDuplicatePictureThrows | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertMissingFileInfoThrows | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertPictureFileInfo | ⚪ Missing | 🟢 Passed | 🔴 Failed | ⚠️ **Regression (Passed -> Failed)** |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterInsertPictureImage | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterProperties | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelHeaderFooterTest | TestHeaderFooterTextFormatting | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelHeaderFooterTest | TestScaleWithDocumentPersistence | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionAddAndLookup | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionAddValueAndFormula | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionInsertRowsAndColumnsBounds | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionNameValidation | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.ExcelNamedRangeCollectionTest | TestNamedRangeCollectionRemoveAndClear | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageCompatibilitySettingsIsWorksheets1Based | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorDefault | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorFileInfo | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorFileInfoTemplate | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorStream | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageConstructorStreamTemplate | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageEncryptionSupport | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.ExcelPackageTest | TestExcelPackageSaveAsFileInfo | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelPackageTest | TestExcelPackageSaveAsStream | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangeCollectionOperations | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangeDuplicateName | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangePropertiesAndSetPassword | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelProtectedRangeTest | TestProtectedRangeSerialization | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | ClearAndDeleteTests | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | CopyCopiesCommentsFromMultiCellRanges | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | CopyCopiesCommentsFromSingleCellRanges | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | ExcelNamedRangeLocalSheetIdTests | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | GetDateTextFormattingTests | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | GetValueTypedConversions | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | LoadFromTextComprehensiveTests | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRangeBaseTest | SettingAddressHandlesMultiAddresses | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_AllTags_Test | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_BrTag_Test | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_HtmlDecode_Test | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.ExcelRichTextHtmlUtilityTest | RichTextHtml_NonBreakingSpace_Test | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelStylesDivergenceTest | AddNewStyleColumnContiguousRangeTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelStylesDivergenceTest | CreateNamedStyleFromOtherWorkbookTest | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.ExcelStyleTest | ApplyProtectionAndAlignmentTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelStyleTest | FontBaselineStyle | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelStyleTest | GetFontHeightEdgeCasesTest | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelStyleTest | GetFontHeightTest | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelStyleTest | QuotePrefixStyle | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ConstructorShouldThrowIfProviderIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateLetterAddressUsingMaxRowsFromProviderLower | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateLetterAddressUsingMaxRowsFromProviderUpper | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateLettersToColumnIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.AddressTranslatorTests | ShouldTranslateRowNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.CellReferenceProviderTests | ShouldReturnReferencedMultipleAddresses | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.CellReferenceProviderTests | ShouldReturnReferencedSingleAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | AddressOnSheetShouldBeSameAsAddressIfNoWorksheetIsSpecified | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ParseShouldSetAddressOnSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ParseShouldSetWorksheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ParseShouldThrowIfAddressIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ShouldIndicateMultipleCellsWhenAddressContainsAColon | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ShouldSetEndCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | ShouldSetStartCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ExcelAddressInfoTests | WorksheetIsSpecifiedShouldBeTrueWhenWorksheetIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldThrowIfExcelDataProviderIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate1And1ToA1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate27And1ToAA1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate53And1ToBA1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate702And1ToZZ1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslate703ToAAA4 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToAbsoluteAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToAbsoluteRowAndRelativeCol | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToEntireColumnWhenRowIsEqualToMaxRows | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToRelativeRowAndAbsoluteCol | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.IndexToAddressTranslatorTests | ShouldTranslateToRelativeRowAndCol | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldHandleTableAddress | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAndInstanceWithColPropertiesSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAndInstanceWithRowPropertiesSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToColSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToColSetWhenARangeAddressIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToRowSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithFromAndToRowSetWhenARangeAddressIsSupplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithStringAddressSet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnAnInstanceWithWorksheetSetToEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldReturnEntireColumnRangeWhenNoRowsAreSpecified | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldSetWorksheetNameIfSuppliedInAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressFactoryTests | CreateShouldThrowIfSuppliedAddressIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressTests | CollideShouldReturnFalseIfRangesCollidesButWorksheetNameDiffers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressTests | CollideShouldReturnFalseIfRangesDoesNotCollide | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.RangeAddressTests | CollideShouldReturnTrueIfRangesCollides | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenBothParamsAreEqual | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenBothParamsAreNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenParamsAreEqualButDifferentTypes | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn0WhenWhenParamsAreEqualStrings | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn1WhenFirstParamIsGreaterThanSecondParam | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturn1WhenFirstParamIsSomethingAndSecondParamIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturnMinus1WhenFirstParamIsLessThanSecondParam | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturnMinus1WhenFirstParamIsNullAndSecondParamIsSomething | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.ValueMatcherTests | ShouldReturnMînus2WhenTypesDifferAndStringConversionToDoubleFails | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.WildCardValueMatcherTests | IsMatchShouldReturn0WhenMultipleCharWildCardMatches | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelUtilities.WildCardValueMatcherTests | IsMatchShouldReturn0WhenSingleCharWildCardMatches | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorkbookTest | Workbook_PivotTableNames_CaseSensitive_On_Stable | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorkbookTest | Workbook_Properties_CalcMode | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorkbookTest | Workbook_Properties_Date1904 | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorkbookTest | Workbook_TableNames_CaseInsensitive_On_Stable | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorkbookTest | Workbook_Worksheets_Access_1Based | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.ExcelWorkbookTest | Workbook_Worksheets_Access_BasedOnCompatibility | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestExtendedPropertiesSyncBaseline | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestNextTableIdInitializationBaseline | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestVBAModuleCreationBaseline | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestWorksheetCopyingWithMergedCells | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestWorksheetCopyingWithPivotTable | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetsDivergenceTest | TestWorksheetIndexingBaseline | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetViewDivergenceTest | TestTabSelectedBaseline | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExcelWorksheetViewDivergenceTest | TestTabSelectedMulti | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.ExceptionsTest | TestBadCrcException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExceptionsTest | TestBadPasswordException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExceptionsTest | TestBadReadException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExceptionsTest | TestBadStateException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExceptionsTest | TestSfxGenerationException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExceptionsTest | TestZipException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateBlankExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateBlankExpressionEqualsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateBlankExpressionEqualsZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsDifferentCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsNumeral | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterExpressionEqualsSameCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsDifferentCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsNumeral | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateCharacterWithOperatorExpressionEqualsSameCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsNonZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToBlankExpressionEqualsZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsNonZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateNotEqualToZeroExpressionEqualsZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateQuotesExpressionEqualsCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateQuotesExpressionEqualsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateQuotesExpressionEqualsZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldEvaluateNumericString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldEvaluateOperator | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldHandleBooleanArg | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldHandleDateArg | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldHandleDateArgWithOperator | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldReturnTrueIfOperandsAreEqual | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldReturnTrueIfOperandsAreMatchingButDifferentTypes | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ExpressionEvaluatorTests | EvaluateShouldThrowIfOperatorIsNotBoolean | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FileSelectorTest | TestFileSelectorComplexCriteria | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FileSelectorTest | TestFileSelectorEvaluate | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FileSelectorTest | TestFileSelectorSimpleName | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FileSelectorTest | TestFileSelectorSizeSuffixes | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FinanceFunctionsTest | TestPmtFunction | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithNormalAddress_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableAddress_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableAll_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableData_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableHeaders_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableThisRow_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.EpplusExcelDataProviderTests | GetRange_WithTableTotals_ShouldReturnCorrectRange | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleMultipleRangesAndCriterias | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleNullRangeCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleNumericCriteria | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleNumericWildcardCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleRangeCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleStringCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.CountIfsTests | ShouldHandleSingleStringWildcardCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.CriteriaTests | CriteriaShouldIgnoreEmptyFields1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.CriteriaTests | CriteriaShouldIgnoreEmptyFields2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.CriteriaTests | CriteriaShouldReadFieldsAndValues | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | DatabaseShouldReadFields | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | DatabaseShouldReadFieldsInRow | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | HasMoreRowsShouldBeFalseWhenLastRowIsRead | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.ExcelDatabaseTests | HasMoreRowsShouldBeTrueWhenInitialized | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldHandleFieldIndex | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchNumericExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchStrings1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchStrings2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldMatchWildcardStrings | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldReturnFalseIfCriteriasDoesNotMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Database.RowMatcherTests | IsMatchShouldReturnTrueIfCriteriasMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.FinanceFunctionTests | PmtTest1 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.FunctionRepositoryTests | LoadModulePopulatesFunctionsAndCustomCompilers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageAArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageACellReferences | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageALiterals | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageATests | AverageAUnparsableLiteral | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfEqualToEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanOrEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfGreaterThanZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanOrEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfLessThanZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNonNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNotEqualToNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNotEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageIfTests | AverageIfNumericExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageCellReferences | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageLiterals | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.AverageTests | AverageUnparsableLiteral | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfEqualToEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanOrEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfGreaterThanZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanOrEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfLessThanZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNonNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNotEqualToNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNotEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.CountIfTests | CountIfNumericExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfEqualToEmptyString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanOrEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfGreaterThanZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfHandleDates | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanOrEqualToCharacter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanOrEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfLessThanZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNonNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNotEqualToNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNotEqualToZero | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNumeric | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfNumericExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.Math.SumIfTests | SumIfShouldHandleBooleanArg | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseMultipleValues | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseSingleFormula | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseSingleValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.ChooseTests | ChooseValueAndFormula | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.IndexTests | Index_Should_Handle_SingleRange | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.IndexTests | Index_Should_Return_Value_By_Index | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.LookupNavigatorFactoryTests | Should_Return_ArrayLookupNavigator_When_Array_Is_Supplied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.RefAndLookup.LookupNavigatorFactoryTests | Should_Return_ExcelLookupNavigator_When_Range_Is_Set | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.SumIfsTests | ShouldCalculateTwoCriteriaRanges | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.SumIfsTests | ShouldHandleExcelRangesInCriteria | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Excel.Functions.SumIfsTests | ShouldIgnoreErrorInCriteriaRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | GetValidName_ShouldFixFirstChar | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | GetValidName_ShouldReplaceInvalidChars | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | GetValidName_ShouldReturnOriginal_IfEmpty | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfContainsInvalidChars | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfFirstCharIsBackslashAndLengthIs2OrLess | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfFirstCharIsInvalid | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfIsAValidCellAddress | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnFalse_IfNameIsEmpty | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnTrue_IfFirstCharIsBackslashAndLengthGreaterThan2 | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnTrue_IfFirstCharIsLetterOrUnderscore | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExcelUtilities.ExcelAddressUtilTests | IsValidName_ShouldReturnTrue_IfIsValid | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.CompileResultFactoryTests | CalculateUsingEuropeanDates | 🔴 Failed | 🔴 Failed | ⚪ Missing | Change (Failed -> Missing) |
| EPPlusTest.FormulaParsing.ExpressionGraph.CompileResultTests | DateStringCompileResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.CompileResultTests | NumericStringCompileResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.EnumerableExpressionTests | CompileShouldReturnEnumerableOfCompiledChildExpressions | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceAbsolute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceColumnAbsolute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceRowAbsolute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileMultiCellReferenceWithValues | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRangeAbsolute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRangeColumnAbsolute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceResolveToRangeRowAbsolute | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | CompileSingleCellReferenceWithValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | ConstructorShouldThrowIfExcelDataProviderIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExcelAddressExpressionTests | ConstructorShouldThrowIfParsingContextIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionCompilerTests | CompileShouldCalculateMultipleExpressionsAccordingToPrecedence | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionCompilerTests | CompileShouldMultiplyGroupExpressionWithFollowingIntegerExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionCompilerTests | ShouldCompileTwoInterExpressionsToCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateBooleanExpressionIfCompileResultIsBoolean | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateBooleanExpressionIfCompileResultIsBooleanString | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDate | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDecimal | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDecimalString | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsTime | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateExcelErrorExpressionIfCompileResultIsExcelError | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateExcelErrorExpressionIfCompileResultIsExcelErrorString | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsEmpty | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsInteger | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsIntegerString | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | FromCompileResultShouldCreateStringExpressionIfCompileResultIsString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | InstanceShouldReturnAnInstance | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | ToStringExpressionShouldConvertDecimalExpressionToStringExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | ToStringExpressionShouldConvertIntegerExpressionToStringExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionConverterTests | ToStringExpressionShouldCopyOperatorToStringExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnBooleanExpressionWhenTokenIsBoolean | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnDecimalExpressionWhenTokenIsDecimal | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnExcelRangeExpressionWhenTokenIsExcelAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnIntegerExpressionWhenTokenIsInteger | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionFactoryTests | ShouldReturnNamedValueExpressionWhenTokenIsNamedValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildExcelAddressExpressionSimple | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldAddCommaSeparatedFunctionArgumentsAsChildrenToFunctionExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldAddOperatorToFunctionExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldBuildFunctionExpressionIfFirstTokenIsFunction | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldCreateASingleExpressionOutOfANegatorAndANumericToken | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldHandleEnumerableTokens | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldNotEvaluateExpressionsWithinAString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldNotUseStringIdentifyersWhenBuildingStringExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetChildrenOnFunctionExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetChildrenOnGroupExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetNextOnGroupedExpression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | BuildShouldSetOperatorOnGroupExpressionCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | RemoveDuplicateOperators1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | RemoveDuplicateOperators2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | ShouldHandleInnerFunctionCall2 | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.ExpressionGraphBuilderTests | ShouldHandleInnerFunctionCall3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesCustomFunctionCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesErrorFunctionCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesLookupFunctionCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesSpecialIfCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesSpecialIfErrorCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesSpecialIfNaCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.FunctionCompilers.FunctionCompilerFactoryTests | CreateHandlesStandardFunctionCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ExpressionGraph.IntegerExpressionTests | MergeWithNextWithPlusOperatorShouldCalulateSumCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.ExpressionGraph.IntegerExpressionTests | MergeWithNextWithPlusOperatorShouldSetNextPointer | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.FormulaParserManagerTests | FunctionsShouldBeCopied | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParseAtShouldCallExcelDataProvider | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParseAtShouldThrowIfAddressIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParserShouldCallCompiler | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParserShouldCallGraphBuilder | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaParserTests | ParserShouldCallLexer | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | C | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | C2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | C2Abs | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | C2AbsWithSheet | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | OutOfRangeCol | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | R2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | R2Abs | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | RC2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | RCFixToABToR1C1_2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | RCRelativeToAB | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | RCRelativeToABToR1C1 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | RCRelativeToABToR1C1_2 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | SimpleAbsR1C1 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.FormulaR1C1Tests | SimpleRelativeR1C1 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldAddIntegersCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldDivideDecimalWithIntegerCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldDivideIntegersCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleDecimalNumberWhenDividingIntegers | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleExpCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleExpWithDecimalCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandleMultiplePercentSigns | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandlePercentageOnFunctionResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldHandlePercentageOnParantethis | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldIgnoreLeadingPlus | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldMultiplyDecimalWithDecimalCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldMultiplyIntegersCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldNegateExpressionInParenthesis | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ShouldSubtractIntegersCorrectly | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | TenPercentShouldBe0Point1 | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeGreaterThanOrEqualToThreeShouldBeTrue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeGreaterThanTwoShouldBeTrue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeLessThanOrEqualToThreeShouldBeTrue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeLessThanOrEqualToTwoDotThreeShouldBeFalse | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | ThreeLessThanTwoShouldBeFalse | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | TwelveAndTwelveShouldBeEqual | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BasicCalcTests | TwoDotTwoGreaterThanOrEqualToThreeShouldBeFalse | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DAverageShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DcountaShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DcountShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DgetShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DMaxShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DMinShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DSumShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DVarpShouldReturnByFieldIndex | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DVarpShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DatabaseTests | DVarShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | Calculation5 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateNotEqualToStringShouldBeTrue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateShouldHandleCellReference | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTest1 | 🟢 Passed | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTestWithoutYear | 🟢 Passed | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTestWithTwoDigitYear | 🔴 Failed | 🔴 Failed | ⚪ Missing | Change (Failed -> Missing) |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DateValueTestWithTwoDigitYear2 | 🟢 Passed | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | Day360ShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | DayShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | EomonthShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | HourShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | HourShouldReturnCorrectResultWhenParsingString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | HourWithExcelReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | IsoWeekNumShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MinuteShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MinuteShouldReturnCorrectResultWhenParsingString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MinuteWithExcelReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | MonthShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | NowShouldReturnAResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | SecondShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | SecondShouldReturnCorrectResultWhenParsingString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | SecondWithExcelReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TimeShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TimeValueTestFullDate | 🟢 Passed | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TimeValueTestPm | 🟢 Passed | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | TodayShouldReturnAResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | WorkdayShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | YearfracShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.DateAndTimeFunctionsTests | YearShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AbsShouldReturn3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleLookupRangeStringMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleLookupRangeStringNumericMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleLookupRangeStringWildCardMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleSingleRangeNumericExpressionMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageIfShouldHandleSingleRangeStringMatch | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | AverageShouldReturn3Point333333 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountAShouldReturn3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountIfShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountShouldReturn2IfACellValueIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | CountShouldReturn3 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | MaxShouldReturn6 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | MinShouldReturn1 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | ShouldIgnoreNullValues | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SignShouldReturn1WhenRefIsPositive | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SubTotalShouldNotIncludeHiddenRow | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SumProductShouldWorkWithSingleCellArray | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SumProductWithRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.MathExcelRangeTests | SumProductWithRangeAndValues | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ExactShouldReturnTrueWhenEqualValues | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | FindShouldReturnIndexCaseSensitive | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | SearchShouldReturnIndexCaseInSensitive | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandle1000delimiter | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandle1000DelimiterAndDecimal | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleDate | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandlePercent | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleScientificNotation | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleStringWithIntegers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldHandleTime | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.TextExcelRangeTests | ValueShouldReturn0IfValueIsNull | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.WorksheetRefsTest | ShouldHandleInvalidRef | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.WorksheetRefsTest | ShouldHandleReferenceToOtherSheet | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.ExcelRanges.WorksheetRefsTest | ShouldHandleReferenceToOtherSheetWithComplexName | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | ErrorTypeShouldReturnCorrectErrorCodes | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsBlankShouldReturnCorrectValue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsErrorShouldReturnTrueWhenDivBy0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsErrShouldReturnFalseIfErrorCodeIsNa | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsNaShouldReturnTrueCodeIsNa | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsNumberShouldReturnCorrectValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.InformationFunctionsTests | IsTextShouldReturnTrueWhenReferencedCellContainsText | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | AndShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | FalseShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IfShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IIfShouldReturnCorrectResultWhenFalseConditionIsCoercedFromAString | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IIfShouldReturnCorrectResultWhenInnerFunctionExists | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | IIfShouldReturnCorrectResultWhenTrueConditionIsCoercedFromAString | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | NotShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | OrShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.LogicalFunctionsTests | TrueShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AbsShouldHandleEmptyCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | Atan2ShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AtanShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AverageShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AverageShouldReturnDiv0IfEmptyCell | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | AverateIfsShouldCaluclateResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CeilingShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CoshShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CosShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountAShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountBlankShouldCalculateEmptyCells | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountIfShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | CountShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | DegreesShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | ExpShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | FactShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | FloorShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | IntShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | LnShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | Log10ShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | LogShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MaxaShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MaxShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MedianShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MinaShouldCalculateStringAs0 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | MinShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | ModShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | PiShouldReturnCorrectResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | PowerShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | ProductShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | QuotientShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RandBetweenShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RandShouldReturnAResult | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RounddownShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RoundShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | RoundupShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SinhShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SinShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SqrtPiShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SqrtShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | StdevPShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | StdevShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SubtotalShouldNegateExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SubtotalShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumShouldReturnCorrectResultWithDecimals | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumShouldReturnCorrectResultWithEnumerable | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumShouldReturnCorrectResultWithInts | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | SumsqShouldReturnCorrectResultWithEnumerable | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | TanhShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | TanShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | TruncShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | VarPShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.MathFunctionsTests | VarShouldReturnAResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Indirect_ShouldHandleStringAddress | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Indirect_ShouldHandleWorksheetAddress | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Match_ShouldHandleRangeArgument | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Match_ShouldHandleStringAddressArgument | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Offset_ShouldHandleNegativeOffsets | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Offset_ShouldReturnRangeValueForSum | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupDivergenceTests | Offset_ShouldReturnSingleCellValue | ⚪ Missing | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | AddressShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ChooseShouldReturnCorrectResult | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ColumnSholdHandleReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ColumnShouldReturnRowNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | ColumnsShouldReturnNbrOfCols | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | HLookupShouldReturnClosestValueBelowIfLastArgIsTrue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | HLookupShouldReturnCorrespondingValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | IndirectShouldReturnARange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | LookupShouldReturnMatchingValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | MatchShouldReturnIndexOfMatchingValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetDirectReferenceToMultiRangeShouldSetValueError | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldCoverMultipleColumns | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnARange | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnARangeAccordingToHeight | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnARangeAccordingToWidth | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | OffsetShouldReturnASingleValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | RowSholdHandleReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | RowShouldReturnRowNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | RowsShouldReturnNbrOfRows | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | VLookupShouldHandleNames | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | VLookupShouldReturnClosestValueBelowIfLastArgIsTrue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.RefAndLookupTests | VLookupShouldReturnCorrespondingValue | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | ConcatenateShouldReturnAccordingToParams | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | LeftShouldReturnSubstringFromLeft | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | LenShouldAddLengthUsingSuppliedOperator | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | LowerShouldReturnALowerCaseString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | MidShouldReturnSubstringAccordingToParams | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | ReplaceShouldReturnSubstringAccordingToParams | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | ReptShouldConcatenate | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | RightShouldReturnSubstringFromRight | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | SubstituteShouldReturnSubstringAccordingToParams | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | TextShouldConcatenateWithNextExpression | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | TShouldReturnText | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.StringFunctionsTests | UpperShouldReturnAnUpperCaseString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Avg | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Count | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_CountA | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Max | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Min | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Product | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Stdev | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_StdevP | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Sum | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_Var | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.SubtotalTests | SubtotalShouldNotIncludeSubtotalChildren_VarP | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | CharShouldReturnCharValOfNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | ConcatenateShouldHandleRange | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldHandleNegativeDecimals | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldHaveCorrectDefaultValues | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldSetCorrectNumberOfDecimals | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | FixedShouldSetNoCommas | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | HyperlinkShouldHandleReference | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | HyperlinkShouldHandleReference2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | HyperlinkShouldHandleText | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions.TextFunctionsTests | Logtest1 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.CalcExtensionsTests | CalculateTest | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.CalcExtensionsTests | CalculateTest2 | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.CalcExtensionsTests | ShouldCalculateChainTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | ArrayInclText | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | MultiCell | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | Name | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | NameOnOtherSheet | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | ReferenceError | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.ErrorHandling.SumTests | SingleCell | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.FormulaParsing.IntegrationTests.OperatorsTests | DivByZeroShouldReturnError | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | Bugfixtest | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCalculateExpressionWithinParenthesisBeforeMultiply | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCalculateTwoGroupsUsingDivideAndMultiplyBeforeSubtract | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCaluclateUsingPrecedenceDivideBeforeAdd | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldCaluclateUsingPrecedenceMultiplyBeforeAdd | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.IntegrationTests.PrecedenceTests | ShouldConcatAfterAdd | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnFalseForSingleOperator | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnFalseIfCharIsNotPartOfMultipleCharOperator | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnFalseIfLastTokenIsNotOperator | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnTrueForGreaterThanOrEqualTo | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnTrueForLessThanOrEqualTo | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.MultipleCharSeparatorHandlerTests | Handle_ShouldReturnTrueForNotEqualTo | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldChangePlusToMinusIfNegatorIsPresent | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnExcelAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnFirstTokenIfFirstCharIsMinus | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnTokenInEnumerable | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnTokenInsideFunctionCall | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.NegationTests | ShouldSetNegatorOnTokenInsideParenthethis | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeAbsoluteR1C1AddressAsNameValueInStable | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeAbsoluteR1C1AddressAsNameValueWhenR1C1IsDisabled | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeAbsoluteR1C1AddressAsR1C1WhenEnabled | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeR1C1RangeAsR1C1WhenEnabled | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeRelativeR1C1AddressAsExcelAddressInStable | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeRelativeR1C1AddressAsR1C1WhenEnabled | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeWorksheetR1C1AddressAsInvalidInStable | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.R1C1Tests | ShouldTokenizeWorksheetR1C1AddressAsR1C1WhenEnabled | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SheetnameHandlerTests | Handle_ShouldHandleEscapedSingleQuote | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SheetnameHandlerTests | Handle_ShouldToggleIsInSheetName | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SheetnameTests | Tokenize_ShouldHandleEscapedSingleQuoteInSheetName | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokenForPercentAfterDecimal | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForEnumerableCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForExcelAddressCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForFunctionCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldCreateTokensForStringCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldHandleMultipleCharOperatorCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldHandleWhitespaceCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldIgnoreTwoSubsequentStringIdentifyers | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldIgnoreTwoSubsequentStringIdentifyers2 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | ShouldTokenizeStringCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TestBug9_12_14 | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesNegatorPositive | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesNegatorPositiveAsFirstFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesNegatorPositiveAsSecondFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesPositiveNegator | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesPositiveNegatorAsFirstFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeHandlesPositiveNegatorAsSecondFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizerShouldHandleWorksheetNameWithMinus | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizerShouldIgnoreOperatorInString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingDoubleNegator | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingDoubleNegatorFromFirstFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingDoubleNegatorFromSecondFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingPlusSign | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingPlusSignFromFirstFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SourceCodeTokenizerTests | TokenizeStripsLeadingPlusSignFromSecondFunctionArgument | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldPassIfParenthesisAreWellformed | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldPassIfStringIsWellformed | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldThrowExceptionIfParenthesesAreNotWellformed | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldThrowExceptionIfStringHasNotClosing | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.SyntacticAnalyzerTests | ShouldThrowExceptionIfThereIsAnUnrecognizedToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateExcelAddressAsExcelAddressToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateExcelRangeAsExcelAddressToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateExcelRangeOnOtherSheetAsExcelAddressToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldCreateNamedValueAsExcelAddressToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | CreateShouldReadFunctionsFromFuncRepository | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateAStringToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateBooleanAsBooleanToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateDecimalAsDecimalToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateDivideAsOperatorToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateEqualsAsOperatorToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateIntegerAsIntegerToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateMinusAsOperatorToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreateMultiplyAsOperatorToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenFactoryTests | ShouldCreatePlusAsOperatorToken | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenHandlerTests | HasMoreTokensShouldBeFalseWhenAllAreHandled | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenHandlerTests | HasMoreTokensShouldBeTrueWhenTokensExists | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.LexicalAnalysis.TokenHandlerTestsInternal | CharIsTokenSeparator_ShouldReturnTrueForSingleQuote | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Logging.TextFileLoggerTests | ShouldHandleExistingLogFile | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.FormulaParsing.Logging.TextFileLoggerTests | ShouldOverwriteLogFileByInStable | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.FormulaParsing.Logging.TextFileLoggerTests | ShouldWriteToLogFile | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingContextTests | ConfigurationShouldBeSetByFactoryMethod | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingContextTests | ScopesShouldBeSetByFactoryMethod | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | CreatedScopeShouldBeCurrentScope | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | CurrentScopeShouldBeNullWhenScopeHasTerminated | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | CurrentScopeShouldHandleNestedScopes | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | LifetimeEventHandlerShouldBeCalled | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopesTest | NewScopeShouldSetParentOnCreatedScopeIfParentScopeExisted | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopeTests | ConstructorShouldSetAddress | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopeTests | ConstructorShouldSetParent | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.ParsingScopeTests | ScopeShouldCallKillScopeOnDispose | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNull_ShouldNotThrowIfValueIsSet | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNull_ShouldThrowIfValueIsNull | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNullOrEmpty_ShouldNotThrowIfValueIsSet | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNullOrEmpty_ShouldThrowIfValueIsEmpty | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNotNullOrEmpty_ShouldThrowIfValueIsNull | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnFalseForNull | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnFalseForString | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForDateTime | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForDecimal | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForDouble | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForFloat | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForInt | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForLong | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForShort | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.FormulaParsing.Utilities.ExtensionMethodsTests | IsNumeric_ShouldReturnTrueForTimeSpan | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | BugCommentExceptionOnRemove | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | BugCommentNullAfterRemove | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Chart_From_Cell_Union_Selector_Bug_Test | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue_15585 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue_15641 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue_5 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue_8 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue10 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue100 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue107 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue127 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue13128 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue13492 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue14788 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue14966 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue14988 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15022 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15031 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15041 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15052 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15056 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15058 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15063 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15097 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15109 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15112 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15113 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15118 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15120 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15123 | 🟢 Passed | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.Issues | Issue15128 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15141 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15145 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15146 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15150 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15154 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15158 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15159 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15167 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15168 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15169 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15172 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15173_1 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15173_2 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15174 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15179 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15188 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15194 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15195 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15198 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15200 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15212 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15213 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15234 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15249 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15252 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15282 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15295 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | issue15300 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15374 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15377 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15378 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15380 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15382 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15397 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15429 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15436 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15438 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15455 | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.Issues | Issue15460WithNonStringPrimitive | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15460WithNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15460WithString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15469 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15485 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue155 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue15548_SumIfsShouldHandleBadData | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15548_SumIfsShouldHandleGaps | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issue15551 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15564 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue15566 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issue167 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue170 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue172 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue173 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue176 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue178 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue181 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue184_Disposing_External_Stream | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue195 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue204 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue219 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue220 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue228 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue233 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue234 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue236 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue241 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue32 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue44 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue51 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue55 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue57 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue58 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue60 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue61 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue63 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue66 | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Issues | Issue68 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue70 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue94 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issue99 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | IssueMergedCells | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issuer14801 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issuer15217 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15228 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15445 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | Issuer15558 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15560 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer15563 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | Issuer26 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issuer27 | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.Issues | Issues14699 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.Issues | IssueTranslate | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | LoadFromColIssue | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Issues | MergeIssue | 🟢 Passed | 🟢 Passed | 🟡 Skipped | ⚠️ **Regression (Passed -> Skipped)** |
| EPPlusTest.Issues | PictureIssue | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldThrowInvalidCastExceptionIf | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldUseAclassProperties | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldUseAnonymousProperties | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.LoadFromCollectionTests | ShouldUseBaseClassProperties | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateBasic | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateClose | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateFlush | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ParallelDeflateOutputStreamTest | TestParallelDeflateLeaveOpen | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.SharedTest | GetFileLength_NonExistentFile_ThrowsFileNotFoundException | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.SharedTest | ReadWithRetry_ReadsSuccessfully | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.SharedTest | StringToByteArray_And_StringFromBuffer_Encoding | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipEntryExtractTest | ZipEntry_Extract_IsNotSupportedOnMono | ⚪ Missing | 🟡 Skipped | ⚪ Missing | Change (Skipped -> Missing) |
| EPPlusTest.Packaging.DotNetZip.ZipEntryExtractTest | ZipEntry_Extract_OverwritesExistingFileAndReleasesHandle | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryExtractTest | ZipEntry_Extract_WritesFileAndReleasesHandle | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_Constructor_SetsExpectedDefaults | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_DontEmitLastModified_RoundTrips | ⚪ Missing | 🟢 Passed | ⚪ Missing | ⚠️ **Regression (Passed -> Missing)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_ReadEntry_ParsesExtendedTimestampExtraField | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_ReadEntry_WithFalsePositiveDescriptorSignature_AccumulatesTrailerLength | ⚪ Missing | 🟢 Passed | 🔴 Failed | ⚠️ **Regression (Passed -> Failed)** |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_TypeAttributes_ArePresent | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_WriteCentralDirectoryEntry_WritesCommentBytes | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipEntryTest | ZipEntry_WriteCentralDirectoryEntry_WritesSegmentedDiskNumber | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipFileTest | ZipFile_AddEntry_DuplicateCase_AllowedInStable | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipFileTest | ZipFile_AddEntry_UsesDefaultEncoding | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_99SegmentLimit | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_ForUpdate_UpdatesSpecificSegment | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_Properties_And_SimpleMethods | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_Read_SpansMultipleSegments | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_TruncateBackward_RemovesInterveningSegments | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZipSegmentedStreamTest | ZipSegmentedStream_WriteAndRead_SpansSegments | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZlibCodecTest | ZlibCodec_CompressDecompress_Succeeds | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZlibCodecTest | ZlibCodec_Initialize_PropertiesSet | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.DotNetZip.ZlibCodecTest | ZlibCodec_VariousInitializers_Succeed | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.ZipPackageTest | AddPartTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.ZipPackageTest | CreateZipPackageTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.ZipPackageTest | DeletePartTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.ZipPackageTest | RelationshipTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Packaging.ZipPackageTest | SaveAndLoadTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ReadTemplate | CondFormatDataValBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | CopyIssue | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | FileStreamSave | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15014 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15030 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15038 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15039 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | I15043 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | InternalZip | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBlankStream | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug10 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug11 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug12 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug13 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug14 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug15 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug2 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug3 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug4 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug5 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug6 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug7 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug8 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadBug9 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadConditionalFormatting | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadNameError | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadStyleBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ReadURL | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | SaveCorruption | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | StreamTest | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | test | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | TestInvalidVBA | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | ThreadingTest | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.ReadTemplate | VBAerror | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.ReadTemplate | whitespace | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.SparkLines | StartTest | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.StringComparisonTests | TableLookup_ShouldBeCaseInsensitive | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.StringComparisonTests | WorksheetLookup_ShouldBeCaseInsensitive | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameEscapingTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameValidationTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameWithInvalidStartCharShouldFail | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.ExcelTableCollectionTest | TableNameWithSpacesShouldFail | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.PivotTableTest | PivotTableDefaultNameTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.PivotTableTest | PivotTableSourceRangeCasingTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Table.PivotTableTest | PivotTableSourceRangeTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.AddressUtilityTests | ParseForEntireColumnSelections_ShouldAddMaxRows | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.AddressUtilityTests | ParseForEntireColumnSelections_ShouldAddMaxRowsOnColumnsWithMultipleLetters | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.AddressUtilityTests | ParseForEntireColumnSelections_ShouldHandleMultipleRanges | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | BadTextToInt | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | BlankStringToNullableDecimal | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | BoolToDecimal | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | BoolToDouble | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | BoolToInt | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | DoubleToNullableInt | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | EmptyStringToDecimal | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | EmptyStringToNullableDecimal | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | FloatingPointStringToInt | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_BasicTypes | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_DateTime | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_Nullable | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | GetTypedCellValue_TimeSpan | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | IntStringToTimeSpan | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | IntToDateTime | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | IntToTimeSpan | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | InvariantCompareInfoTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | IsNumericTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | StringToDecimal | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | TextToInt | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.Utils.ConvertUtilTest | TryParseDateString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.ConvertUtilTest | TryParseNumericString | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsInRange_ShouldNotThrowIfArgumentIsInRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsInRange_ShouldThrowIfArgumentIsOutOfRange | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNull_ShouldNotThrowIfArgumentIsAnInstance | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNull_ShouldThrowIfArgumentIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNullOrEmpty_ShouldNotThrowIfStringIsNotNullOrEmpty | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.GuardingTests | Require_IsNotNullOrEmpty_ShouldThrowIfStringIsNull | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_FromSqRefAddress_ShouldReplaceSpaceWithComma | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldRemoveCommas | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldRemoveCommasAndInsertSpaceIfNecesary | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldRemoveMultipleSpaces | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.SqRefUtilityTests | SqRefUtility_ToSqRefAddress_ShouldThrowIfAddressIsNullOrEmpty | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | GetRelativeUri_ParentDirectory_ReturnsRelative | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | GetRelativeUri_SourceIsDirectory_ReturnsRelative | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | GetRelativeUri_Standard_ReturnsRelative | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_CurrentDirectory_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_ExternalUri_DivergenceTest | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_ParentDirectory_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_RelativePath_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_RootPath_ReturnsTarget | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.Utils.UriHelperTest | ResolvePartUri_SourceIsDirectory_ResolvesCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | Compression | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | CreateUnicodeWsName | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | DecompressionChunkGreaterThan4k | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBA | ReadNewVBA | ⚪ Missing | ⚪ Missing | 🟡 Skipped | Change (New Skipped) |
| EPPlusTest.VBA | ReadVBA | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | ReadVBAUnicodeWsName | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | Resign | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | VbaBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | VbaError | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | WriteLongVBAModule | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBA | WriteVBA | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.VBACollectionTest | VBACollection_Exists_ReturnsTrue | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBACollectionTest | VBACollection_Indexer_IsCaseInsensitive | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBACollectionTest | VBACollection_Indexer_ReturnsModule | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBACollectionTest | VBACollection_ReferenceIndexer_ReturnsReference | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBACompressionTest | VBA_CompressionDecompression_LargeBuffer | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBACompressionTest | VBA_CompressionDecompression_Parity | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBASignatureTest | VBASignature_MD5_IsUsed | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.VBASignatureTest | VBASignature_SignAndVerify_Success | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | ConfirmFileStructure | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteByNameWhereWorkSheetDoesNotExist | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteByNameWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteColumnAfterNormalRangeSheetShouldRemainUnchanged | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteColumnAfterRangeLimitThrowsArgumentException | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteColumnBeforeRangeMimitThrowsArgumentException | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteFirstColumnInRangeColumnShouldBeDeleted | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteFirstTwoColumnsFromRangeColumnsShouldBeDeleted | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | DeleteLastColumnInRangeColumnShouldBeDeleted | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorksheetsTests | MoveAfterByNameWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | MoveAfterByPositionWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | MoveBeforeByNameWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | MoveBeforeByPositionWhereWorkSheetExists | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | RangeClearMethodShouldNotClearSurroundingCells | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | ShouldBeAbleToDeleteAndThenAdd | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | TestTableCalculatedColumnFormulaTranslation | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorksheetsTests | TestVmlCommentsPartCleanup | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | BuildInStyles | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | CloseProblem | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ColumnsTest | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Comment | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CommentShiftsWithColumnInserts | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CommentShiftsWithRowInserts | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesAbsoluteCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesColumnAbsoluteCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesRelativeCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyCellUpdatesRowAbsoluteCrossSheetReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyColumnSetsOutlineLevelsCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyPivotTable | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | CopyRowCrossSheetSetsOutlineLevelsCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopyRowSetsOutlineLevelsCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CopySheetWithSharedFormula | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CreatePivotMultData | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertColumnAfterReferencesHasNoEffect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertColumnsUpdatesReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertRowAfterReferencesHasNoEffect | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetInsertRowsUpdatesReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | CrossSheetReferenceIsUpdatedWhenSheetIsRenamed | 🟢 Passed | 🟢 Passed | 🔴 Failed | ⚠️ **Regression (Passed -> Failed)** |
| EPPlusTest.WorkSheetTest | DateFunctionsWorkWithDifferentCultureDateFormats | 🔴 Failed | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.WorkSheetTest | DefColWidthBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | DelCol | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Deletews | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ExcelWorksheetRenameWithEndApostropheThrowsException | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | ExcelWorksheetRenameWithStartApostropheThrowsException | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | FileLockedProblem | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | FormulaArray | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | GenerateWorksheet | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorkSheetTest | InsCol | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | InsertColumnsSetsOutlineLevel | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | InsertRowsSetsOutlineLevel | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | InsertRowsUpdatesReferencesCorrectly | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Issue15207 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | LoadEmptyDataTable | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | LoadFromOneCollectionTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | LoadText | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorkSheetTest | LoadText_Bug15015 | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | LoadText_Bug15015_Negative | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Mergebug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Moveissue | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | Nametest | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | OpenProblem | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | OpenXlsm | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | PivotTableTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | ProtectionProblem | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadBug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadPivotTable | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadStreamWithTemplateWorkSheet | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ReadWorkSheet | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorkSheetTest | RowStyle | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | RunSample0 | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | RunWorksheetTests | 🟢 Passed | 🟢 Passed | 🔴 Failed | ⚠️ **Regression (Passed -> Failed)** |
| EPPlusTest.WorkSheetTest | SaveToStream | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | SetBackground | 🟢 Passed | 🔴 Failed | 🔴 Failed | Unchanged |
| EPPlusTest.WorkSheetTest | SetHeaderFooterImage | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Sort | 🟢 Passed | 🟢 Passed | 🟡 Skipped | ⚠️ **Regression (Passed -> Skipped)** |
| EPPlusTest.WorkSheetTest | Stylebug | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | TableDeleteTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TableTotalsRowFunctionEscapesSpecialCharactersInColumnName | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TableWithSubtotalsParensInColumnName | 🔴 Failed | 🔴 Failed | 🟢 Passed | 🎉 **Improvement (Failed -> Passed)** |
| EPPlusTest.WorkSheetTest | TestDate1904SetAndRemoveSetting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904SetAndSetSetting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904WithoutSetting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDate1904WithSetting | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestDelete | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | TestRepeatRowsAndColumnsTest | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanNotContainWhiteSpaces | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanNotStartsWithNumber | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanStartsWithBackSlash | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | TestTableNameCanStartsWithUnderscore | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.WorkSheetTest | Text | ⚪ Missing | ⚪ Missing | 🟢 Passed | 🎉 **Improvement (New Passed)** |
| EPPlusTest.WorkSheetTest | URL | 🟡 Skipped | 🟡 Skipped | 🟡 Skipped | Unchanged |
| EPPlusTest.WorkSheetTest | ValueText | 🟢 Passed | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.XmlHelperTest | XmlHelper_CreateNode_CreatesNewNode | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.XmlHelperTest | XmlHelper_CreateNode_DoesNotDuplicateExistingNode | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
| EPPlusTest.XmlHelperTest | XmlHelper_GetXmlNodeInt_ParsesCorrectly | ⚪ Missing | 🟢 Passed | 🟢 Passed | Unchanged |
