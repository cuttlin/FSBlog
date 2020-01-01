### C语言—杨辉三角
```c
#include <stdio.h>

void main()
{
	// 打印直角杨辉三角(7层)
	int i, j;
	int a[7][7];
	for (i = 0; i < 7; i++)
	{
		for (j = 0; j <= i; j++)
		{
			if (j==0||j==i)
			{
				a[i][j] = 1;
			}
			else
			{
				a[i][j] = a[i - 1][j] + a[i - 1][j - 1];
			}
		}
	}
	for (i = 0; i < 7; i++)
	{
		for (j = 0; j <= i; j++)
		{
			printf("%d\t", a[i][j]);
		}
		printf("\n");
	}
}
```