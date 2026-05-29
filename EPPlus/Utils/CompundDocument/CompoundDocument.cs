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
 * Jan Källman		Added		01-01-2012
 * Jan Källman      Added compression support 27-03-2012
 * Jan Källman      Native support for compound documents 2017-04-10
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using comTypes = System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Security;

namespace OfficeOpenXml.Utils.CompundDocument
{
    internal class CompoundDocument
    {
        internal class StoragePart
        {
            public StoragePart()
            {

            }
            internal Dictionary<string, StoragePart> SubStorage = new Dictionary<string, StoragePart>();
            internal Dictionary<string, Stream> DataStreams = new Dictionary<string, Stream>();

            public void Dispose()
            {
                foreach (var part in SubStorage.Values)
                {
                    part.Dispose();
                }
                foreach (var stream in DataStreams.Values)
                {
                    stream.Dispose();
                }
            }
        }
        internal StoragePart Storage = null;
        private readonly string _tempFolder;
        internal CompoundDocument()
            : this((string)null)
        {
        }
        internal CompoundDocument(string tempFolder = null)
        {
            _tempFolder = tempFolder;
            Storage = new StoragePart();
        }
        internal CompoundDocument(MemoryStream ms)
        {
            _tempFolder = null;
            Read(ms);
        }
        internal CompoundDocument(Stream stream, string tempFolder = null)
        {
            _tempFolder = tempFolder;
            Read(stream, tempFolder);
        }
        internal CompoundDocument(FileInfo fi, string tempFolder = null)
        {
            _tempFolder = tempFolder;
            Read(fi, tempFolder);
        }

        internal static bool IsCompoundDocument(FileInfo fi)
        {
            return CompoundDocumentFile.IsCompoundDocument(fi);
        }
        internal static bool IsCompoundDocument(MemoryStream ms)
        {
            return CompoundDocumentFile.IsCompoundDocument(ms);
        }
        internal static bool IsCompoundDocument(Stream stream)
        {
            return CompoundDocumentFile.IsCompoundDocument(stream);
        }

        internal CompoundDocument(byte[] doc)
        {
            _tempFolder = null;
            Read(doc);
        }
        internal void Read(FileInfo fi, string tempFolder = null)
        {
            using (var stream = fi.OpenRead())
            {
                Read(stream, tempFolder ?? _tempFolder);
            }
        }
        internal void Read(byte[] doc)
        {
            Read(new MemoryStream(doc));
        }
        internal void Read(MemoryStream ms)
        {
            Read((Stream)ms);
        }
        internal void Read(Stream stream, string tempFolder = null)
        {
            using (var doc = new CompoundDocumentFile(stream, tempFolder ?? _tempFolder))
            {
                Storage = new StoragePart();
                GetStorageAndStreams(Storage, doc.RootItem);
            }
        }

        private void GetStorageAndStreams(StoragePart storage, CompoundDocumentItem parent)
        {
            foreach(var item in parent.Children)
            {
                if(item.ObjectType==1)      //Substorage
                {
                    var part = new StoragePart();
                    storage.SubStorage.Add(item.Name, part);
                    GetStorageAndStreams(part, item);
                }
                else if(item.ObjectType==2) //Stream
                {
                    storage.DataStreams.Add(item.Name, item.Stream);
                }
            }
        }
        internal void Save(MemoryStream ms)
        {
            Save((Stream)ms);
        }

        internal void Save(Stream stream)
        {
            using (var doc = new CompoundDocumentFile(_tempFolder))
            {
                WriteStorageAndStreams(Storage, doc.RootItem);
                doc.Write(stream);
            }
        }

        private void WriteStorageAndStreams(StoragePart storage, CompoundDocumentItem parent)
        {
            foreach(var item in storage.SubStorage)
            {
                var c = new CompoundDocumentItem() { Name = item.Key, ObjectType = 1, Stream = null, StreamSize = 0, Parent = parent };
                parent.Children.Add(c);
                WriteStorageAndStreams(item.Value, c);
            }
            foreach (var item in storage.DataStreams)
            {
                var stream = item.Value;
                var streamSize = stream == null ? 0 : stream.Length;
                var c = new CompoundDocumentItem() { Name = item.Key, ObjectType = 2, Stream = stream, StreamSize = streamSize, Parent = parent };
                parent.Children.Add(c);
            }
        }

        public void Dispose()
        {
            if (Storage != null) Storage.Dispose();
        }
    }
}
