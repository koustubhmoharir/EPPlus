using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class ZipSegmentedStreamTest
    {
        private string _baseFileName;

        [TestInitialize]
        public void Setup()
        {
            _baseFileName = Path.Combine(Path.GetTempPath(), "ZipSegmentedStreamTest_TEST_ID.zip");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_baseFileName == null) return;
            var dir = Path.GetDirectoryName(_baseFileName);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(_baseFileName);
            var pattern = fileNameWithoutExtension + ".*";
            foreach (var file in Directory.GetFiles(dir, pattern))
            {
                try { File.Delete(file); } catch { }
            }
            try { File.Delete(_baseFileName); } catch { }
        }

        [TestMethod]
        public void ZipSegmentedStream_WriteAndRead_SpansSegments()
        {
            int segmentSize = 20; // 4 bytes for sig + 16 bytes payload
            using (var stream = ForWriting(_baseFileName, segmentSize))
            {
                byte[] data1 = new byte[16];
                for (int i = 0; i < 16; i++) data1[i] = (byte)i;
                stream.Write(data1, 0, 16);
                Assert.AreEqual(0u, GetCurrentSegment(stream));

                byte[] data2 = new byte[20];
                for (int i = 0; i < 20; i++) data2[i] = (byte)(i + 16);
                stream.Write(data2, 0, 20);
                Assert.AreEqual(1u, GetCurrentSegment(stream));

                byte[] data3 = new byte[10];
                for (int i = 0; i < 10; i++) data3[i] = (byte)(i + 36);
                stream.Write(data3, 0, 10);
                Assert.AreEqual(2u, GetCurrentSegment(stream));

                var tempName = (string)GetPrivateField(stream, "_currentTempName");
                stream.Dispose();
                if (File.Exists(tempName))
                {
                    File.Move(tempName, _baseFileName);
                }
            }

            using (var stream = ForReading(_baseFileName, 0, 3))
            {
                byte[] buffer = new byte[100];
                int read = stream.Read(buffer, 0, 100);
                Assert.AreEqual(50, read);

                Assert.AreEqual(0x50, buffer[0]);
                Assert.AreEqual(0x4B, buffer[1]);
                Assert.AreEqual(0x07, buffer[2]);
                Assert.AreEqual(0x08, buffer[3]);

                for (int i = 0; i < 16; i++) Assert.AreEqual((byte)i, buffer[i + 4]);
                for (int i = 0; i < 20; i++) Assert.AreEqual((byte)(i + 16), buffer[i + 20]);
                for (int i = 0; i < 10; i++) Assert.AreEqual((byte)(i + 36), buffer[i + 40]);
            }
        }

        [TestMethod]
        public void ZipSegmentedStream_Read_SpansMultipleSegments()
        {
            int segmentSize = 20;
            using (var stream = ForWriting(_baseFileName, segmentSize))
            {
                stream.Write(new byte[16], 0, 16); // Seg 0
                stream.Write(new byte[20], 0, 20); // Seg 1
                stream.Write(new byte[20], 0, 20); // Seg 2
                var tempName = (string)GetPrivateField(stream, "_currentTempName");
                stream.Dispose();
                if (File.Exists(tempName)) File.Move(tempName, _baseFileName);
            }

            using (var stream = ForReading(_baseFileName, 0, 3))
            {
                byte[] buffer = new byte[60];
                stream.Read(buffer, 0, 5);

                int read = stream.Read(buffer, 5, 30);
                Assert.AreEqual(30, read);
                Assert.AreEqual(1u, GetCurrentSegment(stream));

                read = stream.Read(buffer, 35, 25);
                Assert.AreEqual(25, read);
            }
        }

        [TestMethod]
        public void ZipSegmentedStream_TruncateBackward_RemovesInterveningSegments()
        {
            int segmentSize = 20;
            using (var stream = ForWriting(_baseFileName, segmentSize))
            {
                stream.Write(new byte[16], 0, 16); // Seg 0
                stream.Write(new byte[20], 0, 20); // Seg 1
                stream.Write(new byte[20], 0, 20); // Seg 2
                stream.Write(new byte[20], 0, 20); // Seg 3
                Assert.AreEqual(3u, GetCurrentSegment(stream));

                TruncateBackward(stream, 1, 10);
                Assert.AreEqual(1u, GetCurrentSegment(stream));
                Assert.AreEqual(10L, stream.Position);

                Assert.IsFalse(File.Exists(GetSegmentName(_baseFileName, 2)));
            }
        }

        [TestMethod]
        public void ZipSegmentedStream_ForUpdate_UpdatesSpecificSegment()
        {
            int segmentSize = 20;
            using (var stream = ForWriting(_baseFileName, segmentSize))
            {
                stream.Write(new byte[16], 0, 16); // Seg 0
                stream.Write(new byte[20], 0, 20); // Seg 1
                var tempName = (string)GetPrivateField(stream, "_currentTempName");
                stream.Dispose();
                if (File.Exists(tempName)) File.Move(tempName, _baseFileName);
            }

            string seg0Name = GetSegmentName(_baseFileName, 0);
            using (var updateStream = ForUpdate(_baseFileName, 0))
            {
                updateStream.Seek(4, SeekOrigin.Begin); // After sig
                updateStream.Write(new byte[] { 0xAA, 0xBB }, 0, 2);
            }

            using (var fs = File.OpenRead(seg0Name))
            {
                fs.Seek(4, SeekOrigin.Begin);
                Assert.AreEqual(0xAA, fs.ReadByte());
                Assert.AreEqual(0xBB, fs.ReadByte());
            }
        }

        [TestMethod]
        public void ZipSegmentedStream_99SegmentLimit()
        {
            try
            {
                using (var stream = ForWriting(_baseFileName, 10))
                {
                    SetPrivateField(stream, "_currentDiskNumber", 98u);
                    stream.Write(new byte[20], 0, 20);
                }
#if Core
                Assert.Fail("Should have thrown OverflowException on dotnetport");
#endif
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "OverflowException" || (ex.InnerException != null && ex.InnerException.GetType().Name == "OverflowException"))
                {
#if !Core
                    Assert.Fail("Should not have thrown OverflowException on stable");
#endif
                }
                else
                {
                    throw;
                }
            }
        }

        [TestMethod]
        public void ZipSegmentedStream_Properties_And_SimpleMethods()
        {
            using (var stream = ForWriting(_baseFileName, 100))
            {
                Assert.IsTrue(stream.CanWrite);
                Assert.IsTrue(stream.CanSeek);
                Assert.IsFalse(stream.CanRead);
                Assert.AreEqual(4L, stream.Length); // Sig is 4 bytes

                stream.Write(new byte[10], 0, 10);
                Assert.AreEqual(14L, stream.Length);
                Assert.AreEqual(14L, stream.Position);

                stream.Position = 4;
                Assert.AreEqual(4L, stream.Position);

                stream.Flush();

                stream.Seek(10, SeekOrigin.Begin);
                Assert.AreEqual(10L, stream.Position);

                stream.SetLength(20);
                Assert.AreEqual(20L, stream.Length);

                Assert.IsNotNull(GetPrivateProperty(stream, "CurrentTempName"));

                var computeMethod = stream.GetType().GetMethod("ComputeSegment", BindingFlags.Instance | BindingFlags.Public);
                uint nextSeg = (uint)computeMethod.Invoke(stream, new object[] { 200 });
                Assert.AreEqual(1u, nextSeg);

                var tempName = (string)GetPrivateField(stream, "_currentTempName");
                stream.Dispose();
                if (File.Exists(tempName)) File.Move(tempName, _baseFileName);
            }

            using (var stream = ForReading(_baseFileName, 0, 1))
            {
                Assert.IsTrue(stream.CanRead);
                Assert.IsFalse(stream.CanWrite);
            }
        }

        private static Stream ForWriting(string name, int maxSegmentSize)
        {
            var type = typeof(ZipSegmentedStream);
            var method = type.GetMethod("ForWriting", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(int) }, null);
            return (Stream)method.Invoke(null, new object[] { name, maxSegmentSize });
        }

        private static Stream ForReading(string name, uint initialDiskNumber, uint maxDiskNumber)
        {
            var type = typeof(ZipSegmentedStream);
            var method = type.GetMethod("ForReading", BindingFlags.Static | BindingFlags.Public);
            return (Stream)method.Invoke(null, new object[] { name, initialDiskNumber, maxDiskNumber });
        }

        private static Stream ForUpdate(string name, uint diskNumber)
        {
            var type = typeof(ZipSegmentedStream);
            var method = type.GetMethod("ForUpdate", BindingFlags.Static | BindingFlags.Public);
            return (Stream)method.Invoke(null, new object[] { name, diskNumber });
        }

        private static uint GetCurrentSegment(Stream stream)
        {
            return (uint)stream.GetType().GetProperty("CurrentSegment").GetValue(stream, null);
        }

        private static string GetSegmentName(string baseName, uint diskNumber)
        {
            return string.Format("{0}.z{1:D2}",
                Path.Combine(Path.GetDirectoryName(baseName), Path.GetFileNameWithoutExtension(baseName)),
                diskNumber + 1);
        }

        private static object GetPrivateField(object instance, string fieldName)
        {
            var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            return field.GetValue(instance);
        }

        private static void SetPrivateField(object instance, string fieldName, object value)
        {
            var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(instance, value);
        }

        private static object GetPrivateProperty(object instance, string propertyName)
        {
            var prop = instance.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return prop.GetValue(instance, null);
        }

        private static void TruncateBackward(Stream stream, uint diskNumber, long offset)
        {
            var method = stream.GetType().GetMethod("TruncateBackward", BindingFlags.Instance | BindingFlags.Public);
            method.Invoke(stream, new object[] { diskNumber, offset });
        }
    }
}
