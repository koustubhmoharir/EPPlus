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
 * ******************************************************************************
 * Jan Källman		                Initial Release		        2009-10-01
 * Jan Källman		License changed GPL-->LGPL 2011-12-16
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using OfficeOpenXml.Utils;

namespace OfficeOpenXml.Drawing
{
    /// <summary>
    /// An image object
    /// </summary>
    public sealed class ExcelPicture : ExcelDrawing
    {
        #region "Constructors"
        internal ExcelPicture(ExcelDrawings drawings, XmlNode node) :
            base(drawings, node, "xdr:pic/xdr:nvPicPr/xdr:cNvPr/@name")
        {
            XmlNode picNode = node.SelectSingleNode("xdr:pic/xdr:blipFill/a:blip", drawings.NameSpaceManager);
            if (picNode != null)
            {
                RelPic = drawings.Part.GetRelationship(picNode.Attributes["r:embed"].Value);
                UriPic = UriHelper.ResolvePartUri(drawings.UriDrawing, RelPic.TargetUri);

                Part = drawings.Part.Package.GetPart(UriPic);
                ContentType = Part.ContentType;
                byte[] iby;
                var partStream = Part.GetStream();
                using (var ms = new MemoryStream())
                {
                    partStream.CopyTo(ms);
                    iby = ms.ToArray();
                }
                _imageBytes = iby;
                var ii = _drawings._package.LoadImage(iby, UriPic, Part);
                ImageHash = ii.Hash;
                _imageData = ii.ImageData ?? ExcelImageData.Create(iby, UriPic, Part.ContentType, false);
                ContentType = _imageData.ContentType;
                if (_imageData.PixelWidth > 0 && _imageData.PixelHeight > 0)
                {
                    _imageMetadata = new ExcelImageMetadata
                    {
                        Width = _imageData.PixelWidth,
                        Height = _imageData.PixelHeight,
                        HorizontalDpi = _imageData.HorizontalDpi,
                        VerticalDpi = _imageData.VerticalDpi
                    };
                    _hasImageMetadata = true;
                    _width = _imageMetadata.Width;
                    _height = _imageMetadata.Height;
                    SetPixelWidth(_imageMetadata.Width, _imageMetadata.HorizontalDpi);
                    SetPixelHeight(_imageMetadata.Height, _imageMetadata.VerticalDpi);
                }

                //_height = _image.Height;
                //_width = _image.Width;
                string relID = GetXmlNodeString("xdr:pic/xdr:nvPicPr/xdr:cNvPr/a:hlinkClick/@r:id");
                if (!string.IsNullOrEmpty(relID))
                {
                    HypRel = drawings.Part.GetRelationship(relID);
                    if (HypRel.TargetUri.IsAbsoluteUri)
                    {
                        _hyperlink = new ExcelHyperLink(HypRel.TargetUri.AbsoluteUri);
                    }
                    else
                    {
                        _hyperlink = new ExcelHyperLink(HypRel.TargetUri.OriginalString, UriKind.Relative);
                    }
                    ((ExcelHyperLink)_hyperlink).ToolTip = GetXmlNodeString("xdr:pic/xdr:nvPicPr/xdr:cNvPr/a:hlinkClick/@tooltip");
                }
            }
        }
        internal ExcelPicture(ExcelDrawings drawings, XmlNode node, FileInfo imageFile, Uri hyperlink) :
            base(drawings, node, "xdr:pic/xdr:nvPicPr/xdr:cNvPr/@name")
        {
            byte[] img;
            using (var imagestream = new FileStream(imageFile.FullName, FileMode.Open, FileAccess.Read))
            using (var ms = new MemoryStream())
            {
                imagestream.CopyTo(ms);
                img = ms.ToArray();
            }

            InitializePicture(
                drawings,
                node,
                img,
                GetContentType(imageFile.Extension),
                hyperlink,
                imageFile.Name);
        }

        internal ExcelPicture(ExcelDrawings drawings, XmlNode node, byte[] imageBytes, string contentType, Uri hyperlink) :
            base(drawings, node, "xdr:pic/xdr:nvPicPr/xdr:cNvPr/@name")
        {
            InitializePicture(
                drawings,
                node,
                imageBytes,
                contentType,
                hyperlink,
                null);
        }

