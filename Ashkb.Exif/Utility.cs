using System.IO;
using System.Net.NetworkInformation;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif
{
  public static class Utility
  {
    public static bool StreamContainsJpegSoiEoiMarker(Stream stream)
    {
      var streamContainsJpegSoiEoiMarker = false;

      if (stream != null && stream.CanSeek && stream.CanRead && stream.Length >= 4)
      {
        var start = new byte[2];
        var ending = new byte[2];

        stream.Seek(0, SeekOrigin.Begin);
        stream.Read(start, 0, start.Length);

        stream.Seek(stream.Length - 2, SeekOrigin.Begin);
        stream.Read(ending, 0, ending.Length);

        streamContainsJpegSoiEoiMarker = start[0] == (int) JpegMarker.MarkerPrefix &&
                                         ending[0] == (int) JpegMarker.MarkerPrefix &&
                                         start[1] == (int) JpegMarker.StartOfImage &&
                                         ending[1] == (int) JpegMarker.EndOfImage;
      }


      return streamContainsJpegSoiEoiMarker;
    }

    public static int Combine(byte b1, byte b2)
    {
      int combined = b1 << 8 | b2;
      return combined;
    }
  }
}