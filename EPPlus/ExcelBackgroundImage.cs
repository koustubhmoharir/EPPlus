/*******************************************************************************
 * You may amend and distribute as you like, but don't remove this header!
 *
 * EPPlus provides server-side generation of Excel 2007/2010 spreadsheets.
 * See https://github.com/JanKallman/EPPlus for details.
 *
 * Copyright (C) 2011  Jan Källman
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.

 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
 * See the GNU Lesser General Public License for more details.
 *
 * The GNU Lesser General Public License can be viewed at http://www.opensource.org/licenses/lgpl-license.php
 * If you unfamiliar with this license or have questions about it, here is an http://www.gnu.org/licenses/gpl-faq.html
 *
 * All code and executables are provided "as is" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 *
 * Code change notes:
 * 
 * Author							Change						Date
 *******************************************************************************
 * Jan Källman		Added		10-SEP-2009
 * Jan Källman		License changed GPL-->LGPL 2011-12-16
 *******************************************************************************/
using System;
using System.Xml;
using System.IO;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Packaging;
using OfficeOpenXml.Utils;

namespace OfficeOpenXml
{
    /// <summary>
    /// An image that fills the background of the worksheet.
    /// </summary>
    public class ExcelBackgroundImage : XmlHelper
    {
        ExcelWorksheet _workSheet;
        byte[] _imageBytes;
        Uri _imageUri;
        string _imageHash;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nsm"></param>
        /// <param name="topNode">The topnode of the worksheet</param>
        /// <param name="workSheet">Worksheet reference</param>
        internal  ExcelBackgroundImage(XmlNamespaceManager nsm, XmlNode topNode, ExcelWorksheet workSheet) :
            base(nsm, topNode)
        {
            _workSheet = workSheet;
        }

        const string BACKGROUNDPIC_PATH = "d:picture/@r:id";
        /// <summary>
        /// The background image bytes of the worksheet.
        /// </summary>
        public byte[] ImageBytes
        {
            get
            {
                if (_imageBytes != null)
                {
                    return (byte[])_imageBytes.Clone();
                }

                LoadCurrentImageBytes();
                return _imageBytes == null ? null : (byte[])_imageBytes.Clone();
            }
        }
        /// <summary>
        /// Sets or clears the worksheet background image.
        /// </summary>
        /// <param name="imageBytes">The image bytes. Pass <c>null</c> to clear the background image.</param>
        /// <param name="contentType">The image content type, for example <c>image/jpeg</c>.</param>
        public void SetImage(byte[] imageBytes, string contentType = null)
        {
            DeletePrevImage();

            if (imageBytes == null)
            {
                DeleteAllNode(BACKGROUNDPIC_PATH);
                ClearState();
                return;
            }

            var image = ValidateImage(imageBytes, contentType);
            var requestedUri = XmlHelper.GetNewUri(_workSheet._package.Package, "/xl/media/image{0}" + GetImageExtension(image.ContentType));
            var ii = _workSheet.Workbook._package.AddImage(image.Bytes, requestedUri, image.ContentType);
            var rel = _workSheet.Part.CreateRelationship(ii.Uri, Packaging.TargetMode.Internal, ExcelPackage.schemaRelationships + "/image");
            SetXmlNodeString(BACKGROUNDPIC_PATH, rel.Id);
            CacheImage(image.Bytes, ii);
        }
        /// <summary>
        /// Set the picture from an image file. 
        /// The image file will be saved as a blob, so make sure Excel supports the image format.
        /// </summary>
        /// <param name="PictureFile">The image file.</param>
        public void SetFromFile(FileInfo PictureFile)
        {
            if (PictureFile == null) throw new ArgumentNullException(nameof(PictureFile));
            if (!PictureFile.Exists)
            {
                throw new FileNotFoundException(string.Format("{0} is missing", PictureFile.FullName));
            }

            try
            {
                SetImage(File.ReadAllBytes(PictureFile.FullName), ExcelPicture.GetContentType(PictureFile.Extension));
            }
            catch (Exception ex)
            {
                throw (new InvalidDataException("File is not a supported image-file or is corrupt", ex));
            }
        }
        private void DeletePrevImage()
        {
            var relID = GetXmlNodeString(BACKGROUNDPIC_PATH);
            if (string.IsNullOrEmpty(relID))
            {
                return;
            }

            var rel = _workSheet.Part.GetRelationship(relID);
            var imageUri = _imageUri ?? UriHelper.ResolvePartUri(rel.SourceUri, rel.TargetUri);
            var ii = imageUri == null ? null : _workSheet.Workbook._package.GetImageInfo(imageUri);

            //Delete the relation
            _workSheet.Part.DeleteRelationship(relID);

            //Release the shared package image by hash so ref counts stay consistent.
            if (ii != null)
            {
                _workSheet.Workbook._package.RemoveImage(ii.Hash);
            }
            else if (!string.IsNullOrEmpty(_imageHash))
            {
                _workSheet.Workbook._package.RemoveImage(_imageHash);
            }

            ClearState();
        }

