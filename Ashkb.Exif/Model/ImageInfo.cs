namespace Ashkb.Exif.Model
{
  public class ImageInfo
  {
    internal ImageInfo()
    {
    }

    public string Filename { get; set; }

    public Tag GetExifTag()
    {
      return null;
    }
  }
}