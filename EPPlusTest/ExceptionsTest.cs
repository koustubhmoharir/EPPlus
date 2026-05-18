using System;
using System.IO;
#if !Core
using System.Runtime.Serialization.Formatters.Binary;
#endif
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace EPPlusTest
{
    [TestClass]
    public class ExceptionsTest
    {
        [TestMethod]
        public void TestBadPasswordException()
        {
            // Default constructor
            var ex1 = new BadPasswordException();
            Assert.IsNotNull(ex1);

            // Message constructor
            var ex2 = new BadPasswordException("Wrong password");
            Assert.AreEqual("Wrong password", ex2.Message);

            // Message + InnerException constructor
            var inner = new Exception("inner");
            var ex3 = new BadPasswordException("Wrong password", inner);
            Assert.AreEqual("Wrong password", ex3.Message);
            Assert.AreSame(inner, ex3.InnerException);

#if !Core
            // Serialization test
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ex3);
                stream.Position = 0;
                var deserialized = (BadPasswordException)formatter.Deserialize(stream);
                Assert.AreEqual("Wrong password", deserialized.Message);
                Assert.AreEqual("inner", deserialized.InnerException.Message);
            }
#endif
        }

        [TestMethod]
        public void TestBadReadException()
        {
            var ex1 = new BadReadException();
            Assert.IsNotNull(ex1);

            var ex2 = new BadReadException("Bad read");
            Assert.AreEqual("Bad read", ex2.Message);

            var inner = new Exception("inner");
            var ex3 = new BadReadException("Bad read", inner);
            Assert.AreEqual("Bad read", ex3.Message);
            Assert.AreSame(inner, ex3.InnerException);

#if !Core
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ex3);
                stream.Position = 0;
                var deserialized = (BadReadException)formatter.Deserialize(stream);
                Assert.AreEqual("Bad read", deserialized.Message);
                Assert.AreEqual("inner", deserialized.InnerException.Message);
            }
#endif
        }

        [TestMethod]
        public void TestBadCrcException()
        {
            var ex1 = new BadCrcException();
            Assert.IsNotNull(ex1);

            var ex2 = new BadCrcException("Bad CRC");
            Assert.AreEqual("Bad CRC", ex2.Message);

#if !Core
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ex2);
                stream.Position = 0;
                var deserialized = (BadCrcException)formatter.Deserialize(stream);
                Assert.AreEqual("Bad CRC", deserialized.Message);
            }
#endif
        }

        [TestMethod]
        public void TestSfxGenerationException()
        {
            var ex1 = new SfxGenerationException();
            Assert.IsNotNull(ex1);

            var ex2 = new SfxGenerationException("SFX error");
            Assert.AreEqual("SFX error", ex2.Message);

#if !Core
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ex2);
                stream.Position = 0;
                var deserialized = (SfxGenerationException)formatter.Deserialize(stream);
                Assert.AreEqual("SFX error", deserialized.Message);
            }
#endif
        }

        [TestMethod]
        public void TestBadStateException()
        {
            var ex1 = new BadStateException();
            Assert.IsNotNull(ex1);

            var ex2 = new BadStateException("Bad state");
            Assert.AreEqual("Bad state", ex2.Message);

            var inner = new Exception("inner");
            var ex3 = new BadStateException("Bad state", inner);
            Assert.AreEqual("Bad state", ex3.Message);
            Assert.AreSame(inner, ex3.InnerException);

#if !Core
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ex3);
                stream.Position = 0;
                var deserialized = (BadStateException)formatter.Deserialize(stream);
                Assert.AreEqual("Bad state", deserialized.Message);
                Assert.AreEqual("inner", deserialized.InnerException.Message);
            }
#endif
        }

        [TestMethod]
        public void TestZipException()
        {
            var ex1 = new ZipException();
            Assert.IsNotNull(ex1);

            var ex2 = new ZipException("Zip error");
            Assert.AreEqual("Zip error", ex2.Message);

            var inner = new Exception("inner");
            var ex3 = new ZipException("Zip error", inner);
            Assert.AreEqual("Zip error", ex3.Message);
            Assert.AreSame(inner, ex3.InnerException);

#if !Core
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, ex3);
                stream.Position = 0;
                var deserialized = (ZipException)formatter.Deserialize(stream);
                Assert.AreEqual("Zip error", deserialized.Message);
                Assert.AreEqual("inner", deserialized.InnerException.Message);
            }
#endif
        }
    }
}
