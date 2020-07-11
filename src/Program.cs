using System;
using EasyBlogImageForTypora.Core;

namespace EasyBlogImageForTypora
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("==                                                                    ==");
                Console.WriteLine("==                欢迎使用 EasyBlogImageForTypora v1.0                ==");
                Console.WriteLine("==                                                                    ==");
                Console.WriteLine("==                    常用的博客MetaWeblog API地址：                  ==");
                Console.WriteLine("==       博客园： https://rpc.cnblogs.com/metaweblog/你的博客名       ==");
                Console.WriteLine("==           CSDN： http://write.blog.csdn.net/xmlrpc/index           ==");
                Console.WriteLine("==      开源中国（oschina)：https://my.oschina.net/action/xmlrpc      ==");
                Console.WriteLine("==          51cto：http://imguowei.blog.51cto.com/xmlrpc.php          ==");
                Console.WriteLine("==             网易（163）：http://os.blog.163.com/word/              ==");
                Console.WriteLine("==                        其他请自行搜索......                        ==");
                Console.WriteLine("==                                                                    ==");
                Console.WriteLine("==  如有问题或建议，可以搜索微信公众号【小黑在哪里】，即可联系作者。  ==");
                Console.WriteLine("==                                                                    ==");
                Console.WriteLine("==        https://github.com/xiajingren/EasyBlogImageForTypora        ==");
                Console.WriteLine("==                                                                    ==");
                Console.WriteLine("==                      Powered by .NET Core 3.1                      ==");
                Console.WriteLine("==                                                                    ==");
                Console.WriteLine("========================================================================");
                Console.WriteLine(Environment.NewLine + Environment.NewLine);

                var blogConfig = BlogConfigService.Instance.LoadBlogConfig();

                if (blogConfig != null)
                {
                    Console.WriteLine("您的当前配置：" + blogConfig.ToString());

                    Console.WriteLine("若要修改配置，请按1...");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        BlogConfigService.Instance.InitBlogConfig();
                    }
                }
                else
                {
                    BlogConfigService.Instance.InitBlogConfig();
                }

                Console.WriteLine("请按任意键退出程序...");
                Console.ReadKey();

                return;
            }

            BlogImageService.Instance.UploadImage(args);
        }
    }
}
