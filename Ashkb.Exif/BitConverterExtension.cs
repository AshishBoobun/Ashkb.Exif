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
      var valueEndianness = CopyArrayEndianness(value, startIndex, from, to, 4);
      return BitConverter.ToUInt32(valueEndianness, 0);
    }

    public static ushort ToUInt16(byte[] value, int startIndex, ByteOrder from, ByteOrder to)
    {
      var valueEndianness = CopyArrayEndianness(value, startIndex, from, to, 2);
      return BitConverter.ToUInt16(valueEndianness, 0);
    }

    /// <summary>
    ///   Copies a range of elements from an System.Array starting at the specified source index and pastes them to a new
    ///   System.Array. The length and the indexes are specified as 32-bit integers.
    /// </summary>
    /// <param name="value">The System.Array that contains the data to copy.</param>
    /// <param name="startIndex">A 32-bit integer that represents the index in the sourceArray at which copying begins.</param>
    /// <param name="from">The endianness order in which the <paramref name="value" /> is arranged </param>
    /// <param name="to">The endianness order in which to copy the value into a new array</param>
    /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
    /// <returns>new System.Array that contain copied data</returns>
    public static byte[] CopyArrayEndianness(byte[] value, int startIndex, ByteOrder from, ByteOrder to, int length)
    {
      var valueEndianness = new byte[length];
      Array.Copy(value, startIndex, valueEndianness, 0, length);
      if (from != to)
      {
        Array.Reverse(valueEndianness);
      }

      return valueEndianness;
    }
  }
}