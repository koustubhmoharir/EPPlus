using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Crc;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class ZipEntryTest
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [TestMethod]
        public void ZipEntry_Constructor_SetsExpectedDefaults()
        {
            var entry = new ZipEntry();

            Assert.IsNotNull(entry.AlternateEncoding);
            Assert.AreEqual(437, entry.AlternateEncoding.CodePage);
            Assert.AreEqual(ZipOption.Never, entry.AlternateEncodingUsage);
            Assert.IsFalse(entry.DontEmitLastModified);
        }

        [TestMethod]
        public void ZipEntry_DontEmitLastModified_RoundTrips()
        {
            var entry = new ZipEntry();

            entry.DontEmitLastModified = true;
            Assert.IsTrue(entry.DontEmitLastModified);

            entry.DontEmitLastModified = false;
            Assert.IsFalse(entry.DontEmitLastModified);
        }

        [TestMethod]
        public void ZipEntry_TypeAttributes_ArePresent()
        {
            var type = typeof(ZipEntry);

            var guidAttribute = (GuidAttribute)Attribute.GetCustomAttribute(type, typeof(GuidAttribute));
            var comVisibleAttribute = (ComVisibleAttribute)Attribute.GetCustomAttribute(type, typeof(ComVisibleAttribute));
            var classInterfaceAttribute = (ClassInterfaceAttribute)Attribute.GetCustomAttribute(type, typeof(ClassInterfaceAttribute));

            Assert.IsNotNull(guidAttribute);
            Assert.AreEqual("ebc25cf6-9120-4283-b972-0e5520d00004", guidAttribute.Value);
            Assert.IsNotNull(comVisibleAttribute);
            Assert.IsTrue(comVisibleAttribute.Value);
            Assert.IsNotNull(classInterfaceAttribute);
            Assert.AreEqual(ClassInterfaceType.AutoDispatch, classInterfaceAttribute.Value);
        }

        [TestMethod]
        public void ZipEntry_ReadEntry_ParsesExtendedTimestampExtraField()
        {
            var expectedModifiedTime = new DateTime(2001, 2, 3, 4, 5, 6, DateTimeKind.Utc);
            var archive = CreateEntryArchive(
                "timestamp.txt",
                new byte[] { 10, 20, 30, 40, 50 },
                CreateExtendedTimestampExtraField(expectedModifiedTime),
                includeDataDescriptor: false);

            var entry = ReadEntry(archive);

            Assert.AreEqual("timestamp.txt", entry.FileName);
            Assert.AreEqual(expectedModifiedTime, entry.ModifiedTime);
            Assert.AreEqual(5L, GetPrivateField<long>(entry, "_CompressedFileDataSize"));
            Assert.AreEqual(0, GetPrivateField<int>(entry, "_LengthOfTrailer"));
        }

        [TestMethod]
        public void ZipEntry_ReadEntry_WithFalsePositiveDescriptorSignature_AccumulatesTrailerLength()
        {
            var expectedModifiedTime = new DateTime(2001, 2, 3, 4, 5, 6, DateTimeKind.Utc);
            var data = new byte[70000];
            data[100] = 0x50;
            data[101] = 0x4b;
            data[102] = 0x07;
            data[103] = 0x08;
            var archive = CreateEntryArchive(
                "descriptor.txt",
                data,
                CreateExtendedTimestampExtraField(expectedModifiedTime),
                includeDataDescriptor: true);

            var entry = ReadEntry(archive);

            Assert.AreEqual("descriptor.txt", entry.FileName);
            Assert.AreEqual(expectedModifiedTime, entry.ModifiedTime);
            Assert.AreEqual(70000L, GetPrivateField<long>(entry, "_CompressedFileDataSize"));
            Assert.AreEqual(16, GetPrivateField<int>(entry, "_LengthOfTrailer"));
        }

        private static ZipEntry ReadEntry(byte[] archiveBytes)
        {
            using (var stream = new MemoryStream(archiveBytes))
            using (var input = new Ionic.Zip.ZipInputStream(stream))
            {
                var entry = ZipEntry.ReadEntry(new ZipContainer(input), true);
                Assert.IsNotNull(entry);
                return entry;
            }
        }

        private static byte[] CreateEntryArchive(string fileName, byte[] data, byte[] extraField, bool includeDataDescriptor)
        {
            using (var stream = new MemoryStream())
            {
                var fileNameBytes = System.Text.Encoding.ASCII.GetBytes(fileName);
                var crc = new CRC32().GetCrc32(new MemoryStream(data));

                WriteUInt32(stream, 0x04034b50);
                WriteUInt16(stream, 20);
                WriteUInt16(stream, (ushort)(includeDataDescriptor ? 0x0008 : 0x0000));
                WriteUInt16(stream, 0);
                WriteUInt16(stream, 0);
                WriteUInt16(stream, 0);
                WriteUInt32(stream, includeDataDescriptor ? 0u : unchecked((uint)crc));
                WriteUInt32(stream, includeDataDescriptor ? 0u : (uint)data.Length);
                WriteUInt32(stream, includeDataDescriptor ? 0u : (uint)data.Length);
                WriteUInt16(stream, (ushort)fileNameBytes.Length);
                WriteUInt16(stream, (ushort)extraField.Length);
                stream.Write(fileNameBytes, 0, fileNameBytes.Length);
                stream.Write(extraField, 0, extraField.Length);
                stream.Write(data, 0, data.Length);

                if (includeDataDescriptor)
                {
                    WriteUInt32(stream, 0x08074b50);
                    WriteUInt32(stream, unchecked((uint)crc));
                    WriteUInt32(stream, (uint)data.Length);
                    WriteUInt32(stream, (uint)data.Length);
                }

                WriteUInt32(stream, 0x02014b50);
                stream.Write(new byte[64], 0, 64);
                return stream.ToArray();
            }
        }

        private static byte[] CreateExtendedTimestampExtraField(DateTime modifiedTime)
        {
            var unixSeconds = (int)(modifiedTime.ToUniversalTime() - UnixEpoch).TotalSeconds;
            using (var stream = new MemoryStream())
            {
                WriteUInt16(stream, 0x5455);
                WriteUInt16(stream, 13);
                stream.WriteByte(0x07);
                WriteInt32(stream, unixSeconds);
                WriteInt32(stream, unixSeconds);
                WriteInt32(stream, unixSeconds);
                return stream.ToArray();
            }
        }

        private static void WriteUInt16(Stream stream, ushort value)
        {
            var bytes = BitConverter.GetBytes(value);
            stream.Write(bytes, 0, bytes.Length);
        }

        private static void WriteUInt32(Stream stream, uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            stream.Write(bytes, 0, bytes.Length);
        }

        private static void WriteInt32(Stream stream, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            stream.Write(bytes, 0, bytes.Length);
        }

        private static T GetPrivateField<T>(object instance, string fieldName)
        {
            var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field, fieldName);
            return (T)field.GetValue(instance);
        }
    }
}
