using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Crc;

namespace EPPlusTest
{
    [TestClass]
    public class Crc32Test
    {
        [TestMethod]
        public void TestCrc32BasicCalculations()
        {
            var crc = new CRC32();
            Assert.AreEqual(0, crc.TotalBytesRead);
            Assert.AreEqual(0, crc.Crc32Result);

            byte[] data = new byte[] { 1, 2, 3, 4, 5 };
            crc.SlurpBlock(data, 0, data.Length);
            Assert.AreEqual(data.Length, crc.TotalBytesRead);
            Assert.AreNotEqual(0, crc.Crc32Result);

            crc.Reset();
            Assert.AreEqual(0, crc.Crc32Result);
        }

        [TestMethod]
        public void TestCrc32NullInputs()
        {
            var crc = new CRC32();
            Assert.ThrowsException<Exception>(() => crc.SlurpBlock(null, 0, 0));
            Assert.ThrowsException<Exception>(() => crc.GetCrc32(null));
            Assert.ThrowsException<Exception>(() => crc.GetCrc32AndCopy(null, new MemoryStream()));
        }

        [TestMethod]
        public void TestCrc32GetCrc32AndCopy()
        {
            var crc = new CRC32();
            byte[] data = new byte[] { 65, 66, 67, 68 }; // "ABCD"
            using (var input = new MemoryStream(data))
            using (var output = new MemoryStream())
            {
                var result = crc.GetCrc32AndCopy(input, output);
                Assert.AreEqual(data.Length * 2, crc.TotalBytesRead);
                Assert.AreEqual(result, crc.Crc32Result);
                
                // Verify output stream has the same data
                byte[] written = output.ToArray();
                CollectionAssert.AreEqual(data, written);
            }

            // Test with null output stream
            crc.Reset();
            using (var input = new MemoryStream(data))
            {
                var result = crc.GetCrc32(input);
                Assert.AreEqual(result, crc.Crc32Result);
            }
        }

