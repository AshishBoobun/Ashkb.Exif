using System;

namespace Ashkb.Exif.Error
{
  public class InvalidImageFormatException : Exception
  {
    public InvalidImageFormatException() : base("Invalid image format.")
    {
    }

    public InvalidImageFormatException(string message) : base(message)
    {
    }
  }
}