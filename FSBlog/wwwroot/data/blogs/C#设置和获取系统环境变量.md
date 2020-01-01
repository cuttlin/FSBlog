#C#设置和获取环境变量
1.前言
	
	本来想拿学校机房的Android编辑器直接粘到自己电脑上用，发现它的eclipse是
	32位的，而我的JDK是64位的，于是想到干脆装两个JDK，用C#做一个能够更改环
	境变量的程序
2.代码

Environment类下的静态方法
	
获取环境变量：
	
	public static string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target);
	参数:
    //   variable:
    //     环境变量名。
    //
    //   target:
   	//     System.EnvironmentVariableTarget 值之一，环境变量的位置。
		
设置环境变量：

	public static void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target);
	参数:
    //   variable:
    //     环境变量名。
    //
    //   value:
    //     要分配给 variable 的值。
    //
    //   target:
    //     System.EnvironmentVariableTarget 值之一，环境变量的位置。
PS：这个设置环境变量的方法不用重启电脑也能生效！ (如果不加第三个参数则只会修改当前进程的环境变量)