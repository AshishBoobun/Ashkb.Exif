using System.IO;
using Ashkb.Exif.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ashkb.Exif.Tests
{
  [TestClass]
  public class ImageTest
  {
    [TestMethod]
    public void GetImageInfo_InvalidImageFile()
    {
      var invalidJpegFile = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "InvalidImage.txt");
      Assert.ThrowsException<InvalidImageFormatException>(() => Image.GetImageInfo(invalidJpegFile));
    }

    [TestMethod]
    public void GetImageInfo_NonExistingPath_ThrowFileNotFound()
    {
      Assert.ThrowsException<FileNotFoundException>(() => Image.GetImageInfo("blahblah Path"));
    }

    [TestMethod]
    public void GetImageInfo_ValidJpeg_DoesNotThrowException()
    {
      var jpegPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Image.jpg");

      var result = Image.GetImageInfo(jpegPath);

      Assert.IsNotNull(result);
    }
  }
}