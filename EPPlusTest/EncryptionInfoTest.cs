using System;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Encryption;

namespace EPPlusTest
{
    [TestClass]
    public class EncryptionInfoTest
    {
        private const string AgileXml = 
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n" +
            "<encryption xmlns=\"http://schemas.microsoft.com/office/2006/encryption\" xmlns:p=\"http://schemas.microsoft.com/office/2006/keyEncryptor/password\" xmlns:c=\"http://schemas.microsoft.com/office/2006/keyEncryptor/certificate\">\r\n" +
            "    <keyData saltSize=\"16\" blockSize=\"16\" keyBits=\"256\" hashSize=\"64\" cipherAlgorithm=\"AES\" cipherChaining=\"ChainingModeCBC\" hashAlgorithm=\"SHA512\" saltValue=\"pa+hrJ3s1zrY6hmVuSa5JQ==\" />\r\n" +
            "    <dataIntegrity encryptedHmacKey=\"nd8i4sEKjsMjVN2gLo91oFN2e7bhMpWKDCAUBEpz4GW6NcE3hBXDobLksZvQGwLrPj0SUVzQA8VuDMyjMAfVCA==\" encryptedHmacValue=\"O6oegHpQVz2uO7Om4oZijSi4kzLiiMZGIjfZlq/EFFO6PZbKitenBqe2or1REaxaI7gO/JmtJzZ1ViucqTaw4g==\" />\r\n" +
            "    <keyEncryptors>\r\n" +
            "        <keyEncryptor uri=\"http://schemas.microsoft.com/office/2006/keyEncryptor/password\">\r\n" +
            "           <p:encryptedKey spinCount=\"100000\" saltSize=\"16\" blockSize=\"16\" keyBits=\"256\" hashSize=\"64\" cipherAlgorithm=\"AES\" cipherChaining=\"ChainingModeCBC\" hashAlgorithm=\"SHA512\" saltValue=\"u2BNFAuHYn3M/WRja3/uPg==\" encryptedVerifierHashInput=\"M0V+fRolJMRgFyI9w+AVxQ==\" encryptedVerifierHashValue=\"V/6l9pFH7AaXFqEbsnFBfHe7gMOqFeRwaNMjc7D3LNdw6KgZzOOQlt5sE8/oG7GPVBDGfoQMTxjQydVPVy4qng==\" encryptedKeyValue=\"B0/rbSQRiIKG5CQDH6AKYSybdXzxgKAfX1f+S5k7mNE=\" />\r\n" +
            "        </keyEncryptor></keyEncryptors></encryption>";

