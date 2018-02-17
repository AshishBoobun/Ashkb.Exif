using System;

namespace Ashkb.Exif.Enums
{
  public enum FieldType
  {
    /// <summary>
    ///   8-bit unsigned integer.
    /// </summary>
    Byte = 1,

    /// <summary>
    ///   8-bit byte that contains a 7-bit ASCII code; the last byte must be NUL (binary zero).
    /// </summary>
    Ascii = 2,

    /// <summary>
    ///   16-bit (2-byte) unsigned integer.
    /// </summary>
    Short = 3,

    /// <summary>
    ///   32-bit (4-byte) unsigned integer
    /// </summary>
    Long = 4,

    /// <summary>
    ///   Two LONGs: the first represents the numerator of a fraction; the second, the denominator
    /// </summary>
    Rational = 5,

    /// <summary>
    ///   An 8-bit signed (twos-complement) integer.
    /// </summary>
    SByte = 6,

    /// <summary>
    ///   An 8-bit byte that may contain anything, depending on the definition of the field.
    /// </summary>
    Undefined = 7,

    /// <summary>
    ///   A 16-bit (2-byte) signed (twos-complement) integer.
    /// </summary>
    SShort = 8,

    /// <summary>
    ///   A 32-bit (4-byte) signed (twos-complement) integer.
    /// </summary>
    SLong = 9,

    /// <summary>
    ///   Two SLONG’s: the first represents the numerator of a fraction, the second the denominator.
    /// </summary>
    SRational = 10,

    /// <summary>
    ///   Single precision (4-byte) IEEE format
    /// </summary>
    Float = 11,

    /// <summary>
    ///   Double precision (8-byte) IEEE format.
    /// </summary>
    Double = 12
  }

  public static class FieldTypeHelper
  {
    public static ushort GetFieldTypeByteLength(FieldType type)
    {
      switch (type)
      {
        case FieldType.Ascii:
        case FieldType.Byte:
        case FieldType.SByte:
        case FieldType.Undefined:
          return 1;

        case FieldType.SShort:
        case FieldType.Short:
          return 2;

        case FieldType.Float:
        case FieldType.Long:
        case FieldType.SLong:
          return 4;

        case FieldType.Double:
        case FieldType.Rational:
        case FieldType.SRational:
          return 8;

        default:
          throw new ArgumentException("Invalid FieldType value", nameof(type));
      }
    }
  }
}