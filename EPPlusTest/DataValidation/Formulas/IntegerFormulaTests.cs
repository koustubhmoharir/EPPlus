using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest.DataValidation.Formulas
{
    [TestClass]
    public class IntegerFormulaTests
    {
        private XmlNode _dataValidationNode;
        private XmlNamespaceManager _namespaceManager;
        private Type _formulaType;
        private ConstructorInfo _ctor;
        private PropertyInfo _valueProp;
        private PropertyInfo _excelFormulaProp;

        [TestInitialize]
        public void Setup()
        {
            _formulaType = typeof(ExcelPackage).Assembly.GetType("OfficeOpenXml.DataValidation.Formulas.ExcelDataValidationFormulaInt");
            _ctor = _formulaType.GetConstructor(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(XmlNamespaceManager), typeof(XmlNode), typeof(string) },
                null
            );
            _valueProp = _formulaType.GetProperty("Value", BindingFlags.Public | BindingFlags.Instance);
            _excelFormulaProp = _formulaType.GetProperty("ExcelFormula", BindingFlags.Public | BindingFlags.Instance);
        }

        private void LoadXmlTestData(string address, string validationType, string formula1Value)
        {
            var xmlDoc = new XmlDocument();
            _namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            _namespaceManager.AddNamespace("d", "urn:a");
            var sb = new StringBuilder();
            sb.AppendFormat("<dataValidation xmlns:d=\"urn:a\" type=\"{0}\" sqref=\"{1}\">", validationType, address);
            sb.AppendFormat("<d:formula1>{0}</d:formula1>", formula1Value);
            sb.Append("</dataValidation>");
            xmlDoc.LoadXml(sb.ToString());
            _dataValidationNode = xmlDoc.DocumentElement;
        }

        private object CreateFormulaInstance()
        {
            return _ctor.Invoke(new object[] { _namespaceManager, _dataValidationNode, "d:formula1" });
        }

        private int? GetValue(object instance)
        {
            return (int?)_valueProp.GetValue(instance, null);
        }

        private void SetValue(object instance, int? value)
        {
            _valueProp.SetValue(instance, value, null);
        }

        private string GetExcelFormula(object instance)
        {
            return (string)_excelFormulaProp.GetValue(instance, null);
        }

        [TestMethod]
        public void IntegerFormula_FormulaValueIsSetFromXmlNodeInConstructor()
        {
            // Arrange
            LoadXmlTestData("A1", "decimal", "1");

            // Act
            var formula = CreateFormulaInstance();

            // Assert
            Assert.AreEqual(1, GetValue(formula));
        }

        [TestMethod]
        public void IntegerFormula_FormulasFormulaIsSetFromXmlNodeInConstructor()
        {
            // Arrange
            LoadXmlTestData("A1", "decimal", "A1");

            // Act
            var formula = CreateFormulaInstance();

            // Assert
            Assert.AreEqual("A1", GetExcelFormula(formula));
		}

		[TestMethod]
		public void IntegerFormula_FormulaValueIsSetFromXmlNodeInConstructor2()
		{
			// Arrange
			LoadXmlTestData("A1", "whole", "1");

			// Act
			var formula = CreateFormulaInstance();

			// Assert
			Assert.AreEqual(1, GetValue(formula));
		}

		[TestMethod]
		public void IntegerFormula_FormulasFormulaIsSetFromXmlNodeInConstructor2()
		{
			// Arrange
			LoadXmlTestData("A1", "whole", "A1");

			// Act
			var formula = CreateFormulaInstance();

			// Assert
			Assert.AreEqual("A1", GetExcelFormula(formula));
		}

		[TestMethod]
        public void IntegerFormula_Constructor_ShouldHandleEmptyOrNullValue()
        {
            // Arrange
            LoadXmlTestData("A1", "whole", "");

            // Act
            var formula = CreateFormulaInstance();

            // Assert
            Assert.IsNull(GetValue(formula));
            Assert.IsNull(GetExcelFormula(formula));
        }

        [TestMethod]
        public void IntegerFormula_SetValue_ShouldUpdateXmlValue()
        {
            // Arrange
            LoadXmlTestData("A1", "whole", "1");
            var formula = CreateFormulaInstance();

            // Act
            SetValue(formula, 456);

            // Assert
            Assert.AreEqual(456, GetValue(formula));
            var formulaNode = _dataValidationNode.SelectSingleNode("d:formula1", _namespaceManager);
            Assert.IsNotNull(formulaNode);
            Assert.AreEqual("456", formulaNode.InnerText);
        }

        [TestMethod]
        public void IntegerFormula_SetValueNull_ShouldUpdateXmlValueToEmpty()
        {
            // Arrange
            LoadXmlTestData("A1", "whole", "1");
            var formula = CreateFormulaInstance();

            // Act
            SetValue(formula, null);

            // Assert
            Assert.IsNull(GetValue(formula));
            var formulaNode = _dataValidationNode.SelectSingleNode("d:formula1", _namespaceManager);
            Assert.IsNotNull(formulaNode);
            Assert.AreEqual(string.Empty, formulaNode.InnerText);
        }
    }
}
