using System;
using System.Globalization;

namespace OfficeOpenXml.Style
{
    /// <summary>
    /// EPPlus-native ARGB color value.
    /// </summary>
    public readonly struct ExcelColorValue : IEquatable<ExcelColorValue>
    {
        public ExcelColorValue(byte alpha, byte red, byte green, byte blue)
        {
            A = alpha;
            R = red;
            G = green;
            B = blue;
        }

        public byte A { get; }

        public byte R { get; }

        public byte G { get; }

        public byte B { get; }

        public static ExcelColorValue FromArgb(byte alpha, byte red, byte green, byte blue)
        {
            return new ExcelColorValue(alpha, red, green, blue);
        }

        public static ExcelColorValue Parse(string argbHex)
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

            return new ExcelColorValue(
                byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture),
                byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture),
                byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture),
                byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture));
        }

        public string ToArgbHex()
        {
            return string.Concat(
                A.ToString("X2", CultureInfo.InvariantCulture),
                R.ToString("X2", CultureInfo.InvariantCulture),
                G.ToString("X2", CultureInfo.InvariantCulture),
                B.ToString("X2", CultureInfo.InvariantCulture));
        }

        public int ToArgb()
        {
            return (A << 24) | (R << 16) | (G << 8) | B;
        }

        public static ExcelColorValue Red => FromArgb(255, 255, 0, 0);
        public static ExcelColorValue White => FromArgb(255, 255, 255, 255);
        public static ExcelColorValue DarkCyan => FromArgb(255, 0, 139, 139);
        public static ExcelColorValue SteelBlue => FromArgb(255, 70, 130, 180);
        public static ExcelColorValue LightBlue => FromArgb(255, 173, 216, 230);
        public static ExcelColorValue BlueViolet => FromArgb(255, 138, 43, 226);
        public static ExcelColorValue Blue => FromArgb(255, 0, 0, 255);
        public static ExcelColorValue DarkBlue => FromArgb(255, 0, 0, 139);
        public static ExcelColorValue Aquamarine => FromArgb(255, 127, 255, 212);
        public static ExcelColorValue LightSlateGray => FromArgb(255, 119, 136, 153);
        public static ExcelColorValue DarkRed => FromArgb(255, 139, 0, 0);
        public static ExcelColorValue LightSteelBlue => FromArgb(255, 176, 196, 222);
        public static ExcelColorValue Black => FromArgb(255, 0, 0, 0);
        public static ExcelColorValue Beige => FromArgb(255, 245, 245, 220);
        public static ExcelColorValue Green => FromArgb(255, 0, 128, 0);
        public static ExcelColorValue Yellow => FromArgb(255, 255, 255, 0);
        public static ExcelColorValue Orange => FromArgb(255, 255, 165, 0);
        public static ExcelColorValue Gray => FromArgb(255, 128, 128, 128);
        public static ExcelColorValue CadetBlue => FromArgb(255, 95, 158, 160);
        public static ExcelColorValue LightPink => FromArgb(255, 255, 182, 193);
        public static ExcelColorValue LightCyan => FromArgb(255, 224, 255, 255);
        public static ExcelColorValue OrangeRed => FromArgb(255, 255, 69, 0);
        public static ExcelColorValue ForestGreen => FromArgb(255, 34, 139, 34);
        public static ExcelColorValue Pink => FromArgb(255, 255, 192, 203);
        public static ExcelColorValue PeachPuff => FromArgb(255, 255, 218, 185);
        public static ExcelColorValue PowderBlue => FromArgb(255, 176, 224, 230);
        public static ExcelColorValue LightGray => FromArgb(255, 211, 211, 211);
        public static ExcelColorValue LightYellow => FromArgb(255, 255, 255, 224);
        public static ExcelColorValue LightGreen => FromArgb(255, 144, 238, 144);
        public static ExcelColorValue LightCoral => FromArgb(255, 240, 128, 128);
        public static ExcelColorValue DarkGoldenrod => FromArgb(255, 184, 134, 11);
        public static ExcelColorValue Tomato => FromArgb(255, 255, 99, 71);

        public override string ToString()
        {
            return ToArgbHex();
        }

        public bool Equals(ExcelColorValue other)
        {
            return A == other.A &&
                   R == other.R &&
                   G == other.G &&
                   B == other.B;
        }

        public override bool Equals(object obj)
        {
            return obj is ExcelColorValue other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, R, G, B);
        }

        public static bool operator ==(ExcelColorValue left, ExcelColorValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExcelColorValue left, ExcelColorValue right)
        {
            return !left.Equals(right);
        }
    }
}
