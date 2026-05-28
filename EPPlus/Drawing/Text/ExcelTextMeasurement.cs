namespace OfficeOpenXml.Drawing.Text
{
    internal readonly struct ExcelTextMeasurement
    {
        internal ExcelTextMeasurement(double width, double height)
        {
            Width = width;
            Height = height;
        }

        internal double Width { get; }

        internal double Height { get; }
    }
}
