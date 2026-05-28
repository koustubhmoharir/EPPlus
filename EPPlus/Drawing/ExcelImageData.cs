using System;
using System.Security.Cryptography;

namespace OfficeOpenXml.Drawing
{
    internal enum ExcelImageFormat
    {
        Unknown = 0,
        Bmp,
        Gif,
        Jpeg,
        Png,
        Tiff,
        Emf,
        Wmf,
        Eps,
        Pcx,
        Tga,
        Cgm
    }

    internal sealed class ExcelImageData
    {
        internal ExcelImageData(
            byte[] bytes,
            string contentType,
            Uri uri,
            string hash,
            int pixelWidth,
            int pixelHeight,
            float horizontalDpi,
            float verticalDpi,
            ExcelImageFormat format,
            bool isDecoded)
        {
            Bytes = bytes;
            ContentType = contentType;
            Uri = uri;
            Hash = hash;
            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
            HorizontalDpi = horizontalDpi;
            VerticalDpi = verticalDpi;
            Format = format;
            IsDecoded = isDecoded;
        }

        internal byte[] Bytes { get; }

        internal string ContentType { get; }

        internal Uri Uri { get; }

        internal string Hash { get; }

        internal int PixelWidth { get; }

        internal int PixelHeight { get; }

        internal float HorizontalDpi { get; }

        internal float VerticalDpi { get; }

        internal ExcelImageFormat Format { get; }

        internal bool IsDecoded { get; }

        internal static ExcelImageData Create(byte[] bytes, Uri uri, string contentType, bool isDecoded = false)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (string.IsNullOrWhiteSpace(contentType))
            {
                contentType = "image/jpeg";
            }

            var hash = ComputeHash(bytes);

            var pixelWidth = 0;
            var pixelHeight = 0;
            var horizontalDpi = 96f;
            var verticalDpi = 96f;
            if (ExcelImageMetadataReader.TryGetMetadata(bytes, out var metadata))
            {
                pixelWidth = metadata.Width;
                pixelHeight = metadata.Height;
                horizontalDpi = metadata.HorizontalDpi;
                verticalDpi = metadata.VerticalDpi;
            }

            return new ExcelImageData(
                bytes,
                contentType,
                uri,
                hash,
                pixelWidth,
                pixelHeight,
                horizontalDpi,
                verticalDpi,
                MapFormat(contentType, bytes),
                isDecoded);
        }

        private static string ComputeHash(byte[] bytes)
        {
#if (Core)
            using (var hashProvider = SHA1.Create())
#else
            using (var hashProvider = new SHA1CryptoServiceProvider())
#endif
            {
                return BitConverter.ToString(hashProvider.ComputeHash(bytes)).Replace("-", "");
            }
        }

        private static ExcelImageFormat MapFormat(string contentType, byte[] bytes)
        {
            switch ((contentType ?? string.Empty).ToLowerInvariant())
            {
                case "image/bmp":
                    return ExcelImageFormat.Bmp;
                case "image/gif":
                    return ExcelImageFormat.Gif;
                case "image/jpeg":
                    return ExcelImageFormat.Jpeg;
                case "image/png":
                    return ExcelImageFormat.Png;
                case "image/tiff":
                case "image/x-tiff":
                    return ExcelImageFormat.Tiff;
                case "image/x-emf":
                    return ExcelImageFormat.Emf;
                case "image/x-wmf":
                    return ExcelImageFormat.Wmf;
                case "image/x-eps":
                    return ExcelImageFormat.Eps;
                case "image/x-pcx":
                    return ExcelImageFormat.Pcx;
                case "image/x-tga":
                    return ExcelImageFormat.Tga;
                case "image/cgm":
                    return ExcelImageFormat.Cgm;
            }

            if (bytes != null && bytes.Length >= 4)
            {
                if (bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47)
                {
                    return ExcelImageFormat.Png;
                }

                if (bytes[0] == 0x47 && bytes[1] == 0x49 && bytes[2] == 0x46)
                {
                    return ExcelImageFormat.Gif;
                }

                if (bytes[0] == 0x42 && bytes[1] == 0x4D)
                {
                    return ExcelImageFormat.Bmp;
                }

                if (bytes[0] == 0xFF && bytes[1] == 0xD8)
                {
                    return ExcelImageFormat.Jpeg;
                }
            }

            return ExcelImageFormat.Unknown;
        }
    }
}
