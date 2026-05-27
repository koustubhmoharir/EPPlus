using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.VBA;

namespace EPPlusTest
{
    [TestClass]
    public class VBACollectionTest
    {
        [TestMethod]
        public void VBACollection_Indexer_ReturnsModule()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.CreateVBAProject();
                var moduleName = "TestModule";
                package.Workbook.VbaProject.Modules.AddModule(moduleName);

                var module = package.Workbook.VbaProject.Modules[moduleName];
                Assert.IsNotNull(module);
                Assert.AreEqual(moduleName, module.Name);
            }
        }

        [TestMethod]
        public void VBACollection_Indexer_IsCaseInsensitive()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.CreateVBAProject();
                var moduleName = "TestModule";
                package.Workbook.VbaProject.Modules.AddModule(moduleName);

                var module = package.Workbook.VbaProject.Modules[moduleName.ToLower()];
                Assert.IsNotNull(module);
                Assert.AreEqual(moduleName, module.Name);
            }
        }

        [TestMethod]
        public void VBACollection_Exists_ReturnsTrue()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.CreateVBAProject();
                var moduleName = "TestModule";
                package.Workbook.VbaProject.Modules.AddModule(moduleName);

                Assert.IsTrue(package.Workbook.VbaProject.Modules.Exists(moduleName));
                Assert.IsTrue(package.Workbook.VbaProject.Modules.Exists(moduleName.ToUpper()));
            }
        }

        [TestMethod]
        public void VBACollection_ReferenceIndexer_ReturnsReference()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.CreateVBAProject();
                var refName = "TestRef";
                var reference = new ExcelVbaReference();
                reference.Name = refName;
                reference.Libid = "test-libid";
                package.Workbook.VbaProject.References.Add(reference);

                Assert.IsTrue(package.Workbook.VbaProject.References.Exists(refName));
                var retrieved = package.Workbook.VbaProject.References[refName];
                Assert.IsNotNull(retrieved);
                Assert.AreEqual(refName, retrieved.Name);
            }
        }
    }
}
