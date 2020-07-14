using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyBlogImageForTypora.Common
{
    public class AppConfig
    {
        public static readonly string ConfigFilePath = Path.Combine(AppContext.BaseDirectory, "config.json");

        public static readonly string LogsPath = Path.Combine(AppContext.BaseDirectory, "logs.txt");

        public static string TempPath
        {
            get
            {
                var tempPath = Path.Combine(AppContext.BaseDirectory, "temp");

                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                return tempPath;
            }
        }

    }
}
