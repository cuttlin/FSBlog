### PAT 乙级真题 1003.数素数
#### 题目描述
令Pi表示第i个素数。现任给两个正整数M <= N <= 10000，请输出PM到PN的所有素数。
#### 输入格式
输入在一行中给出M和N，其间以空格分隔。
#### 输出格式
输出从PM到PN的所有素数，每10个数字占1行，其间以空格分隔，但行末不得有多余空格。
#### 输入样例
```text
5 27
```
#### 输出样例
```text
11 13 17 19 23 29 31 37 41 43
47 53 59 61 67 71 73 79 83 89
97 101 103
```
#### 题目思路
注意每一行的后面都不能有空格
```C++
#include<bits/stdc++.h>
using namespace std;
const int N = 1e4 + 10;
int q[N], m, n, i = 0;

void pri_num(int n)
{
	int k = 2;
	while (i < n)
	{
		int j = 2;
		for (; j <= sqrt(k) + 1; j++)
		{
			if (k%j == 0)break;

		}
		int t = sqrt(k) + 1;
		if (j >= t)
		{
			q[i++] = k;
		}
		k++;
	}
}

int main()
{
	scanf("%d%d",&m,&n);
	pri_num(n);
	for (int j = m - 1; j < i; j++)
	{
		if ((j - (m - 1)+ 1) % 10 == 0)
		{
			printf("%d\n", q[j]);
		}
		else if(j == i - 1)
        {
            printf("%d", q[j]);
        }    
        else
		{
			printf("%d ", q[j]);
		}
	}
	return 0;
}

```