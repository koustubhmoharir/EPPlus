namespace OfficeOpenXml.Drawing.Text
{
    internal static class ExcelTextMeasurerProvider
    {
        internal static ITextMeasurer Current { get; set; } = new SkiaTextMeasurer();
    }
}
