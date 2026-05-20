# Branch Differences

This file documents the differences identified between the `dotnetport` branch and the `stable` branch.

| File Path | Method/Area | Description of Difference | Status |
|-----------|-------------|---------------------------|--------|
| Multiple Files | Header URL | Updated project URL from `codeplex.com` to `github.com` in file headers. | Verified |
| Multiple Files | TryParse Updates | Updated `int.TryParse` and `double.TryParse` to use `CultureInfo.InvariantCulture` and appropriate `NumberStyles`. | Verified |
| EPPlus/ExcelNamedRange.cs | LocalSheetId | Updated `LocalSheetId` calculation to use `_workbook._package._worksheetAdd` instead of a hardcoded `-1`. | ExcelRangeBaseTest.cs |
| EPPlus/ExcelNamedRangeCollection.cs | Name Validation & Bounds | Added name validation in `Add`. Improved `InsertColumn` and `InsertRow` with bounds checks against `MaxColumns` and `MaxRows`. Switched to `OrdinalIgnoreCase`. | ExcelNamedRangeCollectionTest.cs |
| EPPlus/ExcelHeaderFooter.cs | Header/Footer Features | Added `ScaleWithDocument` property. Refactored `InsertPicture` to use `ImageCompat` for .NET Core support. | ExcelHeaderFooterTest.cs |
| EPPlus/ExcelCommentCollection.cs | DeleteRow | Added null check for address after row deletion. | Verified |
| EPPlus/ExcelCellBase.cs | Formula & Address Parsing | Extensive refactoring of formula and address translation. Switched to `Lexer` for formula updates. Improved R1C1 and multi-address validation. Removed `MoveFormulaReferences`. | ExcelCellBaseTest.cs |
| EPPlus/ExcelBackgroundImage.cs | Image Handling | Refactored image to byte array conversion using `ImageCompat` for .NET Core. Optimized `SetPicture` to use `File.ReadAllBytes`. | WorkSheet.cs |
| EPPlus/ExcelAddress.cs | Address Handling, R1C1 | Added `R1C1` support in `AddressType` and `IsValid`. Refactored `SetAddress` and `SetWbWs` for better sheet/workbook prefix handling. Removed `swapIfReqd` logic and `Move` method. Added worksheet-specific constructor. | Address.cs |
| EPPlus/Encryption/EncryptionInfo.cs | API Cleanup | Removed `FileStream`-based `Read` and `ReadFile` methods; refactored to use `byte[]` exclusively. | EncryptionInfoTest.cs |
| EPPlus/Encryption/EncryptionHandler.cs | Encryption Refactoring | Major refactoring: changed `EncryptedPackageHandler` to `internal`, removed temp file usage, switched to `byte[]` and `MemoryStream` for processing. Added extensive `.NET Core` support for cryptographic algorithms. | EncryptedPackageHandlerTest.cs |
| EPPlus/Packaging/DotNetZip/ComHelper.cs | .NET Core Support | Commented out COM-related attributes `GuidAttribute`, `ComVisible`, and `ClassInterface` for .NET Core compatibility. | ComHelperTest.cs |
| EPPlus/Packaging/DotNetZip/CRC32.cs | .NET Core Support | Commented out COM-related attributes and conditionalized `IDisposable` / `Close` implementations (`#if !Core`) for .NET Core compatibility. | Crc32Test.cs |
| EPPlus/Packaging/DotNetZip/Exceptions.cs | .NET Core Support | Commented out COM attributes, `Serializable` attribute, and serialization constructors across custom `ZipException` classes for .NET Core compatibility. | ExceptionsTest.cs |
| EPPlus/Packaging/DotNetZip/FileSelector.cs | Regex Optimization | Simplified regex patterns from `[^'\f\n\r\t\v\x85\p{Z}]` to `\S`. Switched size suffix checks to `OrdinalIgnoreCase`. | FileSelectorTest.cs |
| EPPlus/Packaging/DotNetZip/Shared.cs | .NET Core Support | Removed `System.Security.Permissions`, mapped `IBM437` encoding to `UTF-8` under `Core` conditional, and removed unmanaged `SecurityPermission` check/retry logic. | SharedTest.cs |
| EPPlus/Packaging/DotNetZip/ZipDirEntry.cs | Duplicate Files Handling | Removed IgnoreDuplicateFiles conditional checks, simplified unique entry name suffix generation, and removed ThreadStatic tracking. | ZipDirEntryTest.cs |
| EPPlus/Packaging/DotNetZip/ZipEntry.cs | .NET Core Support | Removed `ClassInterface` attribute, mapped `IBM437` encoding to `UTF-8` under `Core` conditional, and removed `DontEmitLastModified` property. | ZipEntryTest.cs |
| EPPlus/Packaging/DotNetZip/ZipEntry.Extract.cs | .NET Core Support | Added `output.Dispose()` after `output.Close()` during file extraction to prevent stream leaks. | ZipEntryExtractTest.cs |
| EPPlus/Packaging/DotNetZip/ZipEntry.Read.cs | Zip Parsing & Extra Fields | Refactored `LengthOfTrailer` updates in `HandleDataDescriptor` and changed `dataSize` parameter type from `UInt16` to `Int16`/`short` in `ProcessExtraField` methods. | ZipEntryTest.cs |
| EPPlus/Packaging/DotNetZip/ZipEntry.Write.cs | Central Dir & Stream Cleanup | Added `Dispose()` calls for output stream, compressor, parallel compressor, and encryptor. Refactored central directory entry buffer, comment serialization, and segmented check. | ZipEntryTest.cs |
| EPPlus/Packaging/DotNetZip/ZipFile.AddUpdate.cs | .NET Core Support & Cleanup | Used UTF-8 encoding instead of Encoding.Default under Core conditional. Removed _entriesInsensitive registration in InternalAddEntry. | ZipFileTest.cs |
| EPPlus/Packaging/DotNetZip/ZipFile.cs | .NET Core Support & Unified Dict | Unified case-insensitive registry into _entries dictionary with _initEntriesDictionary(). Removed IgnoreDuplicateFiles. Simplified MaxOutputSegmentSize to Int32 and default encodings to UTF-8 under Core conditional. | ZipFileTest.cs |
| EPPlus/Packaging/DotNetZip/ZipFile.Read.cs | Zip Reading & Entry Registration | Removed _entriesInsensitive registration in ReadIntoInstance and ReadIntoInstance_Orig. Re-instantiated unified dictionary. | ZipFileTest.cs |
| EPPlus/Packaging/DotNetZip/ZipFile.Save.cs | Zip Save Operations | Refactored renaming and stream disposing using WriteStream.Dispose(). Checked _name directly and threw direct ZipException under Core conditional. | ZipFileTest.cs |
| EPPlus/Packaging/DotNetZip/ZipInputStream.cs | .NET Core Support | Mapped provisional encoding IBM437 to UTF-8 under Core conditional in constructor. | ZipFileTest.cs |
| EPPlus/Packaging/DotNetZip/ZipOutputStream.cs | .NET Core Support | Mapped default and alternate encodings from IBM437 to UTF-8 under Core conditional. | ZipFileTest.cs |
| EPPlus/Packaging/DotNetZip/ZipSegmentedStream.cs | Segmented Stream Writing | Simplified `_maxSegmentSize` to `int`. Enforced limit of 99 zip segments. Simplified chunking math and changed temporary file path resolution. | ZipSegmentedStreamTest.cs |
| EPPlus/Packaging/DotNetZip/Zlib/ParallelDeflateOutputStream.cs | Parallel Deflate Threading | Added `_outStream.Dispose()` under `Close()`. Refactored `_EmitAll` wait/termination loop conditions for complete flushing. | ParallelDeflateOutputStreamTest.cs |
| EPPlus/Packaging/DotNetZip/Zlib/ZlibCodec.cs | .NET Core Support | Commented out COM-related attributes `GuidAttribute`, `ComVisible`, and `ClassInterface` for .NET Core compatibility. | ZlibCodecTest.cs |
| EPPlus/Packaging/ZipPackage.cs | OOXML Package Management | Removed `IDisposable`, `tempFolder`, and `Dispose()`. Switched string comparisons to `OrdinalIgnoreCase`/`ToLowerInvariant()`. Refactored part streams to use `MemoryStream`. Added separator detection. | ZipPackageTest.cs |
| EPPlus/Packaging/ZipPackagePart.cs | OOXML Package Part Stream | Switched backing stream type from `FileStream` (using temporary files) to `MemoryStream`. Directly writes memory stream byte arrays to the `ZipOutputStream`. | ZipPackageTest.cs |
| EPPlus/Packaging/ZipPackageRelationshipBase.cs | .NET Core Support | Removed `using System.Web;` and switched string comparisons to `OrdinalIgnoreCase`. | ZipPackageTest.cs |
| EPPlus/Properties/AssemblyInfo.cs | .NET Core Support | Conditionalized assembly attributes under `#if (!Core)` since modern .NET Core projects define assembly metadata in the csproj file. | Verified |
| EPPlus/Style/ExcelColor.cs | Color Support | Implements `IColor` interface and `SetColor` method. Switched from `decimal.Round` to `Math.Round` in `translatedRGB` calculation. | ExcelColorTest.cs |
| EPPlus/Style/ExcelRichTextHtmlUtility.cs | .NET Core Support | Uses `System.Net.WebUtility.HtmlDecode` instead of `System.Web.HttpUtility.HtmlDecode` under `Core` conditional. | ExcelRichTextHtmlUtilityTest.cs |
| EPPlus/Style/StyleBase.cs | Font Styling | Added `Baseline` enum value to `ExcelVerticalAlignmentFont`. | ExcelStyleTest.cs |
| EPPlus/Style/XmlAccess/ExcelFillXml.cs | Code Cleanup | Removed commented-out XML node appending line in `CreateXmlNode` method. | Verified |
| EPPlus/Style/XmlAccess/ExcelFontXml.cs | Font Height Calculation | Refactored `GetFontHeight` interpolation logic to handle arbitrary sizes safely beyond lookup ranges. | ExcelStyleTest.cs |
| EPPlus/Style/XmlAccess/ExcelXfsXml.cs | Cell Formatting XML Serialization | Added @applyProtection="1" and @applyAlignment="1" attributes conditionally to Xfs XML node. | ExcelStyleTest.cs |
| EPPlus/Table/ExcelTableCollection.cs | Excel Table Collection | Added `ExcelAddressUtil.IsValidName` check to table name validation. Switched string comparisons to `OrdinalIgnoreCase`. | ExcelTableCollectionTest.cs |
| EPPlus/Table/ExcelTable.cs | Excel Table Operations | Added Excel escape and validation support to table names. Improved name uniqueness checks. | ExcelTableCollectionTest.cs |
| EPPlus/Table/PivotTable/ExcelPivotCacheDefinition.cs | Pivot Table Cache | Removed unused `System.Data.SqlClient`. Simplified worksheet range address lookup. Switched string comparisons to `OrdinalIgnoreCase`. | PivotTableTest.cs |
| EPPlus/Table/PivotTable/ExcelPivotTableCollection.cs | Pivot Table Collection | Changed generated default pivot table name prefix from `PivotTable` to `Pivottable`. | PivotTableTest.cs |
| EPPlus/Table/PivotTable/ExcelPivotTable.cs | Excel Pivot Table | Added `ColumnHeaderCaption` property. Corrected `ColumnGrandTotals` spelling and obsoleted `ColumGrandTotals`. Escaped table name in `GetStartXml`. | PivotTableTest.cs |
| EPPlus/Table/PivotTable/ExcelPivotTableField.cs | Excel Pivot Table Field | Added `MultipleItemSelectionAllowed` and various `Show` properties (e.g. `ShowDropDowns`). Used `ToLowerInvariant` in `SubTotal` setter. | PivotTableTest.cs |
| EPPlus/Utils/ConvertUtil.cs | Conversion Utilities | Added `GetTypedCellValue<T>` helper. Initialized `_invariantCompareInfo` using `Name` instead of `LCID`. Used `TypeCompat.IsPrimitive`. | ConvertUtilTest.cs |
| EPPlus/Utils/UriHelper.cs | URI Resolution | Updated ResolvePartUri to immediately return the targetUri if it contains ://. | UriHelperTest.cs |
| EPPlus/VBA/ExcelVBAModuleCollection.cs | .NET Core Support & Reflection | Used TypeCompat.GetPropertyValue instead of direct reflection. Switched string comparisons to OrdinalIgnoreCase. | VBACollectionTest.cs |
| EPPlus/VBA/ExcelVbaProject.cs | VBA Project Operations | Removed IDisposable and obsolete blank module helpers. Switched to VBACompression and Encoding.GetEncoding(0) for .NET Core compatibility. | VBACompressionTest.cs |
| EPPlus/VBA/ExcelVBASignature.cs | VBA Signature | Refactored SignedCms to EnvelopedCms under Core conditional. Updated X509Store construction and cleanup. Used MD5.Create(). | VBASignatureTest.cs |
| EPPlus/XmlHelper.cs | XML Parsing Helper | Refactored `CreateNode` with `addNew` parameter. Standardized `int.TryParse` with invariant culture. Conditionalized `DtdProcessing`. | XmlHelperTest.cs |
| EPPlus/Drawing/ExcelPicture.cs | Image Handling | Refactored image to byte array conversion using `ImageCompat` for .NET Core support. | ExcelPictureTest.cs |
| EPPlus/Drawing/Chart/ExcelChartPlotArea.cs | DataTable Support | Added `DataTable` property and `CreateDataTable`, `RemoveDataTable` methods. Initialized `_dataTable` in constructor. | ExcelChartDataTableTest.cs |
| EPPlus/Drawing/Chart/ExcelChart.cs | RoundedCorners, Core Support | Added RoundedCorners property. Refactored Save to avoid StreamWriter.Close() in .NET Core. Updated int.TryParse with CultureInfo.InvariantCulture. | ExcelChartTest.cs |
| EPPlus/Drawing/Chart/ExcelChartAxis.cs | Gridlines Support | Added `MajorGridlines`, `MinorGridlines` properties and `RemoveGridlines` methods. Updated `SchemaNodeOrder` to include `minorGridlines`. | ExcelChartAxisTest.cs |
| EPPlus/Drawing/Chart/ExcelBubbleChart.cs | ShowNegativeBubbles | Fixed incorrect XML documentation comment for `ShowNegativeBubbles`. | Verified |
| EPPlus/DataValidation/Formulas/ExcelDataValidationFormulaInt.cs | ParseValue | Updated `int.TryParse` to use `NumberStyles.Number` and `CultureInfo.InvariantCulture`. | IntegerFormulaTests.cs |
| EPPlus/ConditionalFormatting/Rules/ExcelConditionalFormattingTwoColorScale.cs | Constructor | Updated to use `ExcelConditionalFormattingConstants.Colors` objects directly instead of `ColorTranslator.FromHtml`. | ConditionalFormatting.cs |
| EPPlus/ConditionalFormatting/Rules/ExcelConditionalFormattingThreeColorScale.cs | Constructor | Updated to use `ExcelConditionalFormattingConstants.Colors` objects directly instead of `ColorTranslator.FromHtml`. | ConditionalFormatting.cs |
| EPPlus/ConditionalFormatting/ExcelConditionalFormattingIconDatabarValue.cs | GreaterThanOrEqualTo | Added `GreaterThanOrEqualTo` property to support the `@gte` attribute in CFVO nodes. | ConditionalFormatting.cs |
| EPPlus/ConditionalFormatting/ExcelConditionalFormattingConstants.cs | Constants, Colors | Added `Gte` attribute constants. Changed default CFVO colors from hex strings to `System.Drawing.Color` objects. | ConditionalFormatting.cs |
| EPPlus/CellStore.cs | GetPosition(int Row), GetPosition(int Column), Refactoring | Added performance optimization: direct indexing check before binary search in GetPosition. Refactored GetValue, Clear, and Exists to use GetPosition. | Verified on .NET 9 |
| Multiple Files | Floating-point Precision | Identified precision differences between Mono and .NET 9 in `double.ToString()` and `TimeSpan` to `double` conversions. | Resolved in tests |
| EPPlus/ExcelPackage.cs | Constructors / Init | Added .NET Core support; refactored stream handling to avoid temp folders; added `appsettings.json` support. Added `Compatibility` and `_worksheetAdd`. | ExcelPackageTest.cs |
| EPPlus/ExcelProtectedRange.cs | Password Hashing | Updated `SetPassword` to use `SHA512.Create()` for .NET Core support. | ExcelProtectedRangeTest.cs |
| EPPlus/ExcelProtectedRangeCollection.cs | Add Method | Added name uniqueness check and refactored XML node creation for protected ranges. | ExcelProtectedRangeTest.cs |
| EPPlus/ExcelPackage.cs | Save / SavePart | Switched to `XmlTextWriter` with `Formatting.None`; refactored encryption to use `MemoryStream`; improved `CopyStream` performance. | ExcelPackageTest.cs |
| EPPlus/ExcelWorksheet.cs | .NET Core & Features | Added `SparklineGroups`. Updated `Load` to use `XmlReader.Create` with .NET Core compatible settings. Improved `Name` setter to update Extended Properties. Switched to `OrdinalIgnoreCase` for unique name checks. Simplified `AdjustFormulasRow/Column`. Removed `MoveFormulaReferences`. Added `FixSharedFormulas`. | SparkLines.cs, WorksheetsTests.cs |
| EPPlus/ExcelWorksheet.cs | Internal Cleanup | Improved URI generation for comments/VML with part existence check (Issue #236). Refactored `PivotTable` address saving; removed `RemoveSheetPrefix`. | WorksheetsTests.cs |
| EPPlus/ExcelWorksheet.cs | Table Support | Added R1C1 translation for calculated column formulas during save. | WorksheetsTests.cs |
| EPPlus/ExcelWorksheet.cs | GetValue<T> | Refactored to delegate type conversion to `ConvertUtil.GetTypedCellValue<T>`. Behavioral difference: `bool` (True) converts to `1` in .NET 9, documented as a change from `stable`. | Verified on .NET 9 |
| EPPlus/ExcelRangeBase.cs | Range Operations & Formatting | Replaced `Type.IsPrimitive` with `TypeCompat.IsPrimitive`. Added `GetDateText` for robust date formatting. Refactored `LoadFromText` with better line splitting. Updated `GetValue<T>` to use `ConvertUtil`. Removed `simulateCut` and `retainFormats` from `Copy`, `Clear`, and `Delete`. | ExcelRangeBaseTest.cs |
| EPPlus/Drawing/ExcelDrawings.cs | AddChart | Added overloads supporting `ExcelPivotTable` as source. | ExcelChartTest.cs |
| EPPlus/Drawing/ExcelDrawings.cs | Internal State | Switched to `OrdinalIgnoreCase` for drawing names; improved XML part creation with unique URI logic (Issue #100). | ExcelChartTest.cs |
| EPPlus/FormulaParsing/EpplusExcelDataProvider.cs | Address Handling | Added `ConvertToA1C1` and `GetRange` overrides for Table-style addresses. | EpplusExcelDataProviderTests.cs |
| EPPlus/FormulaParsing/ExcelUtilities/ExcelAddressUtil.cs | Name Validation | Added `IsValidName` and `GetValidName` methods to support named range validation. | ExcelAddressUtilTests.cs |
| EPPlus/FormulaParsing/ExcelUtilities/RangeAddressFactory.cs | Table-style Address Parsing | Updated `Create` method to parse Table-style addresses and convert them to standard A1C1 addresses using `ExcelDataProvider`. | RangeAddressFactoryTests.cs |
| EPPlus/FormulaParsing/ExpressionGraph/ExpressionConverter.cs | Date/Time Conversion | Updated FromCompileResult to convert DataType.Time and DataType.Date to DecimalExpression using (double)compileResult.Result. | ExpressionConverterTests.cs |
| EPPlus/FormulaParsing/LexicalAnalysis/SourceCodeTokenizer.cs | R1C1 Support | Added `R1C1` static property and updated constructor and tokenization logic to support `TokenType.ExcelAddressR1C1`. | R1C1Tests.cs |
| EPPlus/FormulaParsing/LexicalAnalysis/TokenFactory.cs | R1C1 Support | Updated constructors to accept `r1c1` parameter, and updated `Create` to check for R1C1 addresses and return `TokenType.ExcelAddressR1C1`. | R1C1Tests.cs |
| EPPlus/FormulaParsing/LexicalAnalysis/TokenType.cs | R1C1 Support | Added `ExcelAddressR1C1` to `TokenType` enum. | R1C1Tests.cs |
| EPPlus/FormulaParsing/Logging/TextFileLogger.cs | .NET Core Support | Added `StreamWriter` creation conditional logic (`#if Core`) for .NET Core compatibility. | TextFileLoggerTests.cs |
| EPPlus/FormulaParsing/Utilities/ExtensionMethods.cs | .NET Core Compatibility | Switched to `TypeCompat.IsPrimitive` for .NET Core compatibility. | ExtensionMethodsTests.cs |
| EPPlus/FormulaParsing/LexicalAnalysis/TokenSeparatorHandlers/MultipleCharSeparatorHandler.cs | Cleanup | Removed unnecessary `CultureInfo.InvariantCulture` from `char.ToString()`. | MultipleCharSeparatorHandlerTests.cs |
| EPPlus/FormulaParsing/LexicalAnalysis/TokenSeparatorHandlers/SeparatorHandler.cs | Cleanup | Restored `IsSingleQuote` method to fix `SheetnameHandler` regression. | TokenHandlerTestsInternal.cs |
| EPPlus/FormulaParsing/LexicalAnalysis/TokenSeparatorHandlers/SheetnameHandler.cs | Worksheet Name Handling | Fixed regression by restoring single quote handling for escaped names. | SheetnameHandlerTests.cs, SheetnameTests.cs |
| Multiple Files | String Comparisons | Switched from `InvariantCultureIgnoreCase` to `OrdinalIgnoreCase` in many locations. | StringComparisonTests.cs |
| EPPlus/ExcelStyles.cs | Named Styles & Cloning | Updated CreateNamedStyle to ensure correct CellXfs cloning. Refactored CloneStyle with better parameter naming (allwaysAddCellXfs) and logic for cross-workbook style matching. Fixed column reference update in AddNewStyle. Fixed ExcelStyle property lookups for named styles. | ExcelStylesDivergenceTest.cs |
| EPPlus/ExcelWorkbook.cs | .NET Core Support & Worksheets | Added support for 0-based worksheet indexing via `_package._worksheetAdd` (Compatibility mode). Updated `SchemaNodeOrder` for `webPublishObjects` and `extLst`. Switched to `OrdinalIgnoreCase` for shared strings relationship check. Initialized `_nextPivotTableID` to `int.MinValue`. | ExcelWorkbookTest.cs |
| EPPlus/ExcelWorksheets.cs | Collection Management | Integrated 0-based indexing support. Added `AppendSheetNameToAppXml` to synchronize Extended Properties. Refactored `CopyPivotTable` and `CopyCells` (merged cells) for better reliability. Ensured `_nextTableID` initialization. Removed `MONO` conditional around VBA copying. | Pending |
| EPPlus/ExcelWorksheetView.cs | Tab Selection | Added TabSelectedMulti and SetTabSelected to support multiple selected worksheet tabs. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/BuiltInFunctions.cs | Finance Functions | Added `PMT` function to `BuiltInFunctions`. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/ExcelDoubleCellValue.cs | API Cleanup | Added `GetHashCode` override. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/ExcelFunction.cs | Refactoring & Compatibility | Added `ArgToAddress`. Switched to `TypeCompat.IsPrimitive`. Added static imports for `ExcelDataProvider`. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/Math/Ceiling.cs | Math Logic | Added check for `number % significance == 0` to return the number directly. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/Math/Floor.cs | Math Logic | Added check for `number % significance == 0` to return the number directly. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/Math/Round.cs | Math Logic | Updated rounding logic for negative digits and switched to `MidpointRounding.AwayFromZero` to match Excel behavior. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/RefAndLookup/Indirect.cs | Address Handling | Switched to `ArgToAddress` and used simplified `GetRange` overload. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/RefAndLookup/Match.cs | Address Handling | Switched to `ArgToAddress`. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/RefAndLookup/Offset.cs | Address Handling & Logic | Switched to `ArgToAddress`. Refactored `toRow`/`toCol` calculation for correct height/width handling. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/Text/Proper.cs | Cleanup | Removed unnecessary `CultureInfo.InvariantCulture` from `char.ToString()`. | Pending |
| EPPlus/FormulaParsing/Excel/Functions/Text/Value.cs | Logic & Regex | Added null/empty check. Updated regex for decimal separator matching. | Pending |
| EPPlus/FormulaParsing/ExcelDataProvider.cs | GetRange Overload | Added abstract `GetRange(string worksheetName, string address)` method. | Pending |



