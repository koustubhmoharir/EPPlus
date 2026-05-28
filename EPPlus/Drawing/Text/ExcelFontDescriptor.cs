namespace OfficeOpenXml.Drawing.Text
{
    /// <summary>
    /// EPPlus-native font metadata used for text measurement and font-based API migration.
    /// </summary>
    public readonly struct ExcelFontDescriptor : System.IEquatable<ExcelFontDescriptor>
    {
        public ExcelFontDescriptor(string name, float size, bool bold, bool italic, bool underline, bool strikeout)
        {
            Name = name;
            Size = size;
            Bold = bold;
            Italic = italic;
            Underline = underline;
            Strikeout = strikeout;
        }

        /// <summary>
        /// The font family name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Backwards-compatible alias for the font family name.
        /// </summary>
        public string FamilyName => Name;

        public float Size { get; }

        public bool Bold { get; }

        public bool Italic { get; }

        public bool Underline { get; }

        public bool Strikeout { get; }

        public bool Equals(ExcelFontDescriptor other)
        {
            return string.Equals(Name, other.Name, System.StringComparison.OrdinalIgnoreCase) &&
                   Size.Equals(other.Size) &&
                   Bold == other.Bold &&
                   Italic == other.Italic &&
                   Underline == other.Underline &&
                   Strikeout == other.Strikeout;
        }

        public override bool Equals(object obj)
        {
            return obj is ExcelFontDescriptor other && Equals(other);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(
                Name == null ? string.Empty : Name.ToUpperInvariant(),
                Size,
                Bold,
                Italic,
                Underline,
                Strikeout);
        }

        public static bool operator ==(ExcelFontDescriptor left, ExcelFontDescriptor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExcelFontDescriptor left, ExcelFontDescriptor right)
        {
            return !left.Equals(right);
        }
    }
}
