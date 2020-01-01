### C语言—1000以内所有的完数
```c
#include <stdio.h>

void main()
{
	// 一个数如果恰好等于它的因子之和，这个数就称为“完数”例如6 = 1＋2＋3.
	// 编程找出1000以内的所有完数。
	int i,j,sum;
	for (i = 2; i <= 1000; i++)
	{
		sum = 0;
		for (j = 1; j <= i/2; j++)// 不要忘了'='号
		{
			if (i%j==0)
			{
				sum += j;
			}
		}
		if (sum==i)
		{
			printf("%d\n", i);
		}
	}
}

```