using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Zlib;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class ParallelDeflateOutputStreamTest
    {
        [TestMethod]
        public void TestParallelDeflateBasic()
        {
            byte[] data = new byte[10 * 1024]; // 1MB
            new Random().NextBytes(data);

            using (var ms = new MemoryStream())
            {
                using (var pdos = new ParallelDeflateOutputStream(ms, true))
                {
                    pdos.Write(data, 0, data.Length);
                }

                ms.Position = 0;
                using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
                using (var resultMs = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int read;
                    while ((read = ds.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        resultMs.Write(buffer, 0, read);
                    }

                    byte[] result = resultMs.ToArray();
                    CollectionAssert.AreEqual(data, result);
                }
            }
        }

        [TestMethod]
        public void TestParallelDeflateLeaveOpen()
        {
            var ms = new MemoryStream();
            using (var pdos = new ParallelDeflateOutputStream(ms, true))
            {
                pdos.Write(new byte[] { 1, 2, 3 }, 0, 3);
            }
            // Should still be able to access ms
            Assert.IsTrue(ms.CanWrite);
            ms.Dispose();
        }

        [TestMethod]
        public void TestParallelDeflateClose()
        {
            var ms = new MemoryStream();
            var pdos = new ParallelDeflateOutputStream(ms, false);
            pdos.Write(new byte[] { 1, 2, 3 }, 0, 3);
            pdos.Close();

            // ms should be closed
            try
            {
                ms.Write(new byte[] { 0 }, 0, 1);
                Assert.Fail("MemoryStream should be closed");
            }
            catch (ObjectDisposedException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void TestParallelDeflateFlush()
        {
            byte[] data = new byte[100 * 1024]; // 100KB
            new Random().NextBytes(data);

            using (var ms = new MemoryStream())
            {
                using (var pdos = new ParallelDeflateOutputStream(ms, true))
                {
                    pdos.Write(data, 0, data.Length);
                    pdos.Flush();
                }

                ms.Position = 0;
                using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
                using (var resultMs = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int read;
                    while ((read = ds.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        resultMs.Write(buffer, 0, read);
                    }
                    byte[] result = resultMs.ToArray();
                    CollectionAssert.AreEqual(data, result);
                }
            }
        }
    }
}