        [TestMethod]
        public void TestEncryptionInfoAgile_ReadWrite_ByteArray()
        {
            byte[] xmlBytes = Encoding.UTF8.GetBytes(AgileXml);
            byte[] data = new byte[8 + xmlBytes.Length];
            
            // Major version = 4, Minor version = 4
            byte[] majorBytes = BitConverter.GetBytes((short)4);
            byte[] minorBytes = BitConverter.GetBytes((short)4);
            Array.Copy(majorBytes, 0, data, 0, 2);
            Array.Copy(minorBytes, 0, data, 2, 2);
            
            // 4 extra bytes for header
            Array.Copy(xmlBytes, 0, data, 8, xmlBytes.Length);

            EncryptionInfo info = EncryptionInfo.ReadBinary(data);
            Assert.IsInstanceOfType(info, typeof(EncryptionInfoAgile));
            
            EncryptionInfoAgile agile = (EncryptionInfoAgile)info;
            Assert.AreEqual(4, agile.MajorVersion);
            Assert.AreEqual(4, agile.MinorVersion);
            
            // KeyData assertions
            Assert.AreEqual(16, agile.KeyData.SaltSize);
            Assert.AreEqual(16, agile.KeyData.BlockSize);
            Assert.AreEqual(256, agile.KeyData.KeyBits);
            Assert.AreEqual(64, agile.KeyData.HashSize);
            Assert.AreEqual(eCipherAlgorithm.AES, agile.KeyData.CipherAlgorithm);
            Assert.AreEqual(eChainingMode.ChainingModeCBC, agile.KeyData.CipherChaining);
            Assert.AreEqual(eHashAlogorithm.SHA512, agile.KeyData.HashAlgorithm);
            Assert.AreEqual("pa+hrJ3s1zrY6hmVuSa5JQ==", Convert.ToBase64String(agile.KeyData.SaltValue));
            
            // DataIntegrity assertions
            Assert.AreEqual("O6oegHpQVz2uO7Om4oZijSi4kzLiiMZGIjfZlq/EFFO6PZbKitenBqe2or1REaxaI7gO/JmtJzZ1ViucqTaw4g==", Convert.ToBase64String(agile.DataIntegrity.EncryptedHmacValue));
            Assert.AreEqual("nd8i4sEKjsMjVN2gLo91oFN2e7bhMpWKDCAUBEpz4GW6NcE3hBXDobLksZvQGwLrPj0SUVzQA8VuDMyjMAfVCA==", Convert.ToBase64String(agile.DataIntegrity.EncryptedHmacKey));

            // KeyEncryptors assertions
            Assert.AreEqual(1, agile.KeyEncryptors.Count);
            var encryptor = agile.KeyEncryptors[0];
            Assert.AreEqual(100000, encryptor.SpinCount);
            Assert.AreEqual(16, encryptor.SaltSize);
            Assert.AreEqual(16, encryptor.BlockSize);
            Assert.AreEqual(256, encryptor.KeyBits);
            Assert.AreEqual(64, encryptor.HashSize);
            Assert.AreEqual(eCipherAlgorithm.AES, encryptor.CipherAlgorithm);
            Assert.AreEqual(eChainingMode.ChainingModeCBC, encryptor.CipherChaining);
            Assert.AreEqual(eHashAlogorithm.SHA512, encryptor.HashAlgorithm);
            Assert.AreEqual("u2BNFAuHYn3M/WRja3/uPg==", Convert.ToBase64String(encryptor.SaltValue));
            Assert.AreEqual("M0V+fRolJMRgFyI9w+AVxQ==", Convert.ToBase64String(encryptor.EncryptedVerifierHashInput));
            Assert.AreEqual("V/6l9pFH7AaXFqEbsnFBfHe7gMOqFeRwaNMjc7D3LNdw6KgZzOOQlt5sE8/oG7GPVBDGfoQMTxjQydVPVy4qng==", Convert.ToBase64String(encryptor.EncryptedVerifierHash));
            Assert.AreEqual("B0/rbSQRiIKG5CQDH6AKYSybdXzxgKAfX1f+S5k7mNE=", Convert.ToBase64String(encryptor.EncryptedKeyValue));
        }

        [TestMethod]
        public void TestEncryptionInfoAgile_PropertyMutations()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<keyEncryptor xmlns:p=\"http://schemas.microsoft.com/office/2006/keyEncryptor/password\"><p:encryptedKey/></keyEncryptor>");
            XmlNamespaceManager nsm = new XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("p", "http://schemas.microsoft.com/office/2006/keyEncryptor/password");
            XmlNode topNode = doc.SelectSingleNode("//p:encryptedKey", nsm);

            EncryptionInfoAgile.EncryptionKeyEncryptor encryptor = new EncryptionInfoAgile.EncryptionKeyEncryptor(nsm, topNode);
            
            // Test all the byte[] setters/getters
            byte[] dummyBytes = new byte[] { 1, 2, 3 };
            encryptor.SaltValue = dummyBytes;
            Assert.AreEqual(Convert.ToBase64String(dummyBytes), Convert.ToBase64String(encryptor.SaltValue));

            encryptor.EncryptedKeyValue = dummyBytes;
            Assert.AreEqual(Convert.ToBase64String(dummyBytes), Convert.ToBase64String(encryptor.EncryptedKeyValue));

            encryptor.EncryptedVerifierHash = dummyBytes;
            Assert.AreEqual(Convert.ToBase64String(dummyBytes), Convert.ToBase64String(encryptor.EncryptedVerifierHash));

            encryptor.EncryptedVerifierHashInput = dummyBytes;
            Assert.AreEqual(Convert.ToBase64String(dummyBytes), Convert.ToBase64String(encryptor.EncryptedVerifierHashInput));

            encryptor.VerifierHashInput = dummyBytes;
            Assert.AreSame(dummyBytes, encryptor.VerifierHashInput);

