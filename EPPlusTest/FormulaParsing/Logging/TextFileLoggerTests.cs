using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Logging;

namespace EPPlusTest.FormulaParsing.Logging
{
    [TestClass]
    public class TextFileLoggerTests
    {
        private string _logFile = "test_log.txt";

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_logFile))
            {
                File.Delete(_logFile);
            }
        }

        private IDisposable CreateLogger(FileInfo fileInfo)
        {
            var type = typeof(IFormulaParserLogger).Assembly.GetType("OfficeOpenXml.FormulaParsing.Logging.TextFileLogger");
            return (IDisposable)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new object[] { fileInfo }, null);
        }

        private void Log(IDisposable logger, string message)
        {
            var method = logger.GetType().GetMethod("Log", new[] { typeof(string) });
            method.Invoke(logger, new object[] { message });
        }

        [TestMethod]
        public void ShouldWriteToLogFile()
        {
            var fileInfo = new FileInfo(_logFile);
            using (var logger = CreateLogger(fileInfo))
            {
                Log(logger, "test message");
            }

            Assert.IsTrue(File.Exists(_logFile));
            var content = File.ReadAllText(_logFile);
            Assert.IsTrue(content.Contains("test message"));
        }

        [TestMethod]
        public void ShouldHandleExistingLogFile()
        {
            File.WriteAllText(_logFile, "initial content");

            var fileInfo = new FileInfo(_logFile);
            using (var logger = CreateLogger(fileInfo))
            {
                Log(logger, "new message");
            }

            var content = File.ReadAllText(_logFile);
        #if (Core)
            Assert.IsTrue(content.Contains("initial content"), "Log file should have been appended in Core");
        #else
            Assert.IsFalse(content.Contains("initial content"), "Log file should have been overwritten in stable");
        #endif
            Assert.IsTrue(content.Contains("new message"));
        }
    }
}
