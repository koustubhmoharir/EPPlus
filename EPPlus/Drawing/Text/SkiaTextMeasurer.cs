using System;
using System.Collections.Concurrent;
using SkiaSharp;

namespace OfficeOpenXml.Drawing.Text
{
    internal sealed class SkiaTextMeasurer : ITextMeasurer, IDisposable
    {
        private readonly ConcurrentDictionary<string, SKTypeface> _typefaces = new ConcurrentDictionary<string, SKTypeface>(StringComparer.OrdinalIgnoreCase);

        public ExcelTextMeasurement Measure(string text, ExcelFontDescriptor font)
        {
            if (text == null)
            {
                text = string.Empty;
            }

            using (var skFont = CreateFont(font))
            {
                SKRect bounds;
                var width = skFont.MeasureText(text, out bounds);
                var metrics = skFont.Metrics;
                var height = Math.Max(bounds.Height, metrics.Descent - metrics.Ascent);

                return new ExcelTextMeasurement(width, height);
            }
        }

        private SKFont CreateFont(ExcelFontDescriptor font)
        {
            var typeface = GetTypeface(font);
            var skFont = new SKFont(typeface, font.Size)
            {
                Edging = SKFontEdging.SubpixelAntialias,
                Hinting = SKFontHinting.Full,
                Subpixel = true
            };

            return skFont;
        }

        private SKTypeface GetTypeface(ExcelFontDescriptor font)
        {
            var key = string.Concat(
                string.IsNullOrWhiteSpace(font.Name) ? string.Empty : font.Name.Trim(),
                "|",
                font.Bold ? "b" : "n",
                "|",
                font.Italic ? "i" : "n");

            return _typefaces.GetOrAdd(key, _ =>
            {
                var familyName = string.IsNullOrWhiteSpace(font.Name) ? null : font.Name.Trim();
                var style = new SKFontStyle(
                    font.Bold ? SKFontStyleWeight.Bold : SKFontStyleWeight.Normal,
                    SKFontStyleWidth.Normal,
                    font.Italic ? SKFontStyleSlant.Italic : SKFontStyleSlant.Upright);

                var typeface = string.IsNullOrEmpty(familyName)
                    ? SKTypeface.Default
                    : SKTypeface.FromFamilyName(familyName, style);

                return typeface ?? SKTypeface.Default;
            });
        }

        public void Dispose()
        {
            foreach (var typeface in _typefaces.Values)
            {
                if (!ReferenceEquals(typeface, SKTypeface.Default))
                {
                    typeface.Dispose();
                }
            }
        }
    }
}
