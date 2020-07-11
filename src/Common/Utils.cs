using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EasyBlogImageForTypora.Common
{
    public class Utils
    {
        public static readonly Utils Instance = new Utils();

        private static readonly string AESKey = "82104588cc4340ad9462bde759c5064f";

        private Utils() { }

        private static readonly Dictionary<string, string> MimeDictionary = new Dictionary<string, string>()
        {
            {".png","image/png"},
            {".jpe","image/jpeg"},
            {".jpg","image/jpeg"},
            {".jpeg","image/jpeg"},
            {".ico","image/x-icon"},
            {".bmp","image/bmp"},
            {".gif","image/gif"},
            {".*", "application/octet-stream"}
        };

        /// <summary>
        /// 获取mime类型
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string GetMimeType(FileInfo file)
        {
            try
            {
                var eLower = file.Extension.ToLower();

                if (MimeDictionary.ContainsKey(eLower))
                {
                    return MimeDictionary[eLower];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return MimeDictionary[".*"];
            }
            return MimeDictionary[".*"];
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
                Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7
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
    }
}
