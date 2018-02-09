namespace Ashkb.Exif
{
    public static class Utility
    {
      public static int Combine(byte b1, byte b2)
      {
        
        int combined = b1 << 8 | b2;
        return combined;
      }
    }
}
