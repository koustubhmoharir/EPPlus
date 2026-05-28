# SkiaSharp Migration Plan

Date: 2026-05-28

## Objective

Migrate EPPlus away from `System.Drawing.Common` for .NET 9 compatibility while preserving the current behavior as far as practical.

Primary goals:

- Keep `AutoFitColumns` functional and deterministic across Windows, Linux, and macOS.
- Preserve existing images loaded from `.xlsx` packages across load, worksheet copy, worksheet delete, and save operations.
- Continue supporting image insertion from files for formats SkiaSharp can decode, and preserve byte-level insertion for formats Excel supports but SkiaSharp cannot decode.
- Remove the `System.Drawing.Common` package dependency from the core `net9.0` build.

Non-goals for the first migration:

- Rendering Excel drawings, charts, or worksheets to bitmaps.
- Pixel-perfect matching with GDI+ for every font and platform.
- Full rasterization or format conversion for vector formats such as WMF/EMF.

## External Compatibility Context

Microsoft documents `System.Drawing.Common` as Windows-specific starting with .NET 6; the non-Windows escape switch was removed in .NET 7. The current project targets `net9.0`, so keeping a cross-platform `System.Drawing.Common` dependency is not viable.

Reference:

- https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only

SkiaSharp is the intended replacement. The current stable NuGet package observed during planning is `SkiaSharp` `3.119.2`, with native asset packages available for platform deployment. The Linux no-dependency native asset package excludes Fontconfig, which is relevant to auto-fit font matching.

References:

- https://www.nuget.org/packages/SkiaSharp/
- https://www.nuget.org/packages/SkiaSharp.NativeAssets.Linux.NoDependencies/

## Current Code Findings

### Project Dependency

- `EPPlus/EPPlus.Core.csproj` targets `net9.0` and references `System.Drawing.Common` `9.0.0`.
- The migration must replace this with `SkiaSharp` and a native asset/deployment decision.

### Auto-Fit Columns

Current implementation:

- `EPPlus/ExcelRangeBase.cs:799` implements `AutoFitColumns(double MinimumWidth, double MaximumWidth)`.
- `EPPlus/ExcelRangeBase.cs:809` caches `System.Drawing.Font`.
- `EPPlus/ExcelRangeBase.cs:858` builds `FontStyle`.
- `EPPlus/ExcelRangeBase.cs:872` creates a `Bitmap`.
- `EPPlus/ExcelRangeBase.cs:873` creates `Graphics`.
- `EPPlus/ExcelRangeBase.cs:909` measures text with `Graphics.MeasureString`.
- `EPPlus/ExcelWorkbook.cs:326` documents `MaxFontWidth` as using GDI, although current `GetWidthPixels` uses the static `FontSize` table.

Behavior to preserve:

- Ignore formulas that have no calculated value.
- Ignore wrapped and merged cells.
- Leave hidden columns hidden.
- Add indentation width.
- Add auto-filter/table-filter extra width.
- Handle text rotation.
- Temporarily avoid drawing adjustment side effects while measuring, then restore drawing widths.

Migration need:

- Replace `Bitmap`, `Graphics`, `Font`, `FontStyle`, and `MeasureString` with a Skia-backed text measurement service.
- Keep the existing column-width formula and only change the measured pixel width source initially.

### Worksheet Pictures

Current implementation:

- `EPPlus/Drawing/ExcelPicture.cs:52` loads existing package image parts.
- `EPPlus/Drawing/ExcelPicture.cs:62` decodes existing package image bytes using `Image.FromStream`.
- `EPPlus/Drawing/ExcelPicture.cs:72` registers loaded images by hash.
- `EPPlus/Drawing/ExcelPicture.cs:93` constructs a picture from a `System.Drawing.Image`.
- `EPPlus/Drawing/ExcelPicture.cs:115` constructs a picture from `FileInfo`.
- `EPPlus/Drawing/ExcelPicture.cs:129` decodes file images using `Image.FromStream`.
- `EPPlus/Drawing/ExcelPicture.cs:198` exposes `ImageFormat`.
- `EPPlus/Drawing/ExcelPicture.cs:229` re-serializes `Image` into the package.
- `EPPlus/Drawing/ExcelPicture.cs:262` uses image dimensions and DPI to set anchor size.
- `EPPlus/Drawing/ExcelPicture.cs:309` exposes public `Image Image`.
- `EPPlus/Drawing/ExcelDrawings.cs:300` exposes `AddPicture(string, Image)`.
- `EPPlus/Drawing/ExcelDrawings.cs:310` exposes `AddPicture(string, Image, Uri)`.
- `EPPlus/Drawing/ExcelDrawings.cs:327` exposes `AddPicture(string, FileInfo)`.
- `EPPlus/Drawing/ExcelDrawings.cs:337` exposes `AddPicture(string, FileInfo, Uri)`.

