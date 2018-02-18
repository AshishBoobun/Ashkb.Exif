using System.Collections.Generic;
using Ashkb.Exif.Enums;

namespace Ashkb.Exif
{
  public class ImageFileDirectory
  {
    private static readonly ushort NumberOfFieldsByteLength = 2;

    private static readonly ushort IfdEntryByteLength = 12;
    public ushort NumberOfIfdEntries { get; set; }

    public uint NextIfdOffset { get; set; }

    public List<IfdEntry> IfdEntries { get; set; }


    public static ImageFileDirectory ParseFromImageData(byte[] imageData, int startIndex, ByteOrder byteOrder)
    {
      var ifd = new ImageFileDirectory
      {
        NumberOfIfdEntries =
          BitConverterExtension.ToUInt16(imageData, startIndex, byteOrder, BitConverterExtension.SystemByteOrder)
      };

      ifd.IfdEntries = new List<IfdEntry>(ifd.NumberOfIfdEntries);

      for (var i = 0; i < ifd.NumberOfIfdEntries; i++)
      {
        var ifdEntry = IfdEntry.ParseFromByte(imageData, startIndex + NumberOfFieldsByteLength + IfdEntryByteLength * i,
          byteOrder);
        ifd.IfdEntries.Add(ifdEntry);
      }

      ifd.NextIfdOffset = BitConverterExtension.ToUInt32(imageData,
        startIndex + NumberOfFieldsByteLength + IfdEntryByteLength * ifd.NumberOfIfdEntries, byteOrder,
        BitConverterExtension.SystemByteOrder);

      return ifd;
    }
  }
}