using System;

namespace OfficeOpenXml.Drawing
{
    internal struct ExcelImageMetadata
    {
        public int Width;
        public int Height;
        public float HorizontalDpi;
        public float VerticalDpi;
    }

    internal static class ExcelImageMetadataReader
    {
        internal static bool TryGetMetadata(byte[] imageBytes, out ExcelImageMetadata metadata)
        {
            metadata = new ExcelImageMetadata
            {
                HorizontalDpi = 96,
                VerticalDpi = 96
            };

            if (imageBytes == null || imageBytes.Length < 10)
            {
                return false;
            }

            if (IsPng(imageBytes))
            {
                metadata.Width = ReadInt32BigEndian(imageBytes, 16);
                metadata.Height = ReadInt32BigEndian(imageBytes, 20);
                return metadata.Width > 0 && metadata.Height > 0;
            }

            if (IsGif(imageBytes))
            {
                metadata.Width = ReadInt16LittleEndian(imageBytes, 6);
                metadata.Height = ReadInt16LittleEndian(imageBytes, 8);
                return metadata.Width > 0 && metadata.Height > 0;
            }

            if (IsBmp(imageBytes))
            {
                metadata.Width = ReadInt32LittleEndian(imageBytes, 18);
                metadata.Height = ReadInt32LittleEndian(imageBytes, 22);
                return metadata.Width > 0 && metadata.Height > 0;
            }

            if (IsJpeg(imageBytes))
            {
                return TryReadJpegMetadata(imageBytes, ref metadata);
            }

            return false;
        }

        private static bool IsPng(byte[] imageBytes)
        {
            return imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47;
        }

        private static bool IsGif(byte[] imageBytes)
        {
            return imageBytes[0] == 0x47 && imageBytes[1] == 0x49 && imageBytes[2] == 0x46;
        }

        private static bool IsBmp(byte[] imageBytes)
        {
            return imageBytes[0] == 0x42 && imageBytes[1] == 0x4D && imageBytes.Length >= 26;
        }

        private static bool IsJpeg(byte[] imageBytes)
        {
            return imageBytes[0] == 0xFF && imageBytes[1] == 0xD8;
        }

        private static bool TryReadJpegMetadata(byte[] imageBytes, ref ExcelImageMetadata metadata)
        {
            int index = 2;
            while (index + 1 < imageBytes.Length)
            {
                if (imageBytes[index] != 0xFF)
                {
                    index++;
                    continue;
                }

                byte marker = imageBytes[index + 1];
                if (marker == 0xD9 || marker == 0xDA)
                {
                    break;
                }

                if (index + 3 >= imageBytes.Length)
                {
                    break;
                }

                int length = ReadInt16BigEndian(imageBytes, index + 2);
                if (length < 2 || index + 2 + length > imageBytes.Length)
                {
                    break;
                }

                if (IsFrameMarker(marker))
                {
                    if (index + 7 >= imageBytes.Length)
                    {
                        break;
                    }

                    metadata.Height = ReadInt16BigEndian(imageBytes, index + 5);
                    metadata.Width = ReadInt16BigEndian(imageBytes, index + 7);
                    return metadata.Width > 0 && metadata.Height > 0;
                }

                index += 2 + length;
            }

            return false;
        }

        private static bool IsFrameMarker(byte marker)
        {
            return marker >= 0xC0 && marker <= 0xC3
                || marker >= 0xC5 && marker <= 0xC7
                || marker >= 0xC9 && marker <= 0xCB
                || marker >= 0xCD && marker <= 0xCF;
        }

        private static int ReadInt16LittleEndian(byte[] buffer, int offset)
        {
            return buffer[offset] | (buffer[offset + 1] << 8);
        }

        private static int ReadInt32LittleEndian(byte[] buffer, int offset)
        {
            return buffer[offset]
                   | (buffer[offset + 1] << 8)
                   | (buffer[offset + 2] << 16)
                   | (buffer[offset + 3] << 24);
        }

        private static int ReadInt16BigEndian(byte[] buffer, int offset)
        {
            return (buffer[offset] << 8) | buffer[offset + 1];
        }

        private static int ReadInt32BigEndian(byte[] buffer, int offset)
        {
            return (buffer[offset] << 24)
                   | (buffer[offset + 1] << 16)
                   | (buffer[offset + 2] << 8)
                   | buffer[offset + 3];
        }
    }
}
