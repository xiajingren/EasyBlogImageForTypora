# 背景

习惯使用markdown的人应该都知道Typora这个神器，它非常简洁高效。虽然博客园的在线markdown编辑器也不错，但毕竟是网页版，每次写东西需要登录系统-进后台-找到文章-编辑-保存草稿。。。非常难受。。。

但是使用Typora来写的话，文章图片又是个问题，本地写完粘贴到网站上，图片全丢。。。

大多数解决方案是Typora+PicGo+第三方图床，图床有收费的和免费的，总结一下几个常用的：

- 七牛云

  专业，快速，有免费的存储空间。但是免费域名有使用期限，到期后需要自己备案域名。。。

- 阿里云oss

  专业，快速，存储空间便宜，一年9块钱40G。但是下行流量需要另外收费。。。

- github

  免费。但不是专业图床，国内访问速度太慢。。。

- gitee

  免费，快速。但不是专业图床，有防盗链风险，比如微信浏览器就打不开gitee的图，gitee官方是禁止用来做图床的。。。

。。。。。。

其实Typora除了支持PicGo上传图片以外，还支持自定义上传服务。于是自己写了个简单程序，在本地写作时，直接把图片传到自己的博客网站，就不用折腾各种第三方图床了，写完直接可以粘贴到网站。



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

   Typora进入偏好设置-图像，上传服务选择Custom command，自定义命令填写EasyBlogImageForTypora所在路径，我这里是D:\EasyBlogImageForTypora\EasyBlogImageForTypora.exe

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711115414497-1150081517.png)

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

