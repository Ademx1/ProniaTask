﻿namespace RiodeP137.Extentions
{
    public static class FIleExtension
    {
        public static bool CheckFileType(this IFormFile file, string key)
        {
            return file.ContentType.Contains(key);
        }
        public static string CutFileName(this IFormFile file, int maxSize = 60)
        {
            if (file.FileName.Length > maxSize)
            {
                return file.FileName.Substring(file.FileName.Length - maxSize);
            }
            return file.FileName;
        }
        public static bool CheckFileSize(this IFormFile file, ulong mb)
        {

            return (ulong)file.Length < mb * 1024 * 1024;

        }
        public static void SaveFile(this IFormFile file, string path)
        {
            path = Path.Combine(RiodeP137.Constant.Constant.RoothPath, path);
            using (var writer = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(writer);
            }
        }
    }
}