Important issue:

- Existing package images are decoded and re-encoded just to compute a hash and expose `Image`. This can change bytes, lose metadata, fail on unsupported formats, and break preservation.

Migration need:

- Store original image bytes, content type, URI, relationship, dimensions, DPI, and hash without requiring a decoded bitmap.
- Decode with SkiaSharp only when metadata or conversion is needed.
- Preserve original bytes for loaded package images unless the user replaces the image.

### Worksheet Copy/Delete Image Handling

Current implementation:

- `EPPlus/ExcelWorksheets.cs:682` copies drawing XML.
- `EPPlus/ExcelWorksheets.cs:723` handles copied `ExcelPicture` instances.
- `EPPlus/ExcelWorksheets.cs:727` writes copied images by calling `pic.Image.Save(...)`.
- `EPPlus/ExcelWorksheets.cs:741` increments package image ref counts by `ImageHash`.
- `EPPlus/ExcelWorksheets.cs:924` preloads drawings before worksheet delete to avoid deleting shared images.
- `EPPlus/Drawing/ExcelPicture.cs:430` decrements image ref counts in `DeleteMe`.
- `EPPlus/ExcelPackage.cs:461` adds image bytes and creates package parts.
- `EPPlus/ExcelPackage.cs:495` loads existing image bytes into the package image registry.
- `EPPlus/ExcelPackage.cs:513` removes image parts when ref count reaches zero.

Important issue:

- Copying currently depends on `pic.Image.Save`, which forces decode/re-encode and fails for unsupported formats.
- Shared image reference counting is conceptually useful and should remain, but the hash must be based on original bytes, not re-encoded bytes.

Migration need:

- Copy image parts by bytes or by existing package part streams.
- Reuse the package image registry using byte hashes.
- Never require Skia to copy or save a loaded package image.

### Header/Footer Pictures

Current implementation:

- `EPPlus/ExcelHeaderFooter.cs:125` exposes `InsertPicture(Image, PictureAlignment)`.
- `EPPlus/ExcelHeaderFooter.cs:149` exposes `InsertPicture(FileInfo, PictureAlignment)`.
- `EPPlus/ExcelHeaderFooter.cs:158` decodes file images with `Image.FromFile`.
- `EPPlus/ExcelHeaderFooter.cs:179` computes VML picture size from `Image.Width`, `Image.Height`, and DPI.
- `EPPlus/Drawing/Vml/ExcelVmlDrawingPicture.cs:136` exposes public `Image Image`.
- `EPPlus/ExcelWorksheets.cs:505` copies header/footer pictures using existing VML/image URIs.

Migration need:

- Replace public `Image` overloads/properties with byte/file/stream-oriented APIs.
- Keep header/footer picture copy byte-preserving.
- Compute VML size from Skia metadata for decodable raster images and from parsed vector metadata or explicit size for non-raster formats.

### Background Images

Current implementation:

- `EPPlus/ExcelBackgroundImage.cs:58` exposes public `Image Image`.
- `EPPlus/ExcelBackgroundImage.cs:68` loads a package image using `Image.FromStream`.
- `EPPlus/ExcelBackgroundImage.cs:83` writes an image by re-serializing `Image`.
- `EPPlus/ExcelBackgroundImage.cs:103` supports `SetFromFile(FileInfo)`.
- `EPPlus/ExcelBackgroundImage.cs:113` validates file images using `Image.FromFile`.
- `EPPlus/ExcelBackgroundImage.cs:138` deletes previous images by re-reading `Image` and hashing re-encoded bytes.

Important issue:

