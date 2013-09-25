namespace Supermarket.Client
{
    using Ionic.Zip;
    using System;
    using System.IO;

    public static class ZipManager
    {
        public static void Unzip(string zipPath, string extractPath)
        {
            ZipFile zip = ZipFile.Read(zipPath);
            zip.ExtractAll(extractPath);
        }

        public static void DeleteTempFiles(string path)
        {
            DirectoryInfo rootDir = new DirectoryInfo(path);
            rootDir.Delete(true);
        }
    }
}
