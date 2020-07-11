# EasyBlogImageForTypora

## 适用范围

本程序基于.net core 3.1开发，支持在win-x64，mac osx-x64系统运行，免安装。linux暂时不考虑。

程序的上传服务是使用MetaWebBlog API，MetaWebBlog API(MWA)是一个Blog程序的接口标准，理论上支持MetaWebBlog API标准的博客网站，都可以使用本程序来上传图片。你只需要在程序中配置一下你的博客基本信息即可。

## 如何使用

1. 下载程序：

   https://github.com/xiajingren/EFDynamicDatabaseBuilding

   下载自己系统对应的文件，解压到合适的目录。

2. 配置博客参数：

   以windows为例，运行程序，按照界面提示输入配置信息。完成后退出就行，参数只需配置一次，如果以后要修改的话再次运行即可。

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711114549671-1480666896.png)

3. Typora配置：

   Typora进入偏好设置，上传服务选择Custom command，自定义命令填写EasyBlogImageForTypora所在路径，我这里是D:\EasyBlogImageForTypora\EasyBlogImageForTypora.exe

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711115414497-1150081517.png)

   配置完成后点击验证图片上传选项：

   ![](https://img2020.cnblogs.com/blog/610959/202007/610959-20200711115937146-467789165.png)

   出现验证成功就ok了，赶紧体验一下吧。