- `SetFromFile` already writes original file bytes, but still validates through `System.Drawing.Image`.
- Deleting relies on re-encoded image bytes, which can mismatch the registered original bytes.

Migration need:

- Track the relationship/image hash directly for background images.
- Validate file images with Skia metadata where possible, or with content type and optional known-header checks.
- Delete by relationship target URI or stored package registry entry rather than by re-encoding the image.

### Color and Font Public APIs

Current implementation exposes `System.Drawing.Color` and `System.Drawing.Font` widely:

- `EPPlus/Style/ExcelColor.cs:113` has `SetColor(Color color)`.
- `EPPlus/Style/IColor.cs:24` requires `SetColor(Color color)`.
- `EPPlus/Sparkline/ExcelSparklineColor.cs:73` has `SetColor(Color color)`.
- Conditional formatting APIs expose `Color`, for example `EPPlus/ConditionalFormatting/Contracts/IRangeConditionalFormatting.cs:311`.
- Drawing fill, chart series, VML comments, rich text, and text font classes expose `Color`.
- `EPPlus/Style/ExcelFont.cs:216`, `EPPlus/Style/ExcelTextFont.cs:296`, and `EPPlus/Style/XmlAccess/ExcelFontXml.cs:272` expose `SetFromFont(System.Drawing.Font)`.

Migration need:

- This is larger than the image/auto-fit migration. Public API changes are acceptable, but must be staged to avoid a single high-risk rewrite.
- Introduce EPPlus-native color/font value types and keep optional Windows-only compatibility shims only if desired.

## Proposed Architecture

### New Internal Image Model

Introduce an internal image abstraction, separate from Skia:

```csharp
internal sealed class ExcelImageData
{
    public byte[] Bytes { get; }
    public string ContentType { get; }
    public Uri Uri { get; }
    public string Hash { get; }
    public int PixelWidth { get; }
    public int PixelHeight { get; }
    public float HorizontalDpi { get; }
    public float VerticalDpi { get; }
    public ExcelImageFormat Format { get; }
    public bool IsDecoded { get; }
}
```

Implementation notes:

- `Hash` is always SHA-1 of original bytes.
- `Bytes` are original package/file bytes unless the user explicitly replaces or converts the image.
- `HorizontalDpi` and `VerticalDpi` default to 96 when metadata is unavailable.
- `ContentType` is determined from package part content type or file extension.
- `ExcelImageFormat` is an EPPlus enum, not `System.Drawing.Imaging.ImageFormat`.

### New Skia Boundary

Create a narrow compatibility layer:

- `OfficeOpenXml.Drawing.Image.SkiaImageReader`
- `OfficeOpenXml.Drawing.Image.ExcelImageInfo`
- `OfficeOpenXml.Drawing.Text.SkiaTextMeasurer`
- `OfficeOpenXml.Drawing.Text.ITextMeasurer`

Rules:

- SkiaSharp code must be isolated to this layer.
- Package load/copy/save code should operate on bytes and package parts, not Skia objects.
- No public API should expose SkiaSharp types unless there is a deliberate decision to make SkiaSharp part of EPPlus's public surface.

### New Public Image APIs

Add public APIs that do not require `System.Drawing`:

```csharp
public ExcelPicture AddPicture(string name, FileInfo imageFile);
public ExcelPicture AddPicture(string name, Stream imageStream, string contentType);
public ExcelPicture AddPicture(string name, byte[] imageBytes, string contentType);
public ExcelPicture AddPicture(string name, ExcelImage image);

public sealed class ExcelImage
{
    public byte[] Bytes { get; }
    public string ContentType { get; }
    public int Width { get; }
    public int Height { get; }
    public float HorizontalDpi { get; }
    public float VerticalDpi { get; }
}
```

For unsupported-but-preservable formats:

```csharp
public ExcelPicture AddPicture(
    string name,
    Stream imageStream,
    string contentType,
    int pixelWidth,
    int pixelHeight,
    float horizontalDpi = 96,
    float verticalDpi = 96);
```

Rationale:

- Existing file overloads can remain and internally use Skia metadata.
- Stream/byte overloads cover callers that already have images without using `System.Drawing`.
- Explicit dimension overloads make WMF/EMF and other non-Skia formats insertable when EPPlus cannot infer size.

