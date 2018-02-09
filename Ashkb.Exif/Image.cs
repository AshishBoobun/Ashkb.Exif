using Ashkb.Exif.Model;
using System;
using System.IO;
using Ashkb.Exif.Enums;
using Ashkb.Exif.Error;

namespace Ashkb.Exif
{
  public class Image
  {
    public static ImageInfo GetImageInfo(string path)
    {
      ImageInfo imageInfo;

      using (var stream = new FileStream(path,FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        imageInfo = GetImageInfo(stream);
      }

      return imageInfo;
    }

    public static ImageInfo GetImageInfo(Stream imageStream)
    {
      imageStream.Seek(0, SeekOrigin.Begin);

      byte[] header = new byte[2];
      imageStream.Read(header, 0, header.Length);

      if (Utility.Combine(header[0], header[1]) == (int)JpegMarker.StartOfImage)
      {
        int p = 1;
        //TODO parse jpeg
        return null;
      }

      throw new InvalidImageFormatException();
    }
  }
}
