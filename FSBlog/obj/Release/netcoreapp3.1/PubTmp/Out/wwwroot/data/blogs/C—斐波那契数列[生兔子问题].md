### C语言—斐波那契数列[生兔子问题]
```c
#include <stdio.h>

void main()
{
	// 斐波那契数列[生兔子问题]
	long i,f1 = 1,f2 = 1,t;	//t用来计算前两个月数量之和
	for (i = 1; i <= 10; i++)//i<=n，n代表求的是前几个月的对数。
	{
		printf("%ld\t", f1);
		t = f1;
		f1 = f2;
		f2 = t + f1;
		if (i%4==0)			//用来换行
		{
			printf("\n");
		}
	}
}
```