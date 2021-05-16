using System.IO;
using System.Runtime.InteropServices;

namespace CabStuff
{
    public static class StreamExtensions
    {
        public static T ReadStruct<T>(this Stream stream) where T : struct
        {
            var sz = Marshal.SizeOf(typeof(T));
            var buffer = new byte[sz];
            stream.Read(buffer, 0, sz);
            var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var structure = (T)Marshal.PtrToStructure(
                pinnedBuffer.AddrOfPinnedObject(), typeof(T));
            pinnedBuffer.Free();
            return structure;
        }

        public static string ReadString(this Stream stream)
        {
            byte[] nameBuffer = new byte[256];

            int j = 0;
            for (; j < 256; j++)
            {
                nameBuffer[j] = (byte)stream.ReadByte();
                if (nameBuffer[j] == 0)
                    break;
            }

            return System.Text.Encoding.ASCII.GetString(nameBuffer, 0, j);
        }
    }
}
