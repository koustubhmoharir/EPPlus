using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class FinanceFunctionsTest
    {
        [TestMethod]
        public void TestPmtFunction()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Formula = "PMT(0.08/12, 10, 10000)";
                ws.Calculate();

                var val = ws.Cells["A1"].Value;
#if Core
                Assert.IsNotNull(val);
                Assert.IsInstanceOfType(val, typeof(double));
                // PMT(0.006666, 10, 10000) approx -1037.03
                Assert.AreEqual(-1037.03, Math.Round((double)val, 2));
#else
                // In stable, PMT is not implemented, so it should return #NAME?
                Assert.AreEqual("#NAME?", val.ToString());
#endif
            }
        }
    }
}
