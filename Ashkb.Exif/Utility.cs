using System.IO;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif
{
    public static class Utility
    {
      public static int Combine(byte b1, byte b2)
      {
        
        int combined = b1 << 8 | b2;
        return combined;
      }

      public static bool IsJpeg(Stream stream)
      {
        byte[] header = new byte[2];
        byte[] ending = new byte[2];

        stream.Seek(0, SeekOrigin.Begin);
        stream.Read(header, 0, header.Length);

        stream.Seek(stream.Length - 2, SeekOrigin.Begin);
        stream.Read(ending, 0, ending.Length);

        var isJpeg = Combine(header[0], header[1]) == (int)JpegMarker.StartOfImage &&
                     Combine(ending[0], ending[1]) == (int)JpegMarker.EndOfImage;

        return isJpeg;
      }
    }
}
