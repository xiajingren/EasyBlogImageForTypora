using System;
using System.IO;
using EasyBlogImageForTypora.Common;
using EasyBlogImageForTypora.Entity;
using Newtonsoft.Json;

namespace EasyBlogImageForTypora.Core
{
    public class BlogConfigService
    {
        public static readonly BlogConfigService Instance = new BlogConfigService();

        private BlogConfigService() { }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <returns></returns>
        public BlogConfig LoadBlogConfig()
        {
            if (!File.Exists(AppConfig.ConfigFilePath)) return null;

            try
            {
                var blogConfig = JsonConvert.DeserializeObject<BlogConfig>(File.ReadAllText(AppConfig.ConfigFilePath));

                return blogConfig;
            }
            catch (Exception e)
            {
                Utils.Instance.Output(e);
                File.Delete(AppConfig.ConfigFilePath);
                return null;
            }
        }

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        /// <returns></returns>
        public BlogConfig InitBlogConfig()
        {
            File.Create(AppConfig.ConfigFilePath).Close();

            var blogConfig = new BlogConfig();

            Utils.Instance.Output("请配置您的博客参数：");

            Utils.Instance.Output("您的博客地址（例如 https://www.cnblogs.com/xhznl）：");
            blogConfig.BlogUrl = Console.ReadLine();

            Utils.Instance.Output("您的博客ID（例如 xhznl ）：");
            blogConfig.BlogId = Console.ReadLine();

            Utils.Instance.Output("您的博客用户名（例如 xhznl）：");
            blogConfig.UserName = Console.ReadLine();

            Utils.Instance.Output("您的博客密码（例如 ******）：");
            blogConfig.Password = Console.ReadLine();

            Utils.Instance.Output("博客MetaWeblog API地址（例如 https://rpc.cnblogs.com/metaweblog/xhznl）：");
            blogConfig.MetaWeblogUrl = Console.ReadLine();

            File.WriteAllText(AppConfig.ConfigFilePath, blogConfig.SerializeObject());

            Utils.Instance.Output("参数配置完成！");
            return blogConfig;
        }

    }
}
