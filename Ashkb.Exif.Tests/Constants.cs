using System.IO;

namespace Ashkb.Exif.Tests
{
  public class Constants
  {
    public static readonly string InvalidImagePath =
      Path.Combine(Directory.GetCurrentDirectory(), "Resources", "InvalidImage.txt");

    public static readonly string JpegImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Image.jpg");
  }
}