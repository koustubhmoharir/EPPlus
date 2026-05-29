using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Reflection;
using System.Xml;

namespace EPPlusTest.Drawing.Chart
{
    [TestClass]
    public class ExcelChartAxisTest
    {
        private ExcelChartAxis axis;

        [TestInitialize]
        public void Initialize()
        {
            var xmlDoc = new XmlDocument();
            var xmlNsm = new XmlNamespaceManager(new NameTable());
            xmlNsm.AddNamespace("c", ExcelPackage.schemaChart);
            xmlNsm.AddNamespace("a", ExcelPackage.schemaDrawings);

            var ctor = typeof(ExcelChartAxis).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null,
                new Type[] { typeof(XmlNamespaceManager), typeof(XmlNode) },
                null
            );
            axis = (ExcelChartAxis)ctor.Invoke(new object[] { xmlNsm, xmlDoc.CreateElement("axis") });
        }

        private XmlNode GetTopNode(ExcelChartAxis target)
        {
            var prop = typeof(XmlHelper).GetProperty("TopNode", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return (XmlNode)prop.GetValue(target);
        }

        private XmlNamespaceManager GetNameSpaceManager(ExcelChartAxis target)
        {
            var prop = typeof(XmlHelper).GetProperty("NameSpaceManager", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return (XmlNamespaceManager)prop.GetValue(target);
        }

        [TestMethod]
        public void CrossesAt_SetTo2_Is2()
        {
            axis.CrossesAt = 2;
            Assert.AreEqual(axis.CrossesAt, 2);
        }

        [TestMethod]
        public void CrossesAt_SetTo1EMinus6_Is1EMinus6()
        {
            axis.CrossesAt = 1.2e-6;
            Assert.AreEqual(axis.CrossesAt, 1.2e-6);
        }

        [TestMethod]
        public void MinValue_SetTo2_Is2()
        {
            axis.MinValue = 2;
            Assert.AreEqual(axis.MinValue, 2);
        }

        [TestMethod]
        public void MinValue_SetTo1EMinus6_Is1EMinus6()
        {
            axis.MinValue = 1.2e-6;
            Assert.AreEqual(axis.MinValue, 1.2e-6);
        }

        [TestMethod]
        public void MaxValue_SetTo2_Is2()
        {
            axis.MaxValue = 2;
            Assert.AreEqual(axis.MaxValue, 2);
        }

        [TestMethod]
        public void MaxValue_SetTo1EMinus6_Is1EMinus6()
        {
            axis.MaxValue = 1.2e-6;
            Assert.AreEqual(axis.MaxValue, 1.2e-6);
        }

        [TestMethod]
        public void Gridlines_GetMajor_IsNotNullAndCreatesNode()
        {
            var major = axis.MajorGridlines;
            Assert.IsNotNull(major);
            Assert.IsNotNull(GetTopNode(axis).SelectSingleNode("c:majorGridlines", GetNameSpaceManager(axis)));
            Assert.AreSame(major, axis.MajorGridlines);
        }

        [TestMethod]
        public void Gridlines_GetMinor_IsNotNullAndCreatesNode()
        {
            var minor = axis.MinorGridlines;
            Assert.IsNotNull(minor);
            Assert.IsNotNull(GetTopNode(axis).SelectSingleNode("c:minorGridlines", GetNameSpaceManager(axis)));
            Assert.AreSame(minor, axis.MinorGridlines);
        }

        [TestMethod]
        public void Gridlines_RemoveGridlinesDefault_RemovesBoth()
        {
            var major = axis.MajorGridlines;
            var minor = axis.MinorGridlines;
            Assert.IsNotNull(GetTopNode(axis).SelectSingleNode("c:majorGridlines", GetNameSpaceManager(axis)));
            Assert.IsNotNull(GetTopNode(axis).SelectSingleNode("c:minorGridlines", GetNameSpaceManager(axis)));

            axis.RemoveGridlines();

            Assert.IsNull(GetTopNode(axis).SelectSingleNode("c:majorGridlines", GetNameSpaceManager(axis)));
            Assert.IsNull(GetTopNode(axis).SelectSingleNode("c:minorGridlines", GetNameSpaceManager(axis)));
        }

        [TestMethod]
        public void Gridlines_RemoveGridlinesSelective_RemovesExpected()
        {
            // Case 1: removeMajor=true, removeMinor=false
            var major = axis.MajorGridlines;
            var minor = axis.MinorGridlines;
            axis.RemoveGridlines(true, false);
            Assert.IsNull(GetTopNode(axis).SelectSingleNode("c:majorGridlines", GetNameSpaceManager(axis)));
            Assert.IsNotNull(GetTopNode(axis).SelectSingleNode("c:minorGridlines", GetNameSpaceManager(axis)));

            // Case 2: removeMajor=false, removeMinor=true
            major = axis.MajorGridlines; // recreate major
            axis.RemoveGridlines(false, true);
            Assert.IsNotNull(GetTopNode(axis).SelectSingleNode("c:majorGridlines", GetNameSpaceManager(axis)));
            Assert.IsNull(GetTopNode(axis).SelectSingleNode("c:minorGridlines", GetNameSpaceManager(axis)));
        }
    }
}
