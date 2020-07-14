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
                Utils.Instance.Output("Please initialize the program configuration first!!!");
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
                var fileName = image;
                try
                {
                    if (Utils.Instance.IsUrl(fileName))
                    {
                        fileName = Utils.Instance.DownloadFileAsync(fileName).GetAwaiter().GetResult();
                    }

                    var fileInfo = new FileInfo(fileName);
                    var mediaObject = client.NewMediaObject(fileInfo.Name, Utils.Instance.GetMimeType(fileInfo), File.ReadAllBytes(fileName));
                    Utils.Instance.Output(mediaObject.URL);
                }
                catch (Exception e)
                {
                    Utils.Instance.Output(e);
                }
            }
        }
    }
}
