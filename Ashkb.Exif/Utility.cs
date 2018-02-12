using System.IO;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif
{
  public static class Utility
  {
    public static bool IsJpeg(Stream stream)
    {
      var start = new byte[2];
      var ending = new byte[2];

      stream.Seek(0, SeekOrigin.Begin);
      stream.Read(start, 0, start.Length);

      stream.Seek(stream.Length - 2, SeekOrigin.Begin);
      stream.Read(ending, 0, ending.Length);

      var isJpeg = start[0] == (int) JpegMarker.MarkerPrefix && ending[0] == (int) JpegMarker.MarkerPrefix &&
                   start[1] == (int) JpegMarker.StartOfImage && ending[1] == (int) JpegMarker.EndOfImage;

      return isJpeg;
    }
  }
}