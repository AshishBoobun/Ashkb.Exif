using System.IO;
using Ashkb.Exif.Enums;
using Ashkb.Exif.Error;
using Ashkb.Exif.Model;

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
      if (Utility.IsJpeg(imageStream))
      {
        int p = 1;
        //TODO parse jpeg
        return null;
      }

      throw new InvalidImageFormatException();
    }
  }
}
