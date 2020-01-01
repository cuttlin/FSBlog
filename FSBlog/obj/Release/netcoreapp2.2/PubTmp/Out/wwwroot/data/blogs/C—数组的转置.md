### C语言—数组转置
```c
#include <stdio.h>

void main()
{
	// 数组的转置
	int a[4][4] = { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} };
	int b[4][4];
	int i, j,t;
	for (i = 0; i < 4; i++)
	{
		for (j = 0; j < 4; j++)
		{
			if (i!=j)
			{
				b[j][i] = a[i][j];
			}
			else
			{
				b[i][j] = a[i][j];
			}
		}
	}

	for (i = 0; i < 4; i++)
	{
		for (j = 0; j < 4; j++)
		{
			printf("%d\t", b[i][j]);
		}
		printf("\n");
	}
}

```