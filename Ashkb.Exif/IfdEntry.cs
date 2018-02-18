using System;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif
{
  public class IfdEntry
  {
    private const int IfdEntryValueByteLength = 4;

    private IfdEntry(ushort tag, ushort type, uint count, byte[] value)
    {
      Tag = tag;
      Type = type;
      Count = count;
      Value = value;
    }

    public ushort Tag { get; }

    public ushort Type { get; }

    public uint Count { get; }

    public byte[] Value { get; }

    public static IfdEntry ParseFromByte(byte[] imageData, int startIndex, ByteOrder byteOrder)
    {
      var typeValue =
        BitConverterExtension.ToUInt16(imageData, startIndex + 2, byteOrder, BitConverterExtension.SystemByteOrder);
      if (!typeof(FieldType).IsEnumDefined(typeValue))
      {
        throw new ArgumentOutOfRangeException("Invalid field type value");
      }

      var tag = BitConverterExtension.ToUInt16(imageData, startIndex, byteOrder, BitConverterExtension.SystemByteOrder);
      var count = BitConverterExtension.ToUInt32(imageData, startIndex + 4, byteOrder,
        BitConverterExtension.SystemByteOrder);
      var value = BitConverterExtension.CopyArrayEndianness(imageData, startIndex + 8, byteOrder,
        BitConverterExtension.SystemByteOrder,
        IfdEntryValueByteLength);
      var valueLength = FieldTypeHelper.GetFieldTypeByteLength((FieldType) typeValue) * (int) count;

      if (valueLength > IfdEntryValueByteLength)
      {
        var valueOffset = BitConverterExtension.ToUInt32(value, 0, byteOrder, BitConverterExtension.SystemByteOrder);
        value = BitConverterExtension.CopyArrayEndianness(imageData, (int) valueOffset, byteOrder,
          BitConverterExtension.SystemByteOrder,
          valueLength);
      }

      return new IfdEntry(tag, typeValue, count, value);
    }
  }
}