### Optional System.Drawing Compatibility Package

If backward source compatibility is required, move `System.Drawing`-based overloads into one of these:

- A Windows-only target condition: `net9.0-windows`.
- A separate compatibility assembly, for example `EPPlus.SystemDrawingCompat`.
- Obsolete overloads under a compile symbol, excluded from the default `net9.0` package.

Do not keep `System.Drawing.Common` in the cross-platform core package.

### New Public Color/Font Types

Introduce EPPlus-native value types:

```csharp
public readonly struct ExcelColorValue
{
    public byte A { get; }
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    public string ToArgbHex();
}

public readonly struct ExcelFontDescriptor
{
    public string Name { get; }
    public float Size { get; }
    public bool Bold { get; }
    public bool Italic { get; }
    public bool Underline { get; }
    public bool Strikeout { get; }
}
```

Migration path:

- Add `SetColor(byte alpha, byte red, byte green, byte blue)` and `SetColor(string argbHex)` where missing.
- Add `SetFromFont(ExcelFontDescriptor font)`.
- Mark `System.Drawing.Color` and `System.Drawing.Font` APIs obsolete where retained temporarily.

## Migration Workstreams

### 1. Package and Build Setup

Tasks:

- Replace `System.Drawing.Common` with `SkiaSharp`.
- Decide native asset packaging:
  - For application-style deployment, reference platform native assets in the consuming app.
  - For EPPlus test coverage, reference native assets in the test project.
  - Avoid forcing `SkiaSharp.NativeAssets.Linux.NoDependencies` in the library unless the package policy accepts that deployment tradeoff.
- Add CI/test matrix for Windows, Linux, and macOS on `net9.0`.
- Add a build check that fails if `System.Drawing` is used in the core project outside an optional compatibility folder.

Acceptance criteria:

- `dotnet restore` and `dotnet build` complete without `System.Drawing.Common` in `EPPlus/EPPlus.Core.csproj`.
- `rg "using System.Drawing" EPPlus` returns only allowed compatibility files or zero results for the core build.

### 2. Image Metadata and Byte Preservation

Tasks:

- Add `ExcelImageData` and `SkiaImageReader`.
- Update `ExcelPackage.AddImage`, `LoadImage`, `GetImageInfo`, and `RemoveImage` to manage original bytes and content type consistently.
- Hash original bytes only.
- Keep URI/content type from package parts when loading existing files.
- Replace image-copy code in `ExcelWorksheets.CopyDrawing` with byte/part copy.
- Track image relationships directly for background images and header/footer images.

Acceptance criteria:

- Loading and saving a workbook with existing images preserves media part bytes when images are untouched.
- Copying a worksheet with pictures does not decode or re-encode image bytes.
- Deleting one worksheet that shares an image with another worksheet does not delete the shared media part.
- Replacing a picture updates relationships, ref counts, and media parts correctly.

### 3. Worksheet Picture API Migration

Tasks:

- Add byte/stream/file image insertion overloads that do not expose `System.Drawing`.
- Change `ExcelPicture` internals to expose image metadata from `ExcelImageData`.
- Replace `ExcelPicture.Image` with a non-`System.Drawing` property, for example:
  - `public ExcelImage Image { get; set; }`, or
  - `public byte[] ImageBytes { get; }` plus `SetImage(...)`.
- Replace `ImageFormat` with `ExcelImageFormat` or `ContentType`.
- Keep `SetSize(int Percent)` behavior using stored metadata.
- Ensure duplicate-image de-duplication still works by hash.

Acceptance criteria:

- `AddPicture(string, FileInfo)` works for PNG, JPEG, GIF, and BMP if Skia decodes them in the test environment.
- Existing image tests are ported off `Properties.Resources.Test1` as `System.Drawing.Bitmap` and use bytes/files instead.
- Unsupported decoders produce a clear `InvalidDataException` unless explicit dimensions are provided.

### 4. Header/Footer and Background Images

Tasks:

