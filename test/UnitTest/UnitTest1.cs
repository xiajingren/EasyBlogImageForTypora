using System.IO;
using EasyBlogImageForTypora.Common;
using EasyBlogImageForTypora.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mimeType = Utils.Instance.GetMimeType(new FileInfo("C:\\Users\\xiajr\\AppData\\Local\\Temp/typora-icon2.PNG"));
            Assert.IsNotNull(mimeType);
        }

        [TestMethod]
        public void TestMethod2()
        {
            BlogImageService.Instance.UploadImage(new string[]{ "C:\\Users\\xiajr\\AppData\\Local\\Temp/typora-icon2.PNG",
                "C:\\Users\\xiajr\\AppData\\Local\\Temp/typora-icon.PNG" });
        }

        [TestMethod]
        public void TestMethod3()
        {
            Utils.Instance.DownloadFile("https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1594647519727&di=b28042060a6671590c0b57ce310aa8aa&imgtype=0&src=http%3A%2F%2Ft8.baidu.com%2Fit%2Fu%3D3571592872%2C3353494284%26fm%3D79%26app%3D86%26f%3DJPEG%3Fw%3D1200%26h%3D1290", "");
            Utils.Instance.DownloadFile("https://gitee.com/xhznl/Blog.Images/raw/master/images/image-20200629210341489.png", "");
            Utils.Instance.DownloadFile("https://xhznl-blogs-bucket.oss-cn-beijing.aliyuncs.com/images/20200702120235.png", "");
            Utils.Instance.DownloadFile("https://img2020.cnblogs.com/blog/610959/202007/610959-20200711204347215-519142653.png?xx=111.jpg", "");
        }
    }
}
