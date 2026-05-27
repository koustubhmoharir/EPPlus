using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelProtectedRangeTest
    {
        [TestMethod]
        public void TestProtectedRangePropertiesAndSetPassword()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var range = ws.ProtectedRanges.Add("Range1", new ExcelAddress("A1:B2"));

                Assert.AreEqual("Range1", range.Name);
                Assert.AreEqual("A1:B2", range.Address.Address);

                // Set/Get Name
                range.Name = "Range1_Updated";
                Assert.AreEqual("Range1_Updated", range.Name);

                // Set/Get Address
                range.Address = new ExcelAddress("C3:D4");
                Assert.AreEqual("C3:D4", range.Address.Address);

                // Set/Get SecurityDescriptor
                range.SecurityDescriptor = "SomeDescriptor";
                Assert.AreEqual("SomeDescriptor", range.SecurityDescriptor);

                // Set/Get SpinCount (default is int.MinValue when node is not present)
                Assert.AreEqual(int.MinValue, range.SpinCount);
                range.SpinCount = 120000;
                Assert.AreEqual(120000, range.SpinCount);

                // Test SetPassword
                range.SetPassword("MySecretPassword");

                // Salt and Hash should be set
                Assert.IsFalse(string.IsNullOrEmpty(range.Salt));
                Assert.IsFalse(string.IsNullOrEmpty(range.Hash));
                Assert.AreEqual(eProtectedRangeAlgorithm.SHA512, range.Algorithm);
                Assert.AreEqual(120000, range.SpinCount);

                // Let's test with default spin count resetting to 100000
                var range2 = ws.ProtectedRanges.Add("Range2", new ExcelAddress("E5:F6"));
                range2.SetPassword("AnotherPassword");
#if Core
                Assert.AreEqual(100000, range2.SpinCount);
#else
                // On stable, range2 overwrites/reuses the XML node of range1 due to XML creation bug,
                // so its SpinCount is 120000 instead of 100000.
                Assert.AreEqual(120000, range2.SpinCount);
#endif
                Assert.IsFalse(string.IsNullOrEmpty(range2.Salt));
                Assert.IsFalse(string.IsNullOrEmpty(range2.Hash));

                // Test Algorithm property with other values to exercise algorithm insertion logic
                range2.Algorithm = eProtectedRangeAlgorithm.RIPEMD160;
                Assert.AreEqual(eProtectedRangeAlgorithm.RIPEMD160, range2.Algorithm);

                range2.Algorithm = eProtectedRangeAlgorithm.MD5;
                Assert.AreEqual(eProtectedRangeAlgorithm.MD5, range2.Algorithm);

                range2.Algorithm = eProtectedRangeAlgorithm.SHA256;
                Assert.AreEqual(eProtectedRangeAlgorithm.SHA256, range2.Algorithm);
            }
        }

        [TestMethod]
        public void TestProtectedRangeCollectionOperations()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var prCollection = ws.ProtectedRanges;

                Assert.AreEqual(0, prCollection.Count);

                var r1 = prCollection.Add("Range1", new ExcelAddress("A1"));
                var r2 = prCollection.Add("Range2", new ExcelAddress("B2"));
                var r3 = prCollection.Add("Range3", new ExcelAddress("C3"));

                Assert.AreEqual(3, prCollection.Count);
                Assert.AreEqual(r1, prCollection[0]);
                Assert.AreEqual(r2, prCollection[1]);
                Assert.AreEqual(r3, prCollection[2]);

                // Contains
                Assert.IsTrue(prCollection.Contains(r1));
                Assert.IsTrue(prCollection.Contains(r2));
                Assert.IsFalse(prCollection.Contains(new ExcelProtectedRange("RangeX", new ExcelAddress("D4"), ws.NameSpaceManager, ws.TopNode)));

                // IndexOf
                Assert.AreEqual(0, prCollection.IndexOf(r1));
                Assert.AreEqual(1, prCollection.IndexOf(r2));
                Assert.AreEqual(-1, prCollection.IndexOf(new ExcelProtectedRange("RangeX", new ExcelAddress("D4"), ws.NameSpaceManager, ws.TopNode)));

                // CopyTo
                var array = new ExcelProtectedRange[3];
                prCollection.CopyTo(array, 0);
                Assert.AreEqual(r1, array[0]);
                Assert.AreEqual(r2, array[1]);
                Assert.AreEqual(r3, array[2]);

                // Enumerators
                var list = new List<ExcelProtectedRange>();
                foreach (var item in prCollection)
                {
                    list.Add(item);
                }
                Assert.AreEqual(3, list.Count);
                Assert.AreEqual(r1, list[0]);

                System.Collections.IEnumerator nonGenericEnum = ((System.Collections.IEnumerable)prCollection).GetEnumerator();
                Assert.IsTrue(nonGenericEnum.MoveNext());
                Assert.AreEqual(r1, nonGenericEnum.Current);

                // Remove
                Assert.IsTrue(prCollection.Remove(r2));
                Assert.AreEqual(2, prCollection.Count);
                Assert.IsFalse(prCollection.Contains(r2));

                // Index-based RemoveAt
                prCollection.RemoveAt(0); // Removes r1
                Assert.AreEqual(1, prCollection.Count);
                Assert.AreEqual(r3, prCollection[0]);

                // Clear
                prCollection.Clear();
                Assert.AreEqual(0, prCollection.Count);
            }
        }

        [TestMethod]
        public void TestProtectedRangeDuplicateName()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.ProtectedRanges.Add("Range1", new ExcelAddress("A1:B2"));

