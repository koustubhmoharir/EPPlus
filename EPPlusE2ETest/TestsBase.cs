#nullable enable
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    public abstract class TestsBase
    {
        static TestsBase()
        {
            ProjectRoot = LocateProjectRoot();
            TemplatesDirectory = Path.Combine(ProjectRoot, "Templates");
            TempDirectory = Path.Combine(ProjectRoot, "Temp");
            OutputsDirectory = Path.Combine(ProjectRoot, "Outputs");
            Directory.CreateDirectory(TemplatesDirectory);
            Directory.CreateDirectory(OutputsDirectory);
        }
        public static readonly string ProjectRoot;
        public static readonly string TemplatesDirectory;
        public static readonly string TempDirectory;
        public static readonly string OutputsDirectory;

        private static string LocateProjectRoot()
        {
            var directory = new DirectoryInfo(AppContext.BaseDirectory);

            while (directory != null)
            {
                if (File.Exists(Path.Combine(directory.FullName, "EPPlus.sln")) ||
                    File.Exists(Path.Combine(directory.FullName, "EPPlusE2ETest.csproj")))
                {
                    return directory.FullName;
                }

                directory = directory.Parent;
            }

            throw new InvalidOperationException("Unable to locate the project root.");
        }

        protected static void SaveTemplate(string fileName, Action<ExcelPackage> write)
        {
            string path = Path.Combine(TemplatesDirectory, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var package = new ExcelPackage(tempFolder: TempDirectory))
            {
                write(package);
                package.SaveAs(new FileInfo(path));
            }
        }

        protected static void Test(string templateName, string? templatePassword, string outputName, string? outputPassword, Action<ExcelPackage> write, Action<ExcelPackage> verify)
        {
            string templatePath = Path.Combine(TemplatesDirectory, templateName);
            var outputPath = Path.Combine(OutputsDirectory, outputName);

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            using (var package = new ExcelPackage(new FileInfo(templatePath), templatePassword, TempDirectory))
            {
                write(package);
                package.SaveAs(new FileInfo(outputPath), outputPassword);
            }

            using (var package = new ExcelPackage(new FileInfo(outputPath), outputPassword, TempDirectory))
            {
                verify(package);
            }
        }
    }
}