        private void LoadCurrentImageBytes()
        {
            var relID = GetXmlNodeString(BACKGROUNDPIC_PATH);
            if (string.IsNullOrEmpty(relID))
            {
                return;
            }

            var rel = _workSheet.Part.GetRelationship(relID);
            _imageUri = UriHelper.ResolvePartUri(rel.SourceUri, rel.TargetUri);
            var imagePart = _workSheet.Part.Package.GetPart(_imageUri);
            using (var ms = new MemoryStream())
            {
                imagePart.GetStream().CopyTo(ms);
                _imageBytes = ms.ToArray();
            }

            var ii = _workSheet.Workbook._package.GetImageInfo(_imageUri);
            _imageHash = ii?.Hash;
        }

        private void CacheImage(byte[] imageBytes, ExcelPackage.ImageInfo ii)
        {
            _imageBytes = (byte[])imageBytes.Clone();
            _imageUri = ii?.Uri;
            _imageHash = ii?.Hash;
        }

        private void ClearState()
        {
            _imageBytes = null;
            _imageUri = null;
            _imageHash = null;
        }

        private static ExcelImageData ValidateImage(byte[] imageBytes, string contentType)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                throw new InvalidDataException("File is not a supported image-file or is corrupt");
            }

            contentType = NormalizeContentType(imageBytes, contentType);
            var image = ExcelImageData.Create(imageBytes, null, contentType);
            if (RequiresDimensions(image.ContentType) && (image.PixelWidth <= 0 || image.PixelHeight <= 0))
            {
                throw new InvalidDataException("File is not a supported image-file or is corrupt");
            }

            return image;
        }

        private static string NormalizeContentType(byte[] imageBytes, string contentType)
        {
            if (!string.IsNullOrWhiteSpace(contentType))
            {
                return contentType;
            }

            if (imageBytes == null || imageBytes.Length < 4)
            {
                return "image/jpeg";
            }

            if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
            {
                return "image/png";
            }

            if (imageBytes[0] == 0x47 && imageBytes[1] == 0x49 && imageBytes[2] == 0x46)
            {
                return "image/gif";
            }

            if (imageBytes[0] == 0x42 && imageBytes[1] == 0x4D)
            {
                return "image/bmp";
            }

            if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
            {
                return "image/jpeg";
            }

            return "image/jpeg";
        }

        private static bool RequiresDimensions(string contentType)
        {
            switch ((contentType ?? string.Empty).ToLowerInvariant())
            {
                case "image/png":
                case "image/gif":
                case "image/bmp":
                case "image/jpeg":
                case "image/tiff":
                case "image/x-tiff":
                    return true;
                default:
                    return false;
            }
        }

        private static string GetImageExtension(string contentType)
        {
            switch ((contentType ?? string.Empty).ToLowerInvariant())
            {
                case "image/png":
                    return ".png";
                case "image/gif":
                    return ".gif";
                case "image/bmp":
                    return ".bmp";
                case "image/tiff":
                case "image/x-tiff":
                    return ".tif";
                case "image/x-wmf":
                    return ".wmf";
                case "image/x-emf":
                    return ".emf";
                default:
                    return ".jpg";
            }
        }
    }
}
