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
      Assert.ThrowsException<InvalidImageFormatException>(() => Image.GetImageInfo(Constants.InvalidImagePath));
    }

    [TestMethod]
    public void GetImageInfo_NonExistingPath_ThrowFileNotFound()
    {
      Assert.ThrowsException<FileNotFoundException>(() => Image.GetImageInfo("blahblah Path"));
    }

    [TestMethod]
    public void GetImageInfo_ValidJpeg_DoesNotThrowException()
    {
      var result = Image.GetImageInfo(Constants.JpegImagePath);

      Assert.IsNotNull(result);
    }
  }
}