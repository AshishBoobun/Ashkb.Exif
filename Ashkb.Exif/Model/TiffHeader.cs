using System;
using System.IO;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif.Model
{
  public class TiffHeader
  {
    private const int TiffHeaderByteLength = 8;

    private const ushort TiffVersionNumber = 0x002A;

    private TiffHeader(ByteOrder byteOrder, uint offsetOfIfd0)
    {
      ByteOrder = byteOrder;
      OffsetOfIfd0 = offsetOfIfd0;
      VersionNumber = TiffVersionNumber;
    }

    public ushort VersionNumber { get; }

    public ByteOrder ByteOrder { get; }

    public uint OffsetOfIfd0 { get; }


    /// <summary>
    ///   Analyse the 8 bytes of the stream content starting from the <paramref name="offset" /> to determine if it has a valid
    ///   TIFF header. The method return a boolean to denote if conversion was successful
    /// </summary>
    /// <param name="stream">stream content to analyse TIFF header </param>
    /// <param name="offset">offset position from the start of stream to analyse 8 bytes</param>
    /// <param name="header">
    ///   When this method returns, output parameter contains the TIFF header based on the supplied stream,
    ///   if the conversion succeeded, or null if the conversion failed.
    /// </param>
    /// <returns>true if stream was converted successfully; otherwise false</returns>
    public static bool TryParse(Stream stream, int offset, out TiffHeader header)
    {
      header = null;
      try
      {
        ByteOrder byteOrder;
        var headerBytes = new byte[TiffHeaderByteLength];
        stream.Seek(offset, SeekOrigin.Begin);
        stream.Read(headerBytes, 0, TiffHeaderByteLength);

        var endianess = Utility.Combine(headerBytes[0], headerBytes[1]);
        if (typeof(ByteOrder).IsEnumDefined(endianess))
        {
          byteOrder = (ByteOrder) Utility.Combine(headerBytes[0], headerBytes[1]);
        }
        else
        {
          return false;
        }

        if (BitConverterExtension.ToUInt16(headerBytes, 2, byteOrder, BitConverterExtension.SystemByteOrder) !=
            TiffVersionNumber)
        {
          return false;
        }

        var offsetOfIfd0 =
          BitConverterExtension.ToUInt32(headerBytes, 4, byteOrder, BitConverterExtension.SystemByteOrder);

        header = new TiffHeader(byteOrder, offsetOfIfd0);
        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }
  }
}