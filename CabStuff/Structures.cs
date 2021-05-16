using System;
using System.Runtime.InteropServices;

namespace CabStuff
{
    public struct CFHEADER
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] signature;
        public uint reserved1;
        public uint cbCabinet;
        public uint reserved2;
        public uint coffFiles;
        public uint reserved3;
        public byte versionMinor;
        public byte versionMajor;
        public ushort cFolders;
        public ushort cFiles;
        public Options flags;
        public ushort setID;
        public ushort iCabinet;

        [Flags]
        public enum Options : ushort
        {
            PreviousCabinet = 0x001,
            NextCabinet = 0x002,
            ReservePresent = 0x004
        }
    }

    public struct CFFOLDER
    {
        public uint firstDataBlockOffset;
        public ushort dataBlockCount;
        public CFTYPECOMPRESS typeCompress;

        public enum CFTYPECOMPRESS : ushort
        {
            TYPE_NONE = 0,
            TYPE_MSZIP = 1,
            TYPE_LZX = 5379,
            TYPE_QUANTUM
        }
    }

    public struct CFFILE
    {
        /// <summary>
        /// Specifies the uncompressed size of this file, in bytes.
        /// </summary>
        public uint cbFile;

        /// <summary>
        /// Specifies the uncompressed offset, in bytes, of the start of this file's data. For the 
        /// first file in each folder, this value will usually be zero.Subsequent files in the folder will have offsets
        /// that are typically the running sum of the cbFile field values.
        /// </summary>
        public uint uoffFolderStart;

        public ushort iFolder;
        public ushort date;
        public ushort time;
        public ushort attribs;
    }

    public struct CFDATA
    {
        public uint csum;
        public ushort cbData;
        public ushort cbUncomp;
    }
}
