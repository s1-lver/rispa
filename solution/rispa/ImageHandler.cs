using ImageMagick; 
using System.Text;
using System.Text.Json;

namespace rispa;

public class ImageMetadata
{
    public DateTime? DateTimeTaken { get; set; }
    public string? CameraMake { get; set; }
    public string? CameraModel { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
public static class ImageHandler
{
    public static (bool, Exception?) ValidateImage(string path) 
    {
        if (!File.Exists(path)) 
        {
            return (false, new FileNotFoundException());
        }
        
        try
        {
            using var img = Image.FromFile(path);
            return (true, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }

    public static Image LoadImageFromPath(string imgPath)
    {
        return Image.FromFile(imgPath);
    }

    public static Image? GenerateImage(Image img) // & GenerationOptions options
    {
        // placeholder functionality for testing
        var newImg = img;
        
        return newImg;
    }

    public static (bool, Exception?) SaveImage(Image img, string path)
    {
        try
        {
            if (File.Exists(path)) File.Delete(path);
            img.Save(path);
            return  (true, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }
    
    public static ImageMetadata GetImageMetadata(string imagePath)
{
    var metadata = new ImageMetadata();

    try
    {
        using var image = new MagickImage(imagePath);
        var exifProfile = image.GetExifProfile();

        if (exifProfile != null)
        {
            // Extract DateTime
            var dateTime = exifProfile.GetValue(ExifTag.DateTimeOriginal);
            if (dateTime?.Value != null)
            {
                if (DateTime.TryParseExact(dateTime.Value, "yyyy:MM:dd HH:mm:ss",
                                          null, System.Globalization.DateTimeStyles.None, out var dt))
                {
                    metadata.DateTimeTaken = dt;
                }
            }

            // Extract camera information
            var make = exifProfile.GetValue(ExifTag.Make);
            if (make?.Value != null)
                metadata.CameraMake = make.Value.Trim();

            var model = exifProfile.GetValue(ExifTag.Model);
            if (model?.Value != null)
                metadata.CameraModel = model.Value.Trim();

            // Extract GPS data
            var latRef = exifProfile.GetValue(ExifTag.GPSLatitudeRef)?.Value;
            var latVal = exifProfile.GetValue(ExifTag.GPSLatitude)?.Value;
            var longRef = exifProfile.GetValue(ExifTag.GPSLongitudeRef)?.Value;
            var longVal = exifProfile.GetValue(ExifTag.GPSLongitude)?.Value;

            if (latRef != null && latVal != null)
                metadata.Latitude = ParseGpsCoordinate(latVal, latRef == "S");

            if (longRef != null && longVal != null)
                metadata.Longitude = ParseGpsCoordinate(longVal, longRef == "W");
        }
    }
    catch (Exception)
    {
        // Handle errors gracefully
    }

    return metadata;
}

private static double ParseGpsCoordinate(Rational[] dmsValue, bool isNegative)
{
    try
    {
        if (dmsValue.Length >= 3)
        {
            double degrees = dmsValue[0].ToDouble();
            double minutes = dmsValue[1].ToDouble() / 60;
            double seconds = dmsValue[2].ToDouble() / 3600;

            double coordinate = degrees + minutes + seconds;
            return isNegative ? -coordinate : coordinate;
        }
    }
    catch { }

    return 0;
}

public static DialogResult EditMetadata(ref ImageMetadata metadata)
{
    using var form = new MetadataEditorForm(metadata);
    return form.ShowDialog();
}

public static (bool, Exception?) SaveImageWithMetadata(string sourceImagePath, ImageMetadata metadata, string outputPath)
{
    try
    {
        using var image = new MagickImage(sourceImagePath);

        // Get or create Exif profile
        var exifProfile = image.GetExifProfile() ?? new ExifProfile();

        // Update metadata
        if (metadata.DateTimeTaken.HasValue)
            exifProfile.SetValue(ExifTag.DateTimeOriginal, metadata.DateTimeTaken.Value.ToString("yyyy:MM:dd HH:mm:ss"));

        if (!string.IsNullOrEmpty(metadata.CameraMake))
            exifProfile.SetValue(ExifTag.Make, metadata.CameraMake);

        if (!string.IsNullOrEmpty(metadata.CameraModel))
            exifProfile.SetValue(ExifTag.Model, metadata.CameraModel);

        // Set GPS data
        if (metadata.Latitude.HasValue && metadata.Longitude.HasValue)
        {
            // Set latitude
            double latAbs = Math.Abs(metadata.Latitude.Value);
            int latDeg = (int)latAbs;
            double latMin = ((latAbs - latDeg) * 60);
            double latSec = (latAbs - latDeg - latMin / 60.0) * 3600;
            var r_latDeg = new Rational(latAbs, true);
            var r_latMin = new Rational(latMin, true);
            var r_latSec = new Rational(latSec, true);

            exifProfile.SetValue(ExifTag.GPSLatitudeRef, metadata.Latitude >= 0 ? "N" : "S");
            exifProfile.SetValue(ExifTag.GPSLatitude, [r_latDeg, r_latMin, r_latSec]);

            // Set longitude
            double lngAbs = Math.Abs(metadata.Longitude.Value);
            int lngDeg = (int)lngAbs;
            double lngMin = ((lngAbs - lngDeg) * 60);
            double lngSec = (lngAbs - lngDeg - lngMin / 60.0) * 3600;

            exifProfile.SetValue(ExifTag.GPSLongitudeRef, metadata.Longitude >= 0 ? "E" : "W");
            var r_lngDeg = new Rational(lngAbs, true);
            var r_lngMin = new Rational(lngMin, true);
            var r_lngSec = new Rational(lngSec, true);
            
            exifProfile.SetValue(ExifTag.GPSLongitude, [r_lngDeg,r_lngMin,r_lngSec]);
        }

        // Apply profile and save
        image.SetProfile(exifProfile);
        image.Write(outputPath);

        return (true, null);
    }
    catch (Exception ex)
    {
        return (false, ex);
    }
}
}