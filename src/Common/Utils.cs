using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyBlogImageForTypora.Common
{
    public class Utils
    {
        public static readonly Utils Instance = new Utils();

        private static readonly string AESKey = "82104588cc4340ad9462bde759c5064f";

        private Utils() { }

        private static readonly HashSet<MimeTypeValue> MimeDictionary = new HashSet<MimeTypeValue>()
        {
            new MimeTypeValue(".bmp","image/x-ms-bmp"),
            new MimeTypeValue(".jpg","image/jpeg"),
            new MimeTypeValue(".jpeg","image/jpeg"),
            new MimeTypeValue(".gif","image/gif"),
            new MimeTypeValue(".png","image/png"),
            new MimeTypeValue(".tif  ","image/tiff"),
            new MimeTypeValue(".tiff ","image/tiff"),
            new MimeTypeValue(".tga","image/x-targa"),
            new MimeTypeValue(".psd","image/vnd.adobe.photoshop"),
            new MimeTypeValue(".ico  ","image/x-icon"),
            new MimeTypeValue(".","application/octet-stream")
        };

        /// <summary>
        /// 获取mime类型
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string GetMimeType(FileInfo file)
        {
            var eLower = file.Extension.ToLower();

            var mime = MimeDictionary.FirstOrDefault(p => p.Extension == eLower);

            return mime == null ? MimeDictionary.FirstOrDefault(p => p.Extension == ".")?.MimeType : mime.MimeType;
        }

        /// <summary>
        /// 获取扩展名
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public string GetExtension(string mimeType)
        {
            return MimeDictionary.FirstOrDefault(p => p.MimeType == mimeType)?.Extension;
        }

        /// <summary>  
        /// AES加密  
        /// </summary>
        public string AESEncrypt(string value)
        {
            var keyArray = Encoding.UTF8.GetBytes(AESKey);
            var toEncryptArray = Encoding.UTF8.GetBytes(value);

            var rDel = new RijndaelManaged
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = rDel.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>  
        /// AES解密  
        /// </summary>
        public string AESDecrypt(string value)
        {
            var rDel = new RijndaelManaged();
            try
            {
                var keyArray = Encoding.UTF8.GetBytes(AESKey);
                var toEncryptArray = Convert.FromBase64String(value);

                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                var cTransform = rDel.CreateDecryptor();
                var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 判断一个字符串是否为url
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http(s)?://[^\s]*";
                return Regex.IsMatch(str, Url);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="callback"></param>
        public string DownloadFile(string url, string fileName = null, Action<int> callback = null)
        {
            var request = WebRequest.Create(url);
            using var response = request.GetResponse();

            if (string.IsNullOrEmpty(fileName))
            {
                var extension = GetExtension(response.ContentType);
                fileName = DateTime.Now.Ticks + extension;
                fileName = Path.Combine(AppConfig.TempPath, fileName);
            }

            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }

            using var writer = File.OpenWrite(fileName);
            var buff = new byte[1024];
            using var responseStream = response.GetResponseStream();
            decimal downloadedTotal = 0;
            int l;
            while (responseStream != null && (l = responseStream.Read(buff, 0, buff.Length)) > 0)
            {
                writer.Write(buff, 0, l);
                writer.Flush();

                downloadedTotal += l;
                var progress = (int)(downloadedTotal / response.ContentLength * 100);

                callback?.Invoke(progress);
            }
            response.Close();
            writer.Close();
            responseStream?.Close();

            return fileName;
        }

        public async Task<string> DownloadFileAsync(string url, string fileName = null, Action<int> callback = null)
        {
            return await Task.Run(() => DownloadFile(url, fileName, callback));
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isWrite"></param>
        public void Output(string str, bool isWrite = true)
        {
#if DEBUG
            File.AppendAllText(AppConfig.LogsPath, str + Environment.NewLine);
#endif

            if (isWrite)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="e"></param>
        /// <param name="isWrite"></param>
        public void Output(Exception e, bool isWrite = true)
        {
            var str = e.ToString();

#if DEBUG
            File.AppendAllText(AppConfig.LogsPath, str + Environment.NewLine);
#endif

            if (isWrite)
            {
                Console.WriteLine(str);
            }
        }

        class MimeTypeValue
        {
            public MimeTypeValue(string extension, string mimeType)
            {
                Extension = extension;
                MimeType = mimeType;
            }

            public string Extension { get; set; }

            public string MimeType { get; set; }
        }
    }
}
