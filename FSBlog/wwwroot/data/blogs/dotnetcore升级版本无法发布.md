### .NET Ccore2.2升级.NET Core 3.1发布报错
#### 前言
.NET Core 3.1是长期维护版本，所以将老版本的项目从2.2升级至3.1，修改了许多地方后，在发布时遇到 <font color='red'>资产文件&ldquo;\obj\project.assets.json&rdquo;没有&ldquo;.NETCoreApp,Version=v2.1&rdquo;的目标。确保已运行还原，且&ldquo;netcoreapp2.1&rdquo;已包含在项目的 TargetFrameworks 中。</font> 的错误
#### 错误提示
资产文件&ldquo;\obj\project.assets.json&rdquo;没有&ldquo;.NETCoreApp,Version=v2.1&rdquo;的目标。确保已运行还原，且&ldquo;netcoreapp2.1&rdquo;已包含在项目的 TargetFrameworks 中
#### 解决方法

在项目中找到Properties -> PublishProfiles -> FolderProfile.pubxml文件
![20200126212639.png](https://i.loli.net/2020/01/26/3fIRMbvjYZoTmPr.png)

更改TargetFramework中内容为netcoreapp3.1
![20200126213005.png](https://i.loli.net/2020/01/26/BtpmKToCRYeHbcG.png)