namespace Ashkb.Exif.Enums
{
  public enum JpegMarker
  {
    /// <summary>
    ///   Marker prefix
    /// </summary>
    MarkerPrefix = 0xFF,

    /// <summary>
    ///   Start of compressed data - SOI
    /// </summary>
    StartOfImage = 0xD8,

    /// <summary>
    ///   Exif attribute information - APP1
    /// </summary>
    ApplicationSegment1 = 0xE1,

    /// <summary>
    ///   Exif extended data - APP2
    /// </summary>
    ApplicationSegment2 = 0xE2,

    /// <summary>
    ///   Quantization table definition - DQT
    /// </summary>
    DefineQuantizationTable = 0xDB,

    /// <summary>
    ///   Huffman table definition - DHT
    /// </summary>
    DefineHuffmanTable = 0xC4,

    /// <summary>
    ///   Restart Interoperability definition - SRI
    /// </summary>
    DefineRestartInteroperability = 0xDD,

    /// <summary>
    ///   Parameter data relating to frame - SOF
    /// </summary>
    StartOfFrame = 0xC0,

    /// <summary>
    ///   Parameters relating to components - SOS
    /// </summary>
    StartOfScan = 0xDA,

    /// <summary>
    ///   End of compressed data - EOI
    /// </summary>
    EndOfImage = 0xD9
  }
}