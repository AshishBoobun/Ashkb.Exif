using System;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif
{
  public static class BitConverterExtension
  {
    public static ByteOrder SystemByteOrder =
      BitConverter.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

    public static uint ToUInt32(byte[] value, int startIndex, ByteOrder from, ByteOrder to)
    {
      var valueEndianess = CheckEndianessValue(value, startIndex, from, to, 4);
      return BitConverter.ToUInt32(valueEndianess, 0);
    }

    public static uint ToUInt16(byte[] value, int startIndex, ByteOrder from, ByteOrder to)
    {
      var valueEndianess = CheckEndianessValue(value, startIndex, from, to, 2);
      return BitConverter.ToUInt16(valueEndianess, 0);
    }

    private static byte[] CheckEndianessValue(byte[] value, int startIndex, ByteOrder from, ByteOrder to, int length)
    {
      var valueEndianess = new byte[length];
      Array.Copy(value, startIndex, valueEndianess, 0, length);
      if (from != to)
      {
        Array.Reverse(valueEndianess);
      }

      return valueEndianess;
    }
  }
}