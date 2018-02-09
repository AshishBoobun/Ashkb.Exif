using System;
using System.IO;
using System.Reflection;
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
      string invalidJpegFile = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "InvalidImage.txt");
      Assert.ThrowsException<InvalidImageFormatException>(() => Image.GetImageInfo(invalidJpegFile));
    }

    [TestMethod]
    public void GetImageInfo_NonExistingPath_ThrowFileNotFound()
    {
      Assert.ThrowsException<FileNotFoundException>(() => Image.GetImageInfo("blahblah Path"));
    }
  }
}
