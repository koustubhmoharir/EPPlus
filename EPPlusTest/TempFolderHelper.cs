using System;
using System.IO;

namespace EPPlusTest
{
    internal static class TempFolderHelper
    {
        public static string Create()
        {
            return Path.Combine(Path.GetTempPath(), "EPPlus", "ExcelPackage", Guid.NewGuid().ToString("N"));
        }
    }
}
