using System;
using System.Globalization;
using EasyBlogImageForTypora.Common;
using EasyBlogImageForTypora.Core;

namespace EasyBlogImageForTypora
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.Instance.Output(DateTime.Now.ToString(CultureInfo.InvariantCulture), false);
            Utils.Instance.Output(string.Join(Environment.NewLine, args), false);

            if (args.Length == 0)
            {
                Utils.Instance.Output("========================================================================");
                Utils.Instance.Output("==                                                                    ==");
                Utils.Instance.Output("==                欢迎使用 EasyBlogImageForTypora v1.2                ==");
                Utils.Instance.Output("==                                                                    ==");
                Utils.Instance.Output("==                    常用的博客MetaWeblog API地址：                  ==");
                Utils.Instance.Output("==       博客园： https://rpc.cnblogs.com/metaweblog/你的博客名       ==");
                Utils.Instance.Output("==      开源中国（oschina)：https://my.oschina.net/action/xmlrpc      ==");
                Utils.Instance.Output("==         自建WordPress站点：http://你的博客地址/xmlrpc.php          ==");
                Utils.Instance.Output("==                        其他请自行搜索......                        ==");
                Utils.Instance.Output("==                                                                    ==");
                Utils.Instance.Output("==  如有问题或建议，可以搜索微信公众号【小黑在哪里】，即可联系作者。  ==");
                Utils.Instance.Output("==                                                                    ==");
                Utils.Instance.Output("==        https://github.com/xiajingren/EasyBlogImageForTypora        ==");
                Utils.Instance.Output("==                                                                    ==");
                Utils.Instance.Output("==                      Powered by .NET Core 3.1                      ==");
                Utils.Instance.Output("==                                                                    ==");
                Utils.Instance.Output("========================================================================");
                Utils.Instance.Output(Environment.NewLine + Environment.NewLine);

                var blogConfig = BlogConfigService.Instance.LoadBlogConfig();

                if (blogConfig != null)
                {
                    Utils.Instance.Output("您的当前配置：" + blogConfig.ToString());

                    Utils.Instance.Output("若要修改配置，请按1...");
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

                Utils.Instance.Output("请按任意键退出程序...");
                Console.ReadKey();

                return;
            }

            BlogImageService.Instance.UploadImage(args);
        }
    }
}