- Add `InsertPicture(FileInfo, PictureAlignment)` implementation that reads bytes and uses Skia/header parsing for dimensions.
- Add `InsertPicture(Stream, string contentType, PictureAlignment, ...)`.
- Replace `ExcelVmlDrawingPicture.Image` with bytes/metadata.
- Replace `ExcelBackgroundImage.Image` with bytes/metadata or `SetImage(...)`.
- Fix background deletion to use relationship target and package registry instead of re-encoded bytes.

Acceptance criteria:

- Header/footer image insertion from files still creates correct VML dimensions.
- Header/footer image copy between sheets remains byte-preserving.
- Background image set/load/delete/save round-trips without `System.Drawing`.

### 5. Auto-Fit Text Measurement

Tasks:

- Introduce `ITextMeasurer.Measure(string text, ExcelFontDescriptor font)` returning width and height in pixels.
- Implement `SkiaTextMeasurer` with:
  - `SKTypeface.FromFamilyName(...)`
  - weight/slant mapping for bold and italic.
  - `SKFont` or `SKPaint` text bounds/width measurement.
  - fallback font behavior when the requested font is unavailable.
- Preserve current width calculation:
  - `width = (measuredWidth + 5) / normalSize` for non-rotated text.
  - existing rotation math for rotated text.
  - indentation and filter adjustments.
- Keep current static `FontSize` table as the normal font width source initially, then evaluate whether Skia should replace it.
- Add a configuration point for custom text measurement if users need Excel-tuned metrics:

```csharp
public interface IExcelTextMeasurer
{
    ExcelTextMeasurement Measure(string text, ExcelFontDescriptor font);
}
```

Acceptance criteria:

- `AutoFitColumns` no longer returns early because GDI is unavailable.
- Existing auto-fit tests pass after updating tolerances.
- New tests cover default Calibri-like sizing, bold, italic, indentation, rotation, hidden columns, merged cells, wrap text, and auto-filter width.
- Linux CI validates that auto-fit works without X11, libgdiplus, or fontconfig-specific assumptions.

### 6. Color and Font API Cleanup

Tasks:

- Introduce `ExcelColorValue` and `ExcelFontDescriptor`.
- Update style, conditional formatting, drawing, sparkline, rich text, and VML APIs to support non-`System.Drawing` color/font APIs.
- Replace internal use of `Color.ToArgb()` with EPPlus-native ARGB conversion.
- Replace `Color.FromArgb(...)` returns with `ExcelColorValue`.
- Move or obsolete `System.Drawing.Color` APIs.
- Move or obsolete `System.Drawing.Font` APIs.

Acceptance criteria:

- Core project compiles without `System.Drawing`.
- Public APIs have replacement methods for every removed `Color`/`Font` API.
- Existing style/conditional-formatting tests are ported to the new native color type or byte-based setters.

### 7. Tests and Regression Fixtures

Add fixtures:

- Workbook with existing PNG image.
- Workbook with existing JPEG image.
- Workbook with duplicate/shared image across sheets.
- Workbook with header/footer image.
- Workbook with background image.
- Workbook with unsupported but Excel-preservable media part, if available.

Test scenarios:

- Load and save without modification; compare `/xl/media/*` bytes.
- Load, copy worksheet, save; verify image parts and relationships.
- Load, delete original worksheet after copy, save; verify copied image still opens.
- Add picture from file and save; verify content type, relationship, dimensions, and Excel-openable package.
- Replace picture and verify old media part is removed only when unreferenced.
- Add header/footer picture and copy sheet.
- Set/delete background image.
- Auto-fit on representative text and styles on Linux.

Test mechanics:

- Avoid `Properties.Resources.Test1` typed as `System.Drawing.Bitmap`.
- Load test image resources as byte arrays or files.
- Add package-level assertions by inspecting ZIP entries and relationship XML.
- Use tolerances for auto-fit widths because text rendering differs by platform and installed fonts.

## Proposed Implementation Order

### Phase 0: Safety Harness

- Add image round-trip tests before implementation.
- Un-ignore or replace `DTS_FailingTests` with byte/file-based image tests.
- Add an auto-fit smoke test that runs on Linux.

Exit criteria:

- Failing tests document the current `System.Drawing` limitations.

### Phase 1: Image Byte Preservation

- Introduce `ExcelImageData`.
- Change package image registry to operate on original bytes.
- Update loaded `ExcelPicture` to avoid decode/re-encode.
- Update worksheet copy to copy media bytes.

