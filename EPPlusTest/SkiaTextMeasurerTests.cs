using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Drawing.Text;

namespace EPPlusTest
{
    [TestClass]
    public class SkiaTextMeasurerTests
    {
        [TestMethod]
        public void FontDescriptor_ExposesNativeNameAliasAndValueEquality()
        {
            var descriptor = new ExcelFontDescriptor("Calibri", 11f, false, false, false, false);

            Assert.AreEqual("Calibri", descriptor.Name);
            Assert.AreEqual(descriptor.Name, descriptor.FamilyName);
            Assert.AreEqual(descriptor, new ExcelFontDescriptor("calibri", 11f, false, false, false, false));
        }

        [TestMethod]
        public void Measure_ReturnsPositiveDimensionsForKnownFont()
        {
            using (var measurer = new SkiaTextMeasurer())
            {
                var measurement = measurer.Measure(
                    "Representative text",
                    new ExcelFontDescriptor("Calibri", 11f, false, false, false, false));

                Assert.IsTrue(measurement.Width > 0);
                Assert.IsTrue(measurement.Height > 0);
            }
        }

        [TestMethod]
        public void Measure_UsesFallbackWhenRequestedFontIsUnavailable()
        {
            using (var measurer = new SkiaTextMeasurer())
            {
                var measurement = measurer.Measure(
                    "Fallback font",
                    new ExcelFontDescriptor("DefinitelyMissingFontFamily", 11f, false, false, false, false));

                Assert.IsTrue(measurement.Width > 0);
                Assert.IsTrue(measurement.Height > 0);
            }
        }

        [TestMethod]
        public void Measure_ReflectsTextLengthAndStyleVariants()
        {
            using (var measurer = new SkiaTextMeasurer())
            {
                var regular = measurer.Measure(
                    "Short",
                    new ExcelFontDescriptor("Calibri", 11f, false, false, false, false));

                var longer = measurer.Measure(
                    "A much longer value",
                    new ExcelFontDescriptor("Calibri", 11f, false, false, false, false));

                var bold = measurer.Measure(
                    "Styled",
                    new ExcelFontDescriptor("Calibri", 11f, true, false, false, false));

                var italic = measurer.Measure(
                    "Styled",
                    new ExcelFontDescriptor("Calibri", 11f, false, true, false, false));

                Assert.IsTrue(longer.Width > regular.Width);
                Assert.IsTrue(bold.Width > 0);
                Assert.IsTrue(italic.Width > 0);
            }
        }
    }
}
