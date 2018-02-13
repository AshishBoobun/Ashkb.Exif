using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ashkb.Exif.Tests
{
  [TestClass]
  public class UtilityTest
  {
    [TestMethod]
    public void StreamContainsJpegSoiEoiMarker_InvalidStream_ReturnFalse()
    {
      var invalidJpegStream = new FileStream(Constants.InvalidImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
      var veryShortStream = new MemoryStream(Encoding.UTF8.GetBytes("er"));
      var closedStream = new MemoryStream();
      closedStream.Dispose();

      var nullStreamResult = Utility.StreamContainsJpegSoiEoiMarker(null);
      var invalidJpegStreamResult = Utility.StreamContainsJpegSoiEoiMarker(invalidJpegStream);
      var veryShortStreamResult = Utility.StreamContainsJpegSoiEoiMarker(veryShortStream);
      var closeStreamResult = Utility.StreamContainsJpegSoiEoiMarker(closedStream);

      Assert.IsFalse(nullStreamResult);
      Assert.IsFalse(invalidJpegStreamResult);
      Assert.IsFalse(veryShortStreamResult);
      Assert.IsFalse(closeStreamResult);

      invalidJpegStream.Dispose();
      veryShortStream.Dispose();
    }

    [TestMethod]
    public void StreamContainsJpegSoiEoiMarker_ValidStream_ReturnTrue()
    {
      var validJpegStream = new FileStream(Constants.JpegImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);

      var validJpegStreamResult = Utility.StreamContainsJpegSoiEoiMarker(validJpegStream);

      Assert.IsTrue(validJpegStreamResult);
    }
  }
}