        private void InitializePicture(
            ExcelDrawings drawings,
            XmlNode node,
            byte[] imageBytes,
            string contentType,
            Uri hyperlink,
            string sourceName,
            int fallbackWidth = 0,
            int fallbackHeight = 0,
            float fallbackHorizontalDpi = 96f,
            float fallbackVerticalDpi = 96f,
            bool hasFallbackDimensions = false)
        {
            XmlElement picNode = node.OwnerDocument.CreateElement("xdr", "pic", ExcelPackage.schemaSheetDrawings);
            node.InsertAfter(picNode, node.SelectSingleNode("xdr:to", NameSpaceManager));
            _hyperlink = hyperlink;
            picNode.InnerXml = PicStartXml();

            node.InsertAfter(node.OwnerDocument.CreateElement("xdr", "clientData", ExcelPackage.schemaSheetDrawings), picNode);

            var package = drawings.Worksheet._package.Package;
            _imageBytes = imageBytes;
            ContentType = string.IsNullOrWhiteSpace(contentType) ? DetectContentType(imageBytes) : contentType;
            _imageData = ExcelImageData.Create(imageBytes, null, ContentType);

            var requestedUri = GetNewUri(package, GetImageUriPattern(sourceName, ContentType));
            var ii = _drawings._package.AddImage(imageBytes, requestedUri, ContentType);
            UriPic = ii.Uri;
            Part = ii.Part;
            ImageHash = ii.Hash;
            _imageData = ii.ImageData ?? _imageData;

            string relID;
            if (!drawings._hashes.ContainsKey(ii.Hash))
            {
                RelPic = drawings.Part.CreateRelationship(UriHelper.GetRelativeUri(drawings.UriDrawing, ii.Uri), Packaging.TargetMode.Internal, ExcelPackage.schemaRelationships + "/image");
                relID = RelPic.Id;
                _drawings._hashes.Add(ii.Hash, relID);
                AddNewPicture(imageBytes, relID);
            }
            else
            {
                relID = drawings._hashes[ii.Hash];
                var rel = _drawings.Part.GetRelationship(relID);
                UriPic = UriHelper.ResolvePartUri(rel.SourceUri, rel.TargetUri);
                Part = _drawings.Part.Package.GetPart(UriPic);
            }

            if (_imageData.PixelWidth > 0 && _imageData.PixelHeight > 0)
            {
                _imageMetadata = new ExcelImageMetadata
                {
                    Width = _imageData.PixelWidth,
                    Height = _imageData.PixelHeight,
                    HorizontalDpi = _imageData.HorizontalDpi,
                    VerticalDpi = _imageData.VerticalDpi
                };
                _hasImageMetadata = true;
                SetPosDefaults(_imageMetadata.Width, _imageMetadata.Height, _imageMetadata.HorizontalDpi, _imageMetadata.VerticalDpi);
                _width = _imageMetadata.Width;
                _height = _imageMetadata.Height;
            }
            else if (hasFallbackDimensions)
            {
                _imageMetadata = new ExcelImageMetadata
                {
                    Width = fallbackWidth,
                    Height = fallbackHeight,
                    HorizontalDpi = fallbackHorizontalDpi,
                    VerticalDpi = fallbackVerticalDpi
                };
                _hasImageMetadata = true;
                SetPosDefaults(fallbackWidth, fallbackHeight, fallbackHorizontalDpi, fallbackVerticalDpi);
                _width = fallbackWidth;
                _height = fallbackHeight;
            }
            else
            {
                throw new InvalidDataException("File is not a supported image-file or is corrupt");
            }

            node.SelectSingleNode("xdr:pic/xdr:blipFill/a:blip/@r:embed", NameSpaceManager).Value = relID;
            package.Flush();
        }

        private static string GetImageUriPattern(string sourceName, string contentType)
        {
            if (!string.IsNullOrEmpty(sourceName))
            {
                return "/xl/media/{0}" + sourceName;
            }

            return "/xl/media/image{0}" + GetExtensionForContentType(contentType);
        }

        private static string DetectContentType(byte[] imageBytes)
        {
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

        private static string GetExtensionForContentType(string contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                return ".jpg";
            }

            switch (contentType.ToLowerInvariant())
            {
                case "image/bmp":
                    return ".bmp";
                case "image/gif":
                    return ".gif";
                case "image/png":
                    return ".png";
                case "image/tiff":
                case "image/x-tiff":
                    return ".tif";
                case "image/x-emf":
                    return ".emf";
                case "image/x-wmf":
                    return ".wmf";
                case "image/x-eps":
                    return ".eps";
                case "image/x-pcx":
                    return ".pcx";
                case "image/x-tga":
                    return ".tga";
                case "image/cgm":
                    return ".cgm";
                default:
                    return ".jpg";
            }
        }

        internal static string GetContentType(string extension)
        {
            switch (extension.ToLower(CultureInfo.InvariantCulture))
            {
                case ".bmp":
                    return "image/bmp";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".gif":
                    return "image/gif";
                case ".png":
                    return "image/png";
                case ".cgm":
                    return "image/cgm";
                case ".emf":
                    return "image/x-emf";
                case ".eps":
                    return "image/x-eps";
                case ".pcx":
                    return "image/x-pcx";
                case ".tga":
                    return "image/x-tga";
                case ".tif":
                case ".tiff":
                    return "image/x-tiff";
                case ".wmf":
                    return "image/x-wmf";
                default:
                    return "image/jpeg";

            }
        }
        //Add a new image to the compare collection
        private void AddNewPicture(byte[] img, string relID)
        {
            var newPic = new ExcelDrawings.ImageCompare();
            newPic.image = img;
            newPic.relID = relID;
            //_drawings._pics.Add(newPic);
        }
        #endregion
        private void SetPosDefaults(int width, int height, float horizontalDpi, float verticalDpi)
        {
            EditAs = eEditAs.OneCell;
            SetPixelWidth(width, horizontalDpi);
            SetPixelHeight(height, verticalDpi);
        }

