using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ashkb.Exif.Tests
{
  [TestClass]
    public class UtilityTest
    {
      [TestMethod]
      public void Utility_Combile_2byteReturnCorrectValue()
      {
      byte b1 = 0x4f;
        byte b2 = 0xa9;

        var result = Utility.Combine(b1, b2);

        Assert.AreEqual(0x4fa9, result);

      }
    }
}
