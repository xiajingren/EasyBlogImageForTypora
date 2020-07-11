using System;
using System.IO;
using EasyBlogImageForTypora.Entity;
using Newtonsoft.Json;

namespace EasyBlogImageForTypora.Core
{
    public class BlogConfigService
    {
        public static readonly BlogConfigService Instance = new BlogConfigService();

        private static readonly string ConfigFilePath = Path.Combine(AppContext.BaseDirectory, "config.json");

        private BlogConfigService() { }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <returns></returns>
        public BlogConfig LoadBlogConfig()
        {
            if (!File.Exists(ConfigFilePath)) return null;

            try
            {
                var blogConfig = JsonConvert.DeserializeObject<BlogConfig>(File.ReadAllText(ConfigFilePath));

                return blogConfig;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                File.Delete(ConfigFilePath);
                return null;
            }
        }

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        /// <returns></returns>
        public BlogConfig InitBlogConfig()
        {
            File.Create(ConfigFilePath).Close();

            var blogConfig = new BlogConfig();

            Console.WriteLine("请配置您的博客参数：");

            Console.WriteLine("您的博客地址（例如 https://www.cnblogs.com/xhznl）：");
            blogConfig.BlogUrl = Console.ReadLine();

            Console.WriteLine("您的博客ID（例如 xhznl ）：");
            blogConfig.BlogId = Console.ReadLine();

            Console.WriteLine("您的博客用户名（例如 xhznl）：");
            blogConfig.UserName = Console.ReadLine();

            Console.WriteLine("您的博客密码（例如 ******）：");
            blogConfig.Password = Console.ReadLine();

            Console.WriteLine("博客MetaWeblog API地址（例如 https://rpc.cnblogs.com/metaweblog/xhznl）：");
            blogConfig.MetaWeblogUrl = Console.ReadLine();

            File.WriteAllText(ConfigFilePath, blogConfig.SerializeObject());

            Console.WriteLine("参数配置完成！");
            return blogConfig;
        }

    }
}
