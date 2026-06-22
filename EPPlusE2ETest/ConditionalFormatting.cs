using System;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class ConditionalFormatting : TestsBase
    {
        static string template = "ConditionalFormatting.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Conditional");

                // Sample data
                sheet.Cells["A1"].Value = 10;
                sheet.Cells["A2"].Value = 20;
                sheet.Cells["A3"].Value = 30;

                sheet.Cells["B1"].Value = 100;
                sheet.Cells["B2"].Value = 200;
                sheet.Cells["B3"].Value = 300;
            });
        }

        [TestMethod]
        public void CleanupSheetKraftRules()
        {
            Test(template, null, "ConditionalFormatting.CleanupSheetKraftRules.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Conditional"];

                // SheetKraft rule (should be removed)
                var cf1 = sheet.ConditionalFormatting.AddExpression(sheet.Cells["A1:A3"]);
                cf1.Formula = "IF(SheetKraftFormat,A1>0,FALSE)";
                cf1.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                cf1.Style.Fill.BackgroundColor.Color = System.Drawing.Color.Red;

                // Normal rule (should remain)
                var cf2 = sheet.ConditionalFormatting.AddExpression(sheet.Cells["B1:B3"]);
                cf2.Formula = "B1>0";
                cf2.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                cf2.Style.Fill.BackgroundColor.Color = System.Drawing.Color.Green;

                RemoveSheetKraftConditionalFormatting(package, sheet);
            },
            package =>
            {
                var sheet = package.Workbook.Worksheets["Conditional"];

                Assert.AreEqual(10, Convert.ToInt32(sheet.Cells["A1"].Value));
                Assert.AreEqual(20, Convert.ToInt32(sheet.Cells["A2"].Value));
                Assert.AreEqual(30, Convert.ToInt32(sheet.Cells["A3"].Value));

                Assert.AreEqual(100, Convert.ToInt32(sheet.Cells["B1"].Value));
                Assert.AreEqual(200, Convert.ToInt32(sheet.Cells["B2"].Value));
                Assert.AreEqual(300, Convert.ToInt32(sheet.Cells["B3"].Value));

                var nsm = package.CreateDefaultNSM();

                var formulas = sheet.WorksheetXml
                    .SelectNodes("//d:conditionalFormatting/d:cfRule/d:formula", nsm)
                    .Cast<XmlNode>()
                    .Select(n => n.InnerText)
                    .ToList();

                Assert.IsFalse(
                    formulas.Any(f =>
                        f.StartsWith("IF(SheetKraftFormat,",
                            StringComparison.InvariantCultureIgnoreCase)));

                Assert.IsTrue(formulas.Contains("B1>0"));
            });
        }

        private static void RemoveSheetKraftConditionalFormatting(ExcelPackage package, ExcelWorksheet sheet)
        {
            var nsm = package.CreateDefaultNSM();
            nsm.AddNamespace("xm", "http://schemas.microsoft.com/office/excel/2006/main");
            var formats = sheet.WorksheetXml.SelectNodes("//xm:f", nsm).Cast<XmlNode>()
                .Where(f => f.InnerText.StartsWith("IF(SheetKraftFormat,", StringComparison.InvariantCultureIgnoreCase) &&
                            f.ParentNode?.ParentNode?.LocalName == "conditionalFormatting")
                .Select(f => f.ParentNode.ParentNode)
                .Distinct()
                .ToList();

            if (formats.Count == 0)
            {
                formats = sheet.WorksheetXml.SelectNodes("//d:formula", nsm).Cast<XmlNode>()
                    .Where(f => f.InnerText.StartsWith("IF(SheetKraftFormat,", StringComparison.InvariantCultureIgnoreCase) &&
                                f.ParentNode?.ParentNode?.LocalName == "conditionalFormatting")
                    .Select(f => f.ParentNode.ParentNode)
                    .Distinct()
                    .ToList();
            }

            if (formats.Count == 0)
            {
                return;
            }

            var parent = formats[0].ParentNode;
            foreach (var format in formats)
            {
                format.ParentNode.RemoveChild(format);
            }

            if (parent.ChildNodes.Count == 0)
            {
                parent.ParentNode.RemoveChild(parent);
            }
        }

        [TestMethod]
        public void RemoveEmptyConditionalFormattingParentElement()
        {
            Test(template, null, "ConditionalFormatting.RemoveEmptyParent.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Conditional"];
                
                var cf1 = sheet.ConditionalFormatting.AddExpression(sheet.Cells["A1:A3"]);
                cf1.Formula = "IF(SheetKraftFormat,A1>0,FALSE)";
                
                RemoveSheetKraftConditionalFormatting(package, sheet);
            },
            package =>
            {
                var sheet = package.Workbook.Worksheets["Conditional"];
                var nsm = package.CreateDefaultNSM();
                var condFormats = sheet.WorksheetXml.SelectNodes("//d:conditionalFormatting", nsm);
                Assert.AreEqual(0, condFormats.Count);
            });
        }

        [TestMethod]
        public void RemoveSheetKraftcfRulesLegacyXmNamespace()
        {
            Test(template, null, "ConditionalFormatting.CleanupLegacyXmNamespace.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Conditional"];
                
                // Programmatically inject legacy xm:f conditionalFormatting node
                var doc = sheet.WorksheetXml;
                var root = doc.DocumentElement;
                
                var condFormat = doc.CreateElement("conditionalFormatting", doc.DocumentElement.NamespaceURI);
                condFormat.SetAttribute("sqref", "A1:A3");
                
                var cfRule = doc.CreateElement("cfRule", doc.DocumentElement.NamespaceURI);
                cfRule.SetAttribute("type", "expression");
                cfRule.SetAttribute("priority", "1");
                
                var f = doc.CreateElement("f", "http://schemas.microsoft.com/office/excel/2006/main");
                f.Prefix = "xm";
                f.InnerText = "IF(SheetKraftFormat,A1>0,FALSE)";
                
                cfRule.AppendChild(f);
                condFormat.AppendChild(cfRule);
                root.AppendChild(condFormat);
                
                RemoveSheetKraftConditionalFormatting(package, sheet);
            },
            package =>
            {
                var sheet = package.Workbook.Worksheets["Conditional"];
                var nsm = package.CreateDefaultNSM();
                nsm.AddNamespace("xm", "http://schemas.microsoft.com/office/excel/2006/main");
                
                var nodes = sheet.WorksheetXml.SelectNodes("//xm:f", nsm);
                Assert.AreEqual(0, nodes.Count);
            });
        }
    }
}
