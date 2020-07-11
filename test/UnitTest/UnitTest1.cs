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
    }
}
