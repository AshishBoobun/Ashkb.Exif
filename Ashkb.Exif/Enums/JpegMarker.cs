namespace Ashkb.Exif.Enums
{
    public enum JpegMarker
    {
    /// <summary>
    /// Start of compressed data - SOI
    /// </summary>
    StartOfImage = 0xFFD8,

    /// <summary>
    /// Exif attribute information - APP1
    /// </summary>
    ApplicationSegment1 =  0xFFE1,

    /// <summary>
    /// Exif extended data - APP2
    /// </summary>
    ApplicationSegment2 =  0xFFE2,

    /// <summary>
    /// Quantization table definition - DQT
    /// </summary>
    DefineQuantizationTable = 0xFFDB,

    /// <summary>
    /// Huffman table definition - DHT
    /// </summary>
    DefineHuffmanTable = 0xFFC4,

    /// <summary>
    /// Restart Interoperability definition - SRI
    /// </summary>
    DefineRestartInteroperability = 0xFFDD,

    /// <summary>
    /// Parameter data relating to frame - SOF
    /// </summary>
    StartOfFrame = 0xFFC0,

    /// <summary>
    /// Parameters relating to components - SOS
    /// </summary>
    StartOfScan = 0xFFDA,

    /// <summary>
    /// End of compressed data - EOI
    /// </summary>
    EndOfImage = 0xFFD9 
      

    }
}
