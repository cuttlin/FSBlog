### VS2017如何使用scanf函数
#### 前言

> 在VS2017中使用scanf,报出  
> 错误	C4996	'scanf': This function or variable may be unsafe. Consider using scanf_s instead. To disable deprecation, use _CRT_SECURE_NO_WARNINGS. See online help for details.

#### 解决方法

在代码页首行加入如下代码

```C++
#define _CRT_SECURE_NO_WARNINGS
```