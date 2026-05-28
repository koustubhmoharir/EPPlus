using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System.IO;
using System.Reflection;

namespace EPPlusTest
{
    [TestClass]
    public abstract class TestBase
    {
        protected ExcelPackage _pck;
        protected string _clipartPath="";
        protected string _worksheetPath= Path.Combine(Path.GetTempPath(), "EPPlus", "Testoutput");
        protected string _testInputPath = Path.Combine(Path.GetTempPath(), "EPPlus", "workbooks");
        public TestContext TestContext { get; set; }

        public static string GetBaseDirectory()
        {
#if Core
            return AppContext.BaseDirectory;
#else
            return AppDomain.CurrentDomain.BaseDirectory;
#endif
        }

        public static string GetProjectRootDirectory()
        {
#if Core
            return Directory.GetParent(GetBaseDirectory()).Parent.Parent.Parent.FullName;
#else
            return GetBaseDirectory();
#endif
        }

        [TestInitialize]
        public void InitBase()
        {
            _clipartPath = Path.Combine(Path.GetTempPath(), "EPPlus", "clipart");
            if (!Directory.Exists(_clipartPath))
            {
                Directory.CreateDirectory(_clipartPath);
            }
            if (!Directory.Exists(_worksheetPath))
            {
                Directory.CreateDirectory(_worksheetPath);
            }
            if (!Directory.Exists(_testInputPath))
            {
                Directory.CreateDirectory(_testInputPath);
            }
            _worksheetPath += Path.DirectorySeparatorChar;
            _testInputPath += Path.DirectorySeparatorChar;

            if(Environment.GetEnvironmentVariable("EPPlusTestInputPath")!=null)
            {
                _testInputPath = Environment.GetEnvironmentVariable("EPPlusTestInputPath");
            }
            var asm = Assembly.GetExecutingAssembly();
            var validExtensions = new[]
                {
                    ".gif", ".wmf"
                };

            foreach (var name in asm.GetManifestResourceNames())
            {
                foreach (var ext in validExtensions)
                {
                    if (name.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                    {
                        string fileName = name.Replace("EPPlusTest.Resources.", "");
                        using (var stream = asm.GetManifestResourceStream(name))
                        using (var file = File.Create(Path.Combine(_clipartPath, fileName)))
                        {
                            stream.CopyTo(file);
                        }
                        break;
                    }
                }
            }
            
            //_worksheetPath = Path.Combine(Path.GetTempPath(), @"EPPlus worksheets");
            //if (!Directory.Exists(_worksheetPath))
            //{
            //    Directory.CreateDirectory(_worksheetPath);
            //}

            _pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create());
        }

        protected ExcelPackage OpenPackage(string name, bool delete=false)
        {
            var fi = new FileInfo(_worksheetPath + name);
            if(delete && fi.Exists)
            {
                fi.Delete();
            }
            _pck = new ExcelPackage(fi, EPPlusTest.TempFolderHelper.Create());
            return _pck;
        }
        protected ExcelPackage OpenTemplatePackage(string name)
        {
            var t = new FileInfo(_testInputPath + name);
            if (t.Exists)
            {
                var fi = new FileInfo(_worksheetPath + name);
                _pck = new ExcelPackage(fi, t, EPPlusTest.TempFolderHelper.Create());
            }
            else
            {
                Assert.Inconclusive($"Template {name} does not exist in path {_testInputPath}");
            }
            return _pck;
        }

        protected void SaveWorksheet(string name)
        {
            if (_pck.Workbook.Worksheets.Count == 0) return;
            var fi = new FileInfo(_worksheetPath + name);
            if (fi.Exists)
            {
                fi.Delete();
            }
            _pck.SaveAs(fi);
        }
    }
}
