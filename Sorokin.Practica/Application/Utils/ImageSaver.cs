using System.IO;

namespace Sorokin.Practica.Application.Utils;

public static class ImageSaver
{
    public static string GetFullPath(string localPath)
    {
        return Path.Combine(Environment.CurrentDirectory, "Images", localPath);
    }
}
