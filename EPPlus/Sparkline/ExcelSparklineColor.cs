using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;

namespace OfficeOpenXml.Sparkline
{
    /// <summary>
    /// Sparkline colors
    /// </summary>
    public class ExcelSparklineColor : XmlHelper, IColor
    {
        internal ExcelSparklineColor(XmlNamespaceManager ns , XmlNode node) : base(ns, node)
        {
            
        }
        /// <summary>
        /// Indexed color
        /// </summary>
        public int Indexed
        {
            get => GetXmlNodeInt("@indexed");
            set
            {
                if (value < 0 || value > 65)
                {
                    throw (new ArgumentOutOfRangeException("Index out of range"));
                }
                    
                SetXmlNodeString("@indexed", value.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// RGB 
        /// </summary>
        public string Rgb
        {
            get => GetXmlNodeString("@rgb");
            internal set
            {
                SetXmlNodeString("@rgb", value);
            }
        }
        

        public string Theme => GetXmlNodeString("@theme");

        /// <summary>
        /// The tint value
        /// </summary>
        public decimal Tint
        {
            get=> GetXmlNodeDecimal("@tint");
            set
            {
                if (value > 1 || value < -1)
                {
                    throw (new ArgumentOutOfRangeException("Value must be between -1 and 1"));
                }
                SetXmlNodeString("@tint", value.ToString(CultureInfo.InvariantCulture));
            }
        }

        public void SetColor(ExcelColorValue color)
        {
            Rgb = color.ToArgbHex();
        }

        public void SetColor(string argbHex)
        {
            Rgb = NormalizeArgbHex(argbHex);
        }

        public void SetColor(byte alpha, byte red, byte green, byte blue)
        {
            SetColor(new ExcelColorValue(alpha, red, green, blue));
        }

        private static string NormalizeArgbHex(string argbHex)
        {
            if (string.IsNullOrWhiteSpace(argbHex))
            {
                throw new ArgumentException("ARGB hex string must not be null or empty.", nameof(argbHex));
            }

            var hex = argbHex.Trim();
            if (hex.StartsWith("#", StringComparison.Ordinal))
            {
                hex = hex.Substring(1);
            }

            if (hex.Length == 6)
            {
                hex = "FF" + hex;
            }
            else if (hex.Length != 8)
            {
                throw new ArgumentException("ARGB hex string must be 6 or 8 hex characters.", nameof(argbHex));
            }

            return hex.ToUpperInvariant();
        }
    }
}
