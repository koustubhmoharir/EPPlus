namespace OfficeOpenXml.Drawing.Text
{
    internal interface ITextMeasurer
    {
        ExcelTextMeasurement Measure(string text, ExcelFontDescriptor font);
    }
}
