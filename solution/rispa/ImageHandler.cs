using System.Drawing;
using System.IO;

namespace rispa;

public static class ImageHandler
{
    public static (bool, Exception?) ValidateImage(string path) 
    {
        if (File.Exists(path)) 
        {
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
        
        return (false, new FileNotFoundException());
    }

    public static Bitmap LoadBitmapFromPath(string imgPath)
    {
        return new Bitmap(imgPath);
    }
}