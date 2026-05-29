using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Zlib;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class ZlibCodecTest
    {
        [TestMethod]
        public void ZlibCodec_CompressDecompress_Succeeds()
        {
            string text = "This is a test string for ZlibCodec compression and decompression. It should be long enough to actually benefit from compression, though that's not strictly necessary for verification. Let's add some more text to be sure.";
            byte[] input = Encoding.UTF8.GetBytes(text);

            // Compress
            ZlibCodec compressor = new ZlibCodec(CompressionMode.Compress);
            byte[] compressed = new byte[input.Length * 2];
            compressor.InputBuffer = input;
            compressor.AvailableBytesIn = input.Length;
            compressor.NextIn = 0;
            compressor.OutputBuffer = compressed;
            compressor.AvailableBytesOut = compressed.Length;
            compressor.NextOut = 0;

            int rc = compressor.Deflate(FlushType.Finish);
            Assert.AreEqual(ZlibConstants.Z_STREAM_END, rc);
            int compressedSize = (int)compressor.TotalBytesOut;
            compressor.EndDeflate();

            // Decompress
            ZlibCodec decompressor = new ZlibCodec(CompressionMode.Decompress);
            byte[] decompressed = new byte[input.Length];
            decompressor.InputBuffer = compressed;
            decompressor.AvailableBytesIn = compressedSize;
            decompressor.NextIn = 0;
            decompressor.OutputBuffer = decompressed;
            decompressor.AvailableBytesOut = decompressed.Length;
            decompressor.NextOut = 0;

            rc = decompressor.Inflate(FlushType.Finish);
            Assert.AreEqual(ZlibConstants.Z_STREAM_END, rc);
            decompressor.EndInflate();

            string result = Encoding.UTF8.GetString(decompressed);
            Assert.AreEqual(text, result);
        }

        [TestMethod]
        public void ZlibCodec_Initialize_PropertiesSet()
        {
            ZlibCodec codec = new ZlibCodec();
            codec.CompressLevel = CompressionLevel.BestCompression;
            codec.WindowBits = 12;
            codec.Strategy = CompressionStrategy.Filtered;

            Assert.AreEqual(CompressionLevel.BestCompression, codec.CompressLevel);
            Assert.AreEqual(12, codec.WindowBits);
            Assert.AreEqual(CompressionStrategy.Filtered, codec.Strategy);
        }

        [TestMethod]
        public void ZlibCodec_VariousInitializers_Succeed()
        {
            ZlibCodec codec = new ZlibCodec();
            codec.InitializeInflate(true);
            codec.InitializeInflate(15);
            codec.InitializeInflate(15, false);

            codec = new ZlibCodec();
            codec.InitializeDeflate(CompressionLevel.BestSpeed);
            codec.InitializeDeflate(CompressionLevel.Default, true);
            codec.InitializeDeflate(CompressionLevel.Level1, 15);
            codec.InitializeDeflate(CompressionLevel.Level5, 12, false);

            codec.ResetDeflate();
            codec.SetDeflateParams(CompressionLevel.Default, CompressionStrategy.Default);
        }
    }
}
