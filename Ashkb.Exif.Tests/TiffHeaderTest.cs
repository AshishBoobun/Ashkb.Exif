using System.IO;
using System.Text;
using Ashkb.Exif.Enums;
using Ashkb.Exif.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ashkb.Exif.Tests
{
  [TestClass]
  public class TiffHeaderTest
  {
    [TestMethod]
    public void TryParse_InvalidStream_ReturnFalseAndOutputNull()
    {
      var invalidStream = new FileStream(Constants.InvalidImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
      var veryShortStream = new MemoryStream(Encoding.UTF8.GetBytes("er"));
      var closedStream = new MemoryStream();
      closedStream.Dispose();
      var noReadPermissionStream = new FileStream(Constants.TiffSamplePath, FileMode.Open, FileAccess.Write);

      var nullStreamResult = TiffHeader.TryParse(null, 0, out var headerNullResult);
      var invalidStreamResult = TiffHeader.TryParse(invalidStream, 0, out var headerInvalidResult);
      var veryShortStreamResult = TiffHeader.TryParse(veryShortStream, 0, out var headerVeryShortResult);
      var closeStreamResult = TiffHeader.TryParse(closedStream, 0, out var headerClosedResult);
      var noReadPermissionStreamResult =
        TiffHeader.TryParse(noReadPermissionStream, 0, out var headerNoReadPermissionResult);

      Assert.IsFalse(nullStreamResult);
      Assert.IsNull(headerNullResult);

      Assert.IsFalse(invalidStreamResult);
      Assert.IsNull(headerInvalidResult);

      Assert.IsFalse(veryShortStreamResult);
      Assert.IsNull(headerVeryShortResult);

      Assert.IsFalse(closeStreamResult);
      Assert.IsNull(headerClosedResult);

      Assert.IsFalse(noReadPermissionStreamResult);
      Assert.IsNull(headerNoReadPermissionResult);


      invalidStream.Dispose();
      veryShortStream.Dispose();
      noReadPermissionStream.Dispose();
    }

    [TestMethod]
    public void TryParse_ValidStreamButInvalidStartIndex_ReturnFalseAndOutputNull()
    {
      var correctTiffStream = new FileStream(Constants.TiffSamplePath, FileMode.Open, FileAccess.Read);

      var invalidStartIndexStreamResult =
        TiffHeader.TryParse(correctTiffStream, 1, out var headerInvalidStartIndexResult);

      Assert.IsFalse(invalidStartIndexStreamResult);
      Assert.IsNull(headerInvalidStartIndexResult);
      correctTiffStream.Dispose();
    }

    [TestMethod]
    public void TryParse_ValidStream_ReturnTrueAndCorrectNull()
    {
      var validStream = new FileStream(Constants.TiffSamplePath, FileMode.Open, FileAccess.Read, FileShare.Read);

      var validStreamResult = TiffHeader.TryParse(validStream, 0, out var tiffHeader);

      Assert.IsTrue(validStreamResult);
      Assert.IsNotNull(tiffHeader);
      Assert.AreEqual(0x002A, tiffHeader.VersionNumber);
      Assert.IsTrue(tiffHeader.ByteOrder == ByteOrder.BigEndian || tiffHeader.ByteOrder == ByteOrder.LittleEndian);
      Assert.IsTrue(tiffHeader.OffsetOfIfd0 > 0);
      validStream.Dispose();
    }
  }
}