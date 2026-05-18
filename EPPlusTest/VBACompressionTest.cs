using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Utils;

namespace EPPlusTest
{
    [TestClass]
    public class VBACompressionTest
    {
        [TestInitialize]
        public void Initialize()
        {
#if Core
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
        }

        [TestMethod]
        public void VBA_CompressionDecompression_Parity()
        {
            // Test with a string that has repeatable patterns (good for compression)
            string value = "#aaabcdefaaaaghijaaaaaklaaamnopqaaaaaaaaaaaarstuvwxyzaaa";
            var encoding = Encoding.GetEncoding(1252);
            byte[] rawData = encoding.GetBytes(value);

#if Core
            byte[] compValue = OfficeOpenXml.Utils.VBACompression.CompressPart(rawData);
            byte[] decompValue = OfficeOpenXml.Utils.VBACompression.DecompressPart(compValue);
#else
            byte[] compValue = CompoundDocument.CompressPart(rawData);
            byte[] decompValue = CompoundDocument.DecompressPart(compValue);
#endif
            string result = encoding.GetString(decompValue);
            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void VBA_CompressionDecompression_LargeBuffer()
        {
            // Test with a larger string to hit multiple chunks
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb.Append("This is a test of the VBA compression algorithm. It should handle multiple chunks correctly. ");
            }
            string value = sb.ToString();
            var encoding = Encoding.GetEncoding(1252);
            byte[] rawData = encoding.GetBytes(value);

#if Core
            byte[] compValue = OfficeOpenXml.Utils.VBACompression.CompressPart(rawData);
            byte[] decompValue = OfficeOpenXml.Utils.VBACompression.DecompressPart(compValue);
#else
            byte[] compValue = CompoundDocument.CompressPart(rawData);
            byte[] decompValue = CompoundDocument.DecompressPart(compValue);
#endif
            string result = encoding.GetString(decompValue);
            Assert.AreEqual(value, result);
        }
    }
}
