using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class XmlHelperTest
    {
        public class XmlHelperImpl : XmlHelper
        {
            public XmlHelperImpl(XmlNamespaceManager nsm, XmlNode topNode) : base(nsm, topNode)
            {
            }
        }

        [TestMethod]
        public void XmlHelper_CreateNode_CreatesNewNode()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<root></root>");
            var nsm = new XmlNamespaceManager(doc.NameTable);
            var helper = new XmlHelperImpl(nsm, doc.DocumentElement);

            var node = helper.CreateNode("child");
            Assert.IsNotNull(node);
            Assert.AreEqual("child", node.Name);
            Assert.AreEqual(1, doc.DocumentElement.ChildNodes.Count);
        }

        [TestMethod]
        public void XmlHelper_CreateNode_DoesNotDuplicateExistingNode()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<root><child/></root>");
            var nsm = new XmlNamespaceManager(doc.NameTable);
            var helper = new XmlHelperImpl(nsm, doc.DocumentElement);

            var node = helper.CreateNode("child");
            Assert.IsNotNull(node);
            Assert.AreEqual(1, doc.DocumentElement.ChildNodes.Count);
        }

        [TestMethod]
        public void XmlHelper_GetXmlNodeInt_ParsesCorrectly()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<root><val>123</val></root>");
            var nsm = new XmlNamespaceManager(doc.NameTable);
            var helper = new XmlHelperImpl(nsm, doc.DocumentElement);

            Assert.AreEqual(123, helper.GetXmlNodeInt("val"));
        }
    }
}
