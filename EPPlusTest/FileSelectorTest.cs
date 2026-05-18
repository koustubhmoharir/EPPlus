using System;
using System.IO;
using System.Reflection;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPPlusTest
{
    [TestClass]
    public class FileSelectorTest
    {
        private static Type FileSelectorType;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var assembly = Assembly.Load("EPPlus");
            FileSelectorType = assembly.GetType("OfficeOpenXml.Packaging.Ionic.FileSelector");
            if (FileSelectorType == null)
            {
                throw new Exception("Could not find type OfficeOpenXml.Packaging.Ionic.FileSelector in EPPlus assembly");
            }
        }

        private object CreateFileSelector(string criteria)
        {
            return Activator.CreateInstance(FileSelectorType, new object[] { criteria });
        }

        private ICollection SelectFiles(object selector, string directory, bool recurse)
        {
            var method = FileSelectorType.GetMethod("SelectFiles", new Type[] { typeof(string), typeof(bool) });
            if (method == null)
            {
                throw new Exception("Could not find method SelectFiles(string, bool) on FileSelector");
            }
            return (ICollection)method.Invoke(selector, new object[] { directory, recurse });
        }

        [TestMethod]
        public void TestFileSelectorSimpleName()
        {
            var selector = CreateFileSelector("name = '*.txt'");
            Assert.AreEqual("FileSelector(name = '*.txt')", selector.ToString());
        }

        [TestMethod]
        public void TestFileSelectorSizeSuffixes()
        {
            // Test K / KB
            var selectorK = CreateFileSelector("size > 100K");
            Assert.AreEqual("FileSelector(size > 102400)", selectorK.ToString());

            var selectorKB = CreateFileSelector("size >= 100KB");
            Assert.AreEqual("FileSelector(size >= 102400)", selectorKB.ToString());

            var selectorK_lower = CreateFileSelector("size > 100k");
            Assert.AreEqual("FileSelector(size > 102400)", selectorK_lower.ToString());

            var selectorKB_lower = CreateFileSelector("size >= 100kb");
            Assert.AreEqual("FileSelector(size >= 102400)", selectorKB_lower.ToString());

            // Test M / MB
            var selectorM = CreateFileSelector("size < 2M");
            Assert.AreEqual("FileSelector(size < 2097152)", selectorM.ToString());

            var selectorMB = CreateFileSelector("size <= 2MB");
            Assert.AreEqual("FileSelector(size <= 2097152)", selectorMB.ToString());

            var selectorM_lower = CreateFileSelector("size < 2m");
            Assert.AreEqual("FileSelector(size < 2097152)", selectorM_lower.ToString());

            var selectorMB_lower = CreateFileSelector("size <= 2mb");
            Assert.AreEqual("FileSelector(size <= 2097152)", selectorMB_lower.ToString());

            // Test G / GB
            var selectorG = CreateFileSelector("size = 3G");
            Assert.AreEqual("FileSelector(size = 3221225472)", selectorG.ToString());

            var selectorGB = CreateFileSelector("size != 3GB");
            Assert.AreEqual("FileSelector(size != 3221225472)", selectorGB.ToString());

            var selectorG_lower = CreateFileSelector("size = 3g");
            Assert.AreEqual("FileSelector(size = 3221225472)", selectorG_lower.ToString());

            var selectorGB_lower = CreateFileSelector("size != 3gb");
            Assert.AreEqual("FileSelector(size != 3221225472)", selectorGB_lower.ToString());
        }

        [TestMethod]
        public void TestFileSelectorComplexCriteria()
        {
            var selector1 = CreateFileSelector("(name = '*.txt') and (size > 100k)");
            Assert.AreEqual("FileSelector((name = '*.txt' AND size > 102400))", selector1.ToString());

            var selector2 = CreateFileSelector("((name = '*.txt') or (size > 100kb))");
            Assert.AreEqual("FileSelector((name = '*.txt' OR size > 102400))", selector2.ToString());

            var selector3 = CreateFileSelector("name = 'some file.txt'");
            Assert.AreEqual("FileSelector(name = 'some file.txt')", selector3.ToString());
        }

        [TestMethod]
        public void TestFileSelectorEvaluate()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), "FileSelectorTest_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);

            try
            {
                var txtFile = Path.Combine(tempDir, "test.txt");
                var docFile = Path.Combine(tempDir, "test.doc");
                var spaceFile = Path.Combine(tempDir, "test space.txt");

                File.WriteAllBytes(txtFile, new byte[500]); // 500 bytes
                File.WriteAllBytes(docFile, new byte[150000]); // ~150KB
                File.WriteAllBytes(spaceFile, new byte[100]); // 100 bytes

                // Test Name criterion
                var selectorName = CreateFileSelector("name = *.txt");
                var matchedName = SelectFiles(selectorName, tempDir, false);
                Assert.AreEqual(2, matchedName.Count);
                
                bool foundTxt = false, foundSpace = false;
                foreach (string file in matchedName)
                {
                    if (file == txtFile) foundTxt = true;
                    if (file == spaceFile) foundSpace = true;
                }
                Assert.IsTrue(foundTxt);
                Assert.IsTrue(foundSpace);

                // Test Name criterion with spaces (single quotes)
                var selectorSpace = CreateFileSelector("name = 'test space.txt'");
                var matchedSpace = SelectFiles(selectorSpace, tempDir, false);
                Assert.AreEqual(1, matchedSpace.Count);
                
                bool foundSpaceOnly = false;
                foreach (string file in matchedSpace)
                {
                    if (file == spaceFile) foundSpaceOnly = true;
                }
                Assert.IsTrue(foundSpaceOnly);

                // Test Size criterion
                var selectorSize = CreateFileSelector("size > 100k");
                var matchedSize = SelectFiles(selectorSize, tempDir, false);
                Assert.AreEqual(1, matchedSize.Count);
                
                bool foundDoc = false;
                foreach (string file in matchedSize)
                {
                    if (file == docFile) foundDoc = true;
                }
                Assert.IsTrue(foundDoc);

                // Test Compound criterion
                var selectorCompound = CreateFileSelector("name = *.txt and size < 1k");
                var matchedCompound = SelectFiles(selectorCompound, tempDir, false);
                Assert.AreEqual(2, matchedCompound.Count);
                
                bool foundTxtC = false, foundSpaceC = false;
                foreach (string file in matchedCompound)
                {
                    if (file == txtFile) foundTxtC = true;
                    if (file == spaceFile) foundSpaceC = true;
                }
                Assert.IsTrue(foundTxtC);
                Assert.IsTrue(foundSpaceC);
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }
    }
}
