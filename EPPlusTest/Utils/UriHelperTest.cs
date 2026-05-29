using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Utils;

namespace EPPlusTest.Utils
{
    [TestClass]
    public class UriHelperTest
    {
        [TestMethod]
        public void ResolvePartUri_RootPath_ReturnsTarget()
        {
            var source = new Uri("/xl/workbook.xml", UriKind.Relative);
            var target = new Uri("/custom/path.xml", UriKind.Relative);
            var result = UriHelper.ResolvePartUri(source, target);
            Assert.AreEqual("/custom/path.xml", result.OriginalString);
        }

        [TestMethod]
        public void ResolvePartUri_RelativePath_ResolvesCorrectly()
        {
            var source = new Uri("/xl/workbook.xml", UriKind.Relative);
            var target = new Uri("worksheets/sheet1.xml", UriKind.Relative);
            var result = UriHelper.ResolvePartUri(source, target);
            Assert.AreEqual("/xl/worksheets/sheet1.xml", result.OriginalString);
        }

        [TestMethod]
        public void ResolvePartUri_ParentDirectory_ResolvesCorrectly()
        {
            var source = new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative);
            var target = new Uri("../theme/theme1.xml", UriKind.Relative);
            var result = UriHelper.ResolvePartUri(source, target);
            Assert.AreEqual("/xl/theme/theme1.xml", result.OriginalString);
        }

        [TestMethod]
        public void ResolvePartUri_ExternalUri_DivergenceTest()
        {
            var source = new Uri("/xl/workbook.xml", UriKind.Relative);
            var target = new Uri("http://example.com/file.xlsx", UriKind.Absolute);
            var result = UriHelper.ResolvePartUri(source, target);

            // On stable, it currently tries to resolve this relative to the source.
            // On dotnetport, it should return the target directly.
            // We want to document this difference.
            Assert.AreEqual("http://example.com/file.xlsx", result.OriginalString);
        }

        [TestMethod]
        public void GetRelativeUri_Standard_ReturnsRelative()
        {
            var source = new Uri("/xl/workbook.xml", UriKind.Relative);
            var target = new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative);
            var result = UriHelper.GetRelativeUri(source, target);
            Assert.AreEqual("worksheets/sheet1.xml", result.OriginalString);
        }

        [TestMethod]
        public void GetRelativeUri_ParentDirectory_ReturnsRelative()
        {
            var source = new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative);
            var target = new Uri("/xl/theme/theme1.xml", UriKind.Relative);
            var result = UriHelper.GetRelativeUri(source, target);
            Assert.AreEqual("../theme/theme1.xml", result.OriginalString);
        }
        [TestMethod]
        public void ResolvePartUri_CurrentDirectory_ResolvesCorrectly()
        {
            var source = new Uri("/xl/workbook.xml", UriKind.Relative);
            var target = new Uri("./worksheets/sheet1.xml", UriKind.Relative);
            var result = UriHelper.ResolvePartUri(source, target);
            Assert.AreEqual("/xl/worksheets/sheet1.xml", result.OriginalString);
        }

        [TestMethod]
        public void GetRelativeUri_SourceIsDirectory_ReturnsRelative()
        {
            var source = new Uri("/xl/worksheets/", UriKind.Relative);
            var target = new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative);
            var result = UriHelper.GetRelativeUri(source, target);
            Assert.AreEqual("../sheet1.xml", result.OriginalString);
        }

        [TestMethod]
        public void ResolvePartUri_SourceIsDirectory_ResolvesCorrectly()
        {
            var source = new Uri("/xl/worksheets/", UriKind.Relative);
            var target = new Uri("sheet1.xml", UriKind.Relative);
            var result = UriHelper.ResolvePartUri(source, target);
            Assert.AreEqual("/xl/worksheets//sheet1.xml", result.OriginalString);
        }
    }
}