Exit criteria:

- Existing-image load/copy/delete/save works without using `System.Drawing.Image`.

### Phase 2: Skia Image Metadata

- Add SkiaSharp dependency and `SkiaImageReader`.
- Update file insertion, header/footer insertion, and background image validation to use Skia metadata.
- Add explicit-dimension overloads for unsupported formats.

Exit criteria:

- Adding supported raster images from files works without `System.Drawing`.

### Phase 3: Auto-Fit

- Add `ITextMeasurer` and Skia implementation.
- Refactor `AutoFitColumns` to use the measurer.
- Add configuration override for custom measurers.

Exit criteria:

- Auto-fit runs successfully in headless Linux and .NET 9.

### Phase 4: Public API Replacement

- Introduce EPPlus-native color/font/image public types.
- Mark `System.Drawing` APIs obsolete or move them to compatibility assembly/target.
- Update samples and tests.

Exit criteria:

- Core package public API no longer requires `System.Drawing`.

### Phase 5: Remove System.Drawing from Core

- Remove `System.Drawing.Common` from `EPPlus.Core.csproj`.
- Remove or isolate all `using System.Drawing` from the core build.
- Add CI guard.

Exit criteria:

- `dotnet build` and selected test suite pass on `net9.0` without `System.Drawing.Common`.

## Risks and Mitigations

### Auto-Fit Accuracy

Risk:

- Skia text measurement will not exactly match GDI+ or Excel, especially when fonts are missing.

Mitigation:

- Keep the existing Excel width formula initially.
- Provide a pluggable text measurer.
- Use deterministic fallback fonts and document font installation recommendations.
- Compare output against a set of baseline workbooks rather than requiring exact GDI values.

### Unsupported Image Formats

Risk:

- Skia may not decode every format previously accepted by GDI+, especially WMF/EMF/TIFF variants.

Mitigation:

- Preserve existing package image bytes without decoding.
- For new insertion, support explicit dimensions for formats EPPlus cannot decode.
- Add metadata parsers for important vector formats if needed, starting with EMF and placeable WMF.
- Fail with clear messages for unsupported file additions.

### Public API Breakage

Risk:

- Removing `System.Drawing.Image`, `Color`, and `Font` breaks source compatibility.

Mitigation:

- Add replacement APIs first.
- Optionally ship a separate compatibility assembly.
- Document migration examples for picture insertion, colors, and fonts.

### Native Assets Deployment

Risk:

- SkiaSharp native assets differ by platform and deployment model.

Mitigation:

- Keep direct library dependency minimal.
- Document recommended native asset packages for applications and tests.
- Validate with self-contained and framework-dependent Linux builds.

## Open Decisions

- Should EPPlus expose SkiaSharp types publicly, or keep Skia entirely internal? Recommendation: keep Skia internal.
- Should legacy `System.Drawing` overloads live in a separate compatibility package? Recommendation: yes, if backward compatibility matters.
- Should unsupported image formats be inserted with default dimensions or require explicit dimensions? Recommendation: require explicit dimensions unless metadata can be parsed safely.
- Should auto-fit use installed platform fonts, bundled metrics, or a hybrid? Recommendation: Skia/platform fonts by default, with a custom measurer hook and documented fallback behavior.

## Tracking Checklist

- [x] Add image round-trip fixtures and tests.
- [x] Add auto-fit Linux smoke tests.
- [x] Add `ExcelImageData` internal model.
- [x] Refactor package image registry to use original bytes.
- [x] Refactor worksheet image copy to avoid decode/re-encode.
- [x] Add Skia image metadata reader.
- [x] Fix background-image deletion to release shared media.
- [x] Port header/footer image tests to byte-based fixtures.
- [x] Add non-`System.Drawing` picture insertion APIs.
- [x] Refactor header/footer images.
- [x] Refactor background images.
- [x] Add Skia text measurer.
- [x] Refactor `AutoFitColumns`.
- [x] Add EPPlus-native color type.
- [x] Add EPPlus-native font descriptor.
- [x] Remove public `System.Drawing` APIs.
- [x] Remove `System.Drawing.Common` package reference from core.
