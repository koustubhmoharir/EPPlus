using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelRichTextHtmlUtilityTest : TestBase
    {
        [TestMethod]
        public void RichTextHtml_HtmlDecode_Test()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Test");
                var range = ws.Cells["A1"];

                // Test basic HTML entities. Note: &apos; is not decoded by HttpUtility in .NET 3.5
                string html = "<b>Bold &amp; More</b> <i>Italic &lt; Tag &gt;</i> &quot;Quote&quot; &apos;Apos&apos;";
                ExcelRichTextHtmlUtility.SetRichTextFromHtml(range, html, "Calibri", 11);

                Assert.IsTrue(range.IsRichText);
                
                string fullText = "";
                foreach(var rt in range.RichText) fullText += rt.Text;
                Assert.AreEqual("Bold & More Italic < Tag > \"Quote\" &apos;Apos&apos;", fullText);
                
                bool foundBold = false;
                bool foundItalic = false;
                foreach(var rt in range.RichText) {
                    if (rt.Text == "Bold & More" && rt.Bold) foundBold = true;
                    if (rt.Text == "Italic < Tag >" && rt.Italic) foundItalic = true;
                }
                Assert.IsTrue(foundBold, "Bold text not found");
                Assert.IsTrue(foundItalic, "Italic text not found");
            }
        }

        [TestMethod]
        public void RichTextHtml_NonBreakingSpace_Test()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Test");
                var range = ws.Cells["A1"];

                // Test non-breaking space replacement
                string html = "Text&nbsp;with&nbsp;nbsp";
                ExcelRichTextHtmlUtility.SetRichTextFromHtml(range, html, "Calibri", 11);

                Assert.IsFalse(range.IsRichText);
                Assert.AreEqual("Text with nbsp", range.Value.ToString());
            }
        }
        
        [TestMethod]
        public void RichTextHtml_BrTag_Test()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Test");
                var range = ws.Cells["A1"];

                // Test BR tag replacement
                string html = "Line1<br>Line2<br/>Line3<br  />Line4";
                ExcelRichTextHtmlUtility.SetRichTextFromHtml(range, html, "Calibri", 11);

                Assert.IsFalse(range.IsRichText);
                Assert.AreEqual("Line1\r\nLine2\r\nLine3\r\nLine4", range.Value.ToString());
            }
        }

        [TestMethod]
        public void RichTextHtml_AllTags_Test()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Test");
                var range = ws.Cells["A1"];

                string html = "<b>Bold</b><strong>Strong</strong><i>Italic</i><em>Em</em><u>Underline</u><s>Strike</s><strike>Strike2</strike><sup>Sup</sup><sub>Sub</sub>";
                ExcelRichTextHtmlUtility.SetRichTextFromHtml(range, html, "Calibri", 11);

                Assert.IsTrue(range.IsRichText);
                
                Assert.IsTrue(HasRichText(range, "Bold", rt => rt.Bold));
                Assert.IsTrue(HasRichText(range, "Strong", rt => rt.Bold));
                Assert.IsTrue(HasRichText(range, "Italic", rt => rt.Italic));
                Assert.IsTrue(HasRichText(range, "Em", rt => rt.Italic));
                Assert.IsTrue(HasRichText(range, "Underline", rt => rt.UnderLine));
                Assert.IsTrue(HasRichText(range, "Strike", rt => rt.Strike));
                Assert.IsTrue(HasRichText(range, "Strike2", rt => rt.Strike));
                Assert.IsTrue(HasRichText(range, "Sup", rt => rt.VerticalAlign == ExcelVerticalAlignmentFont.Superscript));
                Assert.IsTrue(HasRichText(range, "Sub", rt => rt.VerticalAlign == ExcelVerticalAlignmentFont.Subscript));
            }
        }

        private bool HasRichText(ExcelRange range, string text, Func<ExcelRichText, bool> predicate) {
            foreach(var rt in range.RichText) {
                if (rt.Text == text && predicate(rt)) return true;
            }
            return false;
        }
    }
}
