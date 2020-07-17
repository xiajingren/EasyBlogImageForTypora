# EasyBlogImageForTypora

> 使用Typora写作，图片即时同步到博客网站，无需第三方图床，写完可直接粘贴。支持网络图片上传。

## 适用范围

本程序基于.net core 3.1开发，支持在win-x64，mac osx-x64系统运行，免安装。linux暂时不考虑，如果有需要再说。

程序的上传服务是使用MetaWebBlog API，MetaWebBlog API(MWA)是一个Blog程序的接口标准，理论上支持MetaWebBlog API标准的博客网站，都可以使用本程序来上传图片，你只需要在程序中配置一下你的博客基本信息即可。目前我自己测试通过的有博客园、开源中国（oschina)；CSDN的接口貌似不能用了。

## 如何使用

### windows

1. 下载程序：

   https://github.com/xiajingren/EasyBlogImageForTypora/releases/

   下载zip文件，解压到合适的目录。

   github访问慢的话去蓝奏云也可以：

   https://wws.lanzous.com/b01hidfwh
   密码:6jnm

2. 配置博客参数：

   运行程序，按照界面提示输入配置信息。完成后退出就行，参数只需配置一次，如果以后要修改的话再次运行即可。

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711204347215-519142653.png)

3. Typora设置：
   
   Typora进入偏好设置-图像，选择插入图片时上传图片。上传服务选择Custom command，自定义命令填写EasyBlogImageForTypora所在路径，我这里是D:\EasyBlogImageForTypora\EasyBlogImageForTypora.exe

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200717164400677-1873636259.png)

   配置完成后点击验证图片上传选项：

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711115937146-467789165.png)

   出现验证成功就ok了。

### macOS

1. 下载安装.net core运行时：

   https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-3.1.5-macos-x64-installer

   下载完安装一下就好，文件很小才28M。

剩下的步骤和windows一样。

![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711173418486-1017714538.png)

![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711173720907-628520961.png)

![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711173830080-1995768272.png)



------

博客园：https://www.cnblogs.com/xhznl/p/13285420.html

可以给个star哦。。。