        private string PicStartXml()
        {
            StringBuilder xml = new StringBuilder();

            xml.Append("<xdr:nvPicPr>");

            if (_hyperlink == null)
            {
                xml.AppendFormat("<xdr:cNvPr id=\"{0}\" descr=\"\" />", _id);
            }
            else
            {
                HypRel = _drawings.Part.CreateRelationship(_hyperlink, Packaging.TargetMode.External, ExcelPackage.schemaHyperlink);
                xml.AppendFormat("<xdr:cNvPr id=\"{0}\" descr=\"\">", _id);
                if (HypRel != null)
                {
                    if (_hyperlink is ExcelHyperLink)
                    {
                        xml.AppendFormat("<a:hlinkClick xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" r:id=\"{0}\" tooltip=\"{1}\"/>",
                          HypRel.Id, ((ExcelHyperLink)_hyperlink).ToolTip);
                    }
                    else
                    {
                        xml.AppendFormat("<a:hlinkClick xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" r:id=\"{0}\" />",
                          HypRel.Id);
                    }
                }
                xml.Append("</xdr:cNvPr>");
            }

            xml.Append("<xdr:cNvPicPr><a:picLocks noChangeAspect=\"1\" /></xdr:cNvPicPr></xdr:nvPicPr><xdr:blipFill><a:blip xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" r:embed=\"\" cstate=\"print\" /><a:stretch><a:fillRect /> </a:stretch> </xdr:blipFill> <xdr:spPr> <a:xfrm> <a:off x=\"0\" y=\"0\" />  <a:ext cx=\"0\" cy=\"0\" /> </a:xfrm> <a:prstGeom prst=\"rect\"> <a:avLst /> </a:prstGeom> </xdr:spPr>");

            return xml.ToString();
        }

        internal string ImageHash { get; set; }
        private ExcelImageMetadata _imageMetadata;
        private bool _hasImageMetadata;
        byte[] _imageBytes = null;
        private ExcelImageData _imageData;
        /// <summary>
        /// The Image
        /// </summary>
        internal string ContentType
        {
            get;
            set;
        }
        /// <summary>
        /// Set the size of the image in percent from the orginal size
        /// Note that resizing columns / rows after using this function will effect the size of the picture
        /// </summary>
        /// <param name="Percent">Percent</param>
        public override void SetSize(int Percent)
        {
            if (_hasImageMetadata)
            {
                _width = _imageMetadata.Width;
                _height = _imageMetadata.Height;

                _width = (int)(_width * ((decimal)Percent / 100));
                _height = (int)(_height * ((decimal)Percent / 100));

                SetPixelWidth(_width, _imageMetadata.HorizontalDpi);
                SetPixelHeight(_height, _imageMetadata.VerticalDpi);
            }
            else
            {
                base.SetSize(Percent);
            }
        }
        internal Uri UriPic { get; set; }
        internal Packaging.ZipPackageRelationship RelPic { get; set; }
        internal Packaging.ZipPackageRelationship HypRel { get; set; }
        internal Packaging.ZipPackagePart Part;

        internal new string Id
        {
            get { return Name; }
        }
        ExcelDrawingFill _fill = null;
        /// <summary>
        /// Fill
        /// </summary>
        public ExcelDrawingFill Fill
        {
            get
            {
                if (_fill == null)
                {
                    _fill = new ExcelDrawingFill(NameSpaceManager, TopNode, "xdr:pic/xdr:spPr");
                }
                return _fill;
            }
        }
        ExcelDrawingBorder _border = null;
        /// <summary>
        /// Border
        /// </summary>
        public ExcelDrawingBorder Border
        {
            get
            {
                if (_border == null)
                {
                    _border = new ExcelDrawingBorder(NameSpaceManager, TopNode, "xdr:pic/xdr:spPr/a:ln");
                }
                return _border;
            }
        }

        private Uri _hyperlink = null;
        /// <summary>
        /// Hyperlink
        /// </summary>
        public Uri Hyperlink
        {
            get
            {
                return _hyperlink;
            }
        }
        internal override void DeleteMe()
        {
            _drawings._package.RemoveImage(ImageHash);
            base.DeleteMe();
        }
        public override void Dispose()
        {
            base.Dispose();
            _hyperlink = null;
        }
    }
}
