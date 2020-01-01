### C语言—判断素数
```c
#include <stdio.h>
#include <math.h>

void main()
{
	// 判断101 - 200之间有多少个素数，并输出所有素数及素数的个数。
	// 素数如：2,3,5,7,11,13...
	int i,j,count = 0,flag;		//count计数器,flag标志为1则不是素数
	for (i = 101; i < 201; i++)
	{
		flag = 0;
		for (j = 2; j <= sqrt(i); j++)	//除从2到这个数的开方，注意j要<=这个数的开方
		{
			if (i%j==0)
			{
				flag = 1;
				break;
			}
		}
		if (!flag)
		{
			count++;
			printf("%d\t", i);
		}
	}
	printf("素数的个数为：%d", count);
}

```