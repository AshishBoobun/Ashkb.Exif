using Ashkb.Exif.Enums;

namespace Ashkb.Exif.Model
{
  /// <summary>
  ///   The class represents a field recording ancillary data about an image
  /// </summary>
  public class Tag
  {
    /// <summary>
    ///   Unique 2-byte number to identify the field
    /// </summary>
    public int Number { get; set; }

    public string Name { get; set; }

    /// <summary>
    ///   Data format type for tag
    /// </summary>
    public DataFormat Format { get; set; }

    /// <summary>
    ///   The value for the current exif tag
    /// </summary>
    public dynamic Value { get; set; }
  }
}