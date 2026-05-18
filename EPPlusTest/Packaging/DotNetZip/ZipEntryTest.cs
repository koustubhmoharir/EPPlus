using System;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class ZipEntryTest
    {
        [TestMethod]
        public void ZipEntry_Constructor_SetsExpectedDefaults()
        {
            var entry = new ZipEntry();

            Assert.IsNotNull(entry.AlternateEncoding);
#if Core
            Assert.AreEqual(65001, entry.AlternateEncoding.CodePage);
#else
            Assert.AreEqual(437, entry.AlternateEncoding.CodePage);
#endif
            Assert.AreEqual(ZipOption.Never, entry.AlternateEncodingUsage);
#if Core
            Assert.IsNull(typeof(ZipEntry).GetProperty("DontEmitLastModified", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
#else
            Assert.IsFalse(entry.DontEmitLastModified);
#endif
        }

        #if !Core
        [TestMethod]
        public void ZipEntry_DontEmitLastModified_RoundTrips()
        {
            var entry = new ZipEntry();

            entry.DontEmitLastModified = true;
            Assert.IsTrue(entry.DontEmitLastModified);

            entry.DontEmitLastModified = false;
            Assert.IsFalse(entry.DontEmitLastModified);
        }
        #endif

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
#if Core
            Assert.IsNull(classInterfaceAttribute);
#else
            Assert.IsNotNull(classInterfaceAttribute);
            Assert.AreEqual(ClassInterfaceType.AutoDispatch, classInterfaceAttribute.Value);
#endif
        }
    }
}