            encryptor.VerifierHash = dummyBytes;
            Assert.AreSame(dummyBytes, encryptor.VerifierHash);

            encryptor.KeyValue = dummyBytes;
            Assert.AreSame(dummyBytes, encryptor.KeyValue);

            // DataIntegrity mutators
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<encryption xmlns=\"http://schemas.microsoft.com/office/2006/encryption\"><dataIntegrity/></encryption>");
            XmlNamespaceManager nsm2 = new XmlNamespaceManager(doc2.NameTable);
            nsm2.AddNamespace("d", "http://schemas.microsoft.com/office/2006/encryption");
            XmlNode topNode2 = doc2.SelectSingleNode("//d:dataIntegrity", nsm2);

            EncryptionInfoAgile.EncryptionDataIntegrity integrity = new EncryptionInfoAgile.EncryptionDataIntegrity(nsm2, topNode2);
            integrity.EncryptedHmacValue = dummyBytes;
            Assert.AreEqual(Convert.ToBase64String(dummyBytes), Convert.ToBase64String(integrity.EncryptedHmacValue));

            integrity.EncryptedHmacKey = dummyBytes;
            Assert.AreEqual(Convert.ToBase64String(dummyBytes), Convert.ToBase64String(integrity.EncryptedHmacKey));
        }

        [TestMethod]
        public void TestEncryptionInfoBinary_ReadWrite_ByteArray()
        {
            EncryptionInfoBinary source = new EncryptionInfoBinary();
            source.MajorVersion = 4;
            source.MinorVersion = 2;
            source.Flags = Flags.fAES | Flags.fCryptoAPI;

            source.Header = new EncryptionHeader();
            source.Header.Flags = Flags.fAES | Flags.fCryptoAPI;
            source.Header.SizeExtra = 0;
            source.Header.AlgID = AlgorithmID.AES128;
            source.Header.AlgIDHash = AlgorithmHashID.SHA1;
            source.Header.KeySize = 128;
            source.Header.ProviderType = ProviderType.AES;
            source.Header.Reserved1 = 0;
            source.Header.Reserved2 = 0;
            source.Header.CSPName = "Microsoft Enhanced RSA and AES Cryptographic Provider\0";

            source.Verifier = new EncryptionVerifier();
            source.Verifier.SaltSize = 16;
            source.Verifier.Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            source.Verifier.EncryptedVerifier = new byte[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32 };
            source.Verifier.VerifierHashSize = 20;
            source.Verifier.EncryptedVerifierHash = new byte[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39 };

            byte[] serialized = source.WriteBinary();

            EncryptionInfo info = EncryptionInfo.ReadBinary(serialized);
            Assert.IsInstanceOfType(info, typeof(EncryptionInfoBinary));

            EncryptionInfoBinary binary = (EncryptionInfoBinary)info;
            Assert.AreEqual(4, binary.MajorVersion);
            Assert.AreEqual(2, binary.MinorVersion);
            Assert.AreEqual(Flags.fAES | Flags.fCryptoAPI, binary.Flags);

            // Header assertions
            Assert.AreEqual(Flags.fAES | Flags.fCryptoAPI, binary.Header.Flags);
            Assert.AreEqual(0, binary.Header.SizeExtra);
            Assert.AreEqual(AlgorithmID.AES128, binary.Header.AlgID);
            Assert.AreEqual(AlgorithmHashID.SHA1, binary.Header.AlgIDHash);
            Assert.AreEqual(128, binary.Header.KeySize);
            Assert.AreEqual(ProviderType.AES, binary.Header.ProviderType);
            Assert.AreEqual(0, binary.Header.Reserved1);
            Assert.AreEqual(0, binary.Header.Reserved2);
            Assert.AreEqual("Microsoft Enhanced RSA and AES Cryptographic Provider", binary.Header.CSPName);

            // Verifier assertions
            Assert.AreEqual(16u, binary.Verifier.SaltSize);
            CollectionAssert.AreEqual(source.Verifier.Salt, binary.Verifier.Salt);
            CollectionAssert.AreEqual(source.Verifier.EncryptedVerifier, binary.Verifier.EncryptedVerifier);
            Assert.AreEqual(20u, binary.Verifier.VerifierHashSize);
            CollectionAssert.AreEqual(source.Verifier.EncryptedVerifierHash, binary.Verifier.EncryptedVerifierHash);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestEncryptionInfo_UnsupportedRC4()
        {
            byte[] data = new byte[8];
            // Major version = 4, Minor version = 1 (RC4)
            byte[] majorBytes = BitConverter.GetBytes((short)4);
            byte[] minorBytes = BitConverter.GetBytes((short)1);
            Array.Copy(majorBytes, 0, data, 0, 2);
            Array.Copy(minorBytes, 0, data, 2, 2);

            EncryptionInfo.ReadBinary(data);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestEncryptionInfo_UnsupportedVersion()
        {
            byte[] data = new byte[8];
            // Major version = 5, Minor version = 5
            byte[] majorBytes = BitConverter.GetBytes((short)5);
            byte[] minorBytes = BitConverter.GetBytes((short)5);
            Array.Copy(majorBytes, 0, data, 0, 2);
            Array.Copy(minorBytes, 0, data, 2, 2);

            EncryptionInfo.ReadBinary(data);
        }

#if !Core
        [TestMethod]
        public void TestEncryptionInfoAgile_ReadWrite_FileStream()
        {
            byte[] xmlBytes = Encoding.UTF8.GetBytes(AgileXml);
            byte[] data = new byte[8 + xmlBytes.Length];
            
            byte[] majorBytes = BitConverter.GetBytes((short)4);
            byte[] minorBytes = BitConverter.GetBytes((short)4);
            Array.Copy(majorBytes, 0, data, 0, 2);
            Array.Copy(minorBytes, 0, data, 2, 2);
            Array.Copy(xmlBytes, 0, data, 8, xmlBytes.Length);

            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(tempFile, data);
                using (FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Read))
                {
                    EncryptionInfo info = EncryptionInfo.ReadFile(fs);
                    Assert.IsInstanceOfType(info, typeof(EncryptionInfoAgile));
                    
                    EncryptionInfoAgile agile = (EncryptionInfoAgile)info;
                    Assert.AreEqual(4, agile.MajorVersion);
                    Assert.AreEqual(4, agile.MinorVersion);
                    Assert.AreEqual(16, agile.KeyData.SaltSize);
                }
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [TestMethod]
        public void TestEncryptionInfoBinary_ReadWrite_FileStream()
        {
            EncryptionInfoBinary source = new EncryptionInfoBinary();
            source.MajorVersion = 4;
            source.MinorVersion = 2;
            source.Flags = Flags.fAES | Flags.fCryptoAPI;

            source.Header = new EncryptionHeader();
            source.Header.Flags = Flags.fAES | Flags.fCryptoAPI;
            source.Header.SizeExtra = 0;
            source.Header.AlgID = AlgorithmID.AES128;
            source.Header.AlgIDHash = AlgorithmHashID.SHA1;
            source.Header.KeySize = 128;
            source.Header.ProviderType = ProviderType.AES;
            source.Header.Reserved1 = 0;
            source.Header.Reserved2 = 0;
            source.Header.CSPName = "Microsoft Enhanced RSA and AES Cryptographic Provider\0";

            source.Verifier = new EncryptionVerifier();
            source.Verifier.SaltSize = 16;
            source.Verifier.Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            source.Verifier.EncryptedVerifier = new byte[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32 };
            source.Verifier.VerifierHashSize = 20;
            source.Verifier.EncryptedVerifierHash = new byte[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39 };

            byte[] serialized = source.WriteBinary();

            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(tempFile, serialized);
                using (FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Read))
                {
                    EncryptionInfo info = EncryptionInfo.ReadFile(fs);
                    Assert.IsInstanceOfType(info, typeof(EncryptionInfoBinary));

                    EncryptionInfoBinary binary = (EncryptionInfoBinary)info;
                    Assert.AreEqual(4, binary.MajorVersion);
                    Assert.AreEqual(2, binary.MinorVersion);
                    Assert.AreEqual(Flags.fAES | Flags.fCryptoAPI, binary.Flags);
                    Assert.AreEqual(AlgorithmID.AES128, binary.Header.AlgID);
                }
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
#endif
    }
}