        [TestMethod]
        public void TestCrc32ComputeCrc32()
        {
            var crc = new CRC32();
            int result = crc.ComputeCrc32(12345, 67);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestCrc32UpdateCrc()
        {
            var crc = new CRC32();
            crc.UpdateCRC(65); // 'A'
            var singleResult = crc.Crc32Result;

            crc.Reset();
            crc.UpdateCRC(65, 1);
            var repeatedResult = crc.Crc32Result;

            Assert.AreEqual(singleResult, repeatedResult);

            crc.Reset();
            crc.UpdateCRC(65, 3);
            Assert.AreNotEqual(singleResult, crc.Crc32Result);
        }

        [TestMethod]
        public void TestCrc32ReverseBits()
        {
            // Test constructor with reverseBits = true
            var crcReverse = new CRC32(true);
            byte[] data = new byte[] { 10, 20, 30 };
            crcReverse.SlurpBlock(data, 0, data.Length);
            var resReverse = crcReverse.Crc32Result;

            var crcNormal = new CRC32(false);
            crcNormal.SlurpBlock(data, 0, data.Length);
            var resNormal = crcNormal.Crc32Result;

            Assert.AreNotEqual(resReverse, resNormal);

            // Test custom polynomial
            var crcCustom = new CRC32(0x04C11DB7, true);
            crcCustom.SlurpBlock(data, 0, data.Length);
            Assert.AreNotEqual(resReverse, crcCustom.Crc32Result);
        }

        [TestMethod]
        public void TestCrc32Combine()
        {
            var crc1 = new CRC32();
            var crc2 = new CRC32();

            byte[] part1 = new byte[] { 1, 2, 3 };
            byte[] part2 = new byte[] { 4, 5, 6, 7 };

            crc1.SlurpBlock(part1, 0, part1.Length);
            crc2.SlurpBlock(part2, 0, part2.Length);

            var crcCombined = new CRC32();
            crcCombined.SlurpBlock(part1, 0, part1.Length);
            crcCombined.Combine(crc2.Crc32Result, part2.Length);

            var crcFull = new CRC32();
            byte[] full = new byte[] { 1, 2, 3, 4, 5, 6, 7 };
            crcFull.SlurpBlock(full, 0, full.Length);

            Assert.AreEqual(crcFull.Crc32Result, crcCombined.Crc32Result);

            // Combine with length 0
            var beforeCombineLengthZero = crcCombined.Crc32Result;
            crcCombined.Combine(999, 0);
            Assert.AreEqual(beforeCombineLengthZero, crcCombined.Crc32Result);
        }

        [TestMethod]
        public void TestCrcCalculatorStreamConstructors()
        {
            using (var ms = new MemoryStream())
            {
                using (var s1 = new CrcCalculatorStream(ms))
                {
                    Assert.IsTrue(s1.LeaveOpen);
                }
                using (var s2 = new CrcCalculatorStream(ms, false))
                {
                    Assert.IsFalse(s2.LeaveOpen);
                }
                using (var s3 = new CrcCalculatorStream(ms, 100))
                {
                    Assert.AreEqual(100, s3.Length);
                }
                using (var s4 = new CrcCalculatorStream(ms, 50, true))
                {
                    Assert.AreEqual(50, s4.Length);
                    Assert.IsTrue(s4.LeaveOpen);
                }
                using (var s5 = new CrcCalculatorStream(ms, 20, false, new CRC32()))
                {
                    Assert.AreEqual(20, s5.Length);
                    Assert.IsFalse(s5.LeaveOpen);
                }

                // Invalid lengths
                Assert.ThrowsException<ArgumentException>(() => new CrcCalculatorStream(ms, -5));
                Assert.ThrowsException<ArgumentException>(() => new CrcCalculatorStream(ms, -1, true));
                Assert.ThrowsException<ArgumentException>(() => new CrcCalculatorStream(ms, -10, false, new CRC32()));
            }
        }

        [TestMethod]
        public void TestCrcCalculatorStreamReadWrite()
        {
            byte[] data = new byte[] { 10, 20, 30, 40, 50 };
            using (var ms = new MemoryStream())
            {
                using (var writer = new CrcCalculatorStream(ms, true))
                {
                    Assert.IsTrue(writer.CanWrite);
                    Assert.IsFalse(writer.CanSeek);
                    writer.Write(data, 0, data.Length);
                    writer.Flush();
                    
                    Assert.AreEqual(data.Length, writer.TotalBytesSlurped);
                    Assert.AreNotEqual(0, writer.Crc);
                }

                ms.Position = 0;

                using (var reader = new CrcCalculatorStream(ms, true))
                {
                    Assert.IsTrue(reader.CanRead);
                    byte[] readBuffer = new byte[10];
                    int bytesRead = reader.Read(readBuffer, 0, readBuffer.Length);
                    Assert.AreEqual(data.Length, bytesRead);
                    Assert.AreEqual(data.Length, reader.TotalBytesSlurped);
                    
                    // Verify correct CRC is calculated during read
                    var expectedCrc = new CRC32();
                    expectedCrc.SlurpBlock(data, 0, data.Length);
                    Assert.AreEqual(expectedCrc.Crc32Result, reader.Crc);
                }
            }
        }

        [TestMethod]
        public void TestCrcCalculatorStreamLengthLimit()
        {
            byte[] data = new byte[] { 10, 20, 30, 40, 50 };
            using (var ms = new MemoryStream(data))
            {
                // Limit to 3 bytes
                using (var reader = new CrcCalculatorStream(ms, 3, true))
                {
                    byte[] readBuffer = new byte[10];
                    int bytesRead = reader.Read(readBuffer, 0, 10);
                    Assert.AreEqual(3, bytesRead);
                    
                    // Further reads should return 0 (EOF)
                    bytesRead = reader.Read(readBuffer, 0, 10);
                    Assert.AreEqual(0, bytesRead);
                }
            }
        }

        [TestMethod]
        public void TestCrcCalculatorStreamPropertiesAndUnsupportedMethods()
        {
            using (var ms = new MemoryStream())
            using (var stream = new CrcCalculatorStream(ms))
            {
                Assert.AreEqual(0, stream.Length);
                Assert.AreEqual(0, stream.Position);

                Assert.ThrowsException<NotSupportedException>(() => stream.Position = 10);
                Assert.ThrowsException<NotSupportedException>(() => stream.Seek(0, SeekOrigin.Begin));
                Assert.ThrowsException<NotSupportedException>(() => stream.SetLength(10));

                stream.LeaveOpen = true;
                Assert.IsTrue(stream.LeaveOpen);
                stream.LeaveOpen = false;
                Assert.IsFalse(stream.LeaveOpen);

                // Check IDisposable.Dispose
                ((IDisposable)stream).Dispose();
            }
        }
    }
}