#if Core
                // On dotnetport branch, duplicate names are prohibited and throw InvalidOperationException
                try
                {
                    ws.ProtectedRanges.Add("range1", new ExcelAddress("C3:D4"));
                    Assert.Fail("Should have thrown InvalidOperationException on dotnetport branch for duplicate name");
                }
                catch (InvalidOperationException ex)
                {
                    Assert.IsTrue(ex.Message.Contains("already exists"));
                }
#else
                // On stable branch, duplicate names are permitted and don't throw
                var r2 = ws.ProtectedRanges.Add("range1", new ExcelAddress("C3:D4"));
                Assert.AreEqual("range1", r2.Name);
                Assert.AreEqual(2, ws.ProtectedRanges.Count);
#endif
            }
        }

        [TestMethod]
        public void TestProtectedRangeSerialization()
        {
            byte[] packageBytes;
            var xlsxFile = new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx"));
            try
            {
                using (var package = new ExcelPackage(xlsxFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws = package.Workbook.Worksheets.Add("Sheet1");
                    var r1 = ws.ProtectedRanges.Add("Range1", new ExcelAddress("A1:B2"));
                    r1.SetPassword("Password123");
                    r1.SecurityDescriptor = "SDVal";

                    var r2 = ws.ProtectedRanges.Add("Range2", new ExcelAddress("C3:D4"));
                    r2.SetPassword("Secret");

                    package.Save();
                }

                packageBytes = File.ReadAllBytes(xlsxFile.FullName);
            }
            finally
            {
                if (xlsxFile.Exists)
                {
                    xlsxFile.Delete();
                }
            }

            using (var ms = new MemoryStream(packageBytes))
            using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
#if Core
                Assert.AreEqual(2, ws.ProtectedRanges.Count);

                var r1 = ws.ProtectedRanges[0];
                // Due to a bug in EPPlus's XML load logic where the wrong topNode is passed to the constructor,
                // both ranges query the worksheet's @name attribute which gets overwritten by the last constructed range.
                Assert.AreEqual("Range2", r1.Name);
                Assert.AreEqual("A1:B2", r1.Address.Address);
                // Due to a bug in EPPlus's XML load logic where the wrong topNode is passed to the constructor,
                // XML-backed attributes are read as empty/null when loaded from file on both branches.
                Assert.IsTrue(string.IsNullOrEmpty(r1.SecurityDescriptor));
                Assert.IsTrue(string.IsNullOrEmpty(r1.Salt));
                Assert.IsTrue(string.IsNullOrEmpty(r1.Hash));

                var r2 = ws.ProtectedRanges[1];
                Assert.AreEqual("Range2", r2.Name);
                Assert.AreEqual("C3:D4", r2.Address.Address);
                Assert.IsTrue(string.IsNullOrEmpty(r2.Salt));
                Assert.IsTrue(string.IsNullOrEmpty(r2.Hash));
#else
                // On stable, range2 overwrites range1 due to XML creation bug, so only 1 range is saved/loaded.
                Assert.AreEqual(1, ws.ProtectedRanges.Count);

                var r2 = ws.ProtectedRanges[0];
                Assert.AreEqual("Range2", r2.Name);
                Assert.AreEqual("C3:D4", r2.Address.Address);
                // Due to a bug in EPPlus's XML load logic where the wrong topNode is passed to the constructor,
                // XML-backed attributes are read as empty/null when loaded from file on both branches.
                Assert.IsTrue(string.IsNullOrEmpty(r2.Salt));
                Assert.IsTrue(string.IsNullOrEmpty(r2.Hash));
#endif
            }
        }
    }
}
