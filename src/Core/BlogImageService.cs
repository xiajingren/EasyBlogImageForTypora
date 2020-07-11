using System;
using System.IO;
using EasyBlogImageForTypora.Common;
using EasyBlogImageForTypora.Entity;
using MetaWeblogClient;

namespace EasyBlogImageForTypora.Core
{
    public class BlogImageService
    {
        public static readonly BlogImageService Instance = new BlogImageService();

        private BlogImageService() { }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="images"></param>
        public void UploadImage(string[] images)
        {
            var blogConfig = BlogConfigService.Instance.LoadBlogConfig();

            if (blogConfig == null)
            {
                Console.WriteLine("Please initialize the program configuration first!!!");
                return;
            }

            var blogConnectionInfo = new BlogConnectionInfo(
                blogConfig.BlogUrl,
                blogConfig.MetaWeblogUrl,
                blogConfig.BlogId,
                blogConfig.UserName,
                blogConfig.PasswordDecrypt
            );

            var client = new Client(blogConnectionInfo);

            foreach (var image in images)
            {
                try
                {
                    var fileInfo = new FileInfo(image);
                    var mediaObject = client.NewMediaObject(fileInfo.Name, Utils.Instance.GetMimeType(fileInfo), File.ReadAllBytes(image));
                    Console.WriteLine(mediaObject.URL);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
