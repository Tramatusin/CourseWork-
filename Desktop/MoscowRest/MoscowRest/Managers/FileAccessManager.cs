using System;
using Xamarin.Essentials;

namespace MoscowRest.Managers
{
    public class FileAccessManager
    {
        /// <summary>
        /// Получение локального пути к файлам.
        /// </summary>
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
