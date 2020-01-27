### PAT 乙级真题 1004.福尔摩斯的约会
#### 题目描述
大侦探福尔摩斯接到一张奇怪的字条：“我们约会吧！ 3485djDkxh4hhGE 2984akDfkkkkggEdsb s&hgsfdk d&Hyscvnm”。大侦探很快就明白了，字条上奇怪的乱码实际上就是约会的时间“星期四 14:04”，因为前面两字符串中第1对相同的大写英文字母（大小写有区分）是第4个字母'D'，代表星期四；第2对相同的字符是'E'，那是第5个英文字母，代表一天里的第14个钟头（于是一天的0点到23点由数字0到9、以及大写字母A到N表示）；后面两字符串第1对相同的英文字母's'出现在第4个位置（从0开始计数）上，代表第4分钟。现给定两对字符串，请帮助福尔摩斯解码得到约会的时间。
#### 输入格式
输入在4行中分别给出4个非空、不包含空格、且长度不超过60的字符串。
#### 输出格式
在一行中输出约会的时间，格式为“DAY HH:MM”，其中“DAY”是某星期的3字符缩写，即MON表示星期一，TUE表示星期二，WED表示星期三，THU表示星期
四，FRI表示星期五，SAT表示星期六，SUN表示星期日。题目输入保证每个测试存在唯一解。
#### 输入样例
```text
3485djDkxh4hhGE
2984akDfkkkkggEdsb
s&hgsfdk
d&Hyscvnm
```
#### 输出样例
```text
THU 14:04
```
#### 题目思路
注意题目指的是第一个串与第二个串的相同角标的字符相同，  
第三个串与第四个串的相同角标的字符相同。
```C++
#include<iostream>
#include<string>

using namespace std;
const int N = 70;
char s[4][N];
int main()
{
	for (int i = 0; i < 4; i++)
	{
		scanf("%s", s[i]);
	}
	int end = 0;
	char c = ';', c2 = '0';
	string str = "";

	for (int i = 0; i < 2 * N; i++)
	{
		if (*((*s) + i) >= 'A'&&*((*s) + i) <= 'Z'&& c == ';')
		{
			if (*((*s) + i) == *((*s) + i+N) )
			{
				c = *((*s) + i);
			}
		}
		else if (c != ';'&&*((*s) + i) == *((*s) + i + N)&&(*((*s) + i) >= 'A'&&*((*s) + i) <= 'Z'||*((*s) + i) >= '0'&&*((*s) + i) <= '9'))
		{
			c2 = *((*s) + i);
			break;
		}
	}
	switch (c - 'A' + 1)
	{
	case 1:printf("MON ");
		break;
	case 2:printf("TUE ");
		break;
	case 3:printf("WED ");
		break;
	case 4:printf("THU ");
		break;
	case 5:printf("FRI ");
		break;
	case 6:printf("SAT ");
		break;
	case 7:printf("SUN ");
		break;
	default:
		break;
	}
	if (c2 < 'A')
	{
		printf("0%c:", c2);
	}
	else
	{
		int ct = c2 - 'A' + 10;
		printf("%d:", ct);
	}
	str = "";
	for (int i = 2 * N; i < 4 * N; i++)
	{
		if (*((*s) + i) >= 'A'&&*((*s) + i) <= 'Z' || *((*s) + i) >= 'a'&&*((*s) + i) <= 'z')
		{
			if (*((*s) + i)== *((*s) + i+N))
			{
				c = *((*s) + i);
				end = i-2*N;
				break;
			}
			
		}
	}
	if (end > 9)
	{
		printf("%d", end);
	}
	else
	{
		printf("0%d", end);
	}
	return 0;
}

```