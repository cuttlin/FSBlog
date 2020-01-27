### PAT 乙级真题 1008.锤子剪刀布
#### 题目描述
大家应该都会玩“锤子剪刀布”的游戏：  
现给出两人的交锋记录，请统计双方的胜、平、负次数，并且给出双方分别出什么手势的胜算最大。
#### 输入格式
输入第1行给出正整数N（<=105），即双方交锋的次数。随后N行，每行给出一次交锋的信息，即甲、乙双方同时给出的的手势。C代表“锤子”、J代表“剪刀”、B代
表“布”，第1个字母代表甲方，第2个代表乙方，中间有1个空格。
#### 输出格式
输出第1、2行分别给出甲、乙的胜、平、负次数，数字间以1个空格分隔。第3行给出两个字母，分别代表甲、乙获胜次数最多的手势，中间有1个空格。如果解不唯
一，则输出按字母序最小的解。
#### 输入样例
```text
10
C J
J B
C B
B B
B C
C C
C B
J B
B C
J J
```
#### 输出样例
```text
5 3 2
2 3 5
B B
```
#### 题目思路
注意输入字符时%c前面加空格，防止读入空格
```C++
#include<iostream>
using namespace std;

int main()
{
	int n, a1 = 0, b1 = 0, c1 = 0;
	int q[3]{ 0 }, p[3]{ 0 };
	char in1, in2;
	scanf("%d", &n);
	while (n--)
	{
		scanf(" %c %c", &in1, &in2);
		if (in1 == in2)b1++;
		else if (in1 == 'C'&&in2 == 'B')
		{
			p[2]++;
			c1++;
		}
		else if (in1 == 'C'&&in2 == 'J')
		{
			q[1]++;
			a1++;
		}
		else if (in1 == 'J'&&in2 == 'C')
		{
			p[1]++;
			c1++;
		}
		else if (in1 == 'J'&&in2 == 'B')
		{
			q[0]++;
			a1++;
		}
		else if (in1 == 'B'&&in2 == 'C')
		{
			q[2]++;
			a1++;
		}
		else if (in1 == 'B'&&in2 == 'J')
		{
			p[0]++;
			c1++;
		}
	}
	printf("%d %d %d\n", a1, b1, c1);
	printf("%d %d %d\n", c1, b1, a1);
	if (q[2] >= q[1] && q[2] >= q[0])printf("B ");
	else if (q[1] > q[2] && q[1] >= q[0])printf("C ");
	else if (q[0] > q[1] && q[0] > q[2])printf("J ");
	if (p[2] >= p[1] && p[2] >= p[0])printf("B");
	else if (p[1] > p[2] && p[1] >= p[0])printf("C");
	else if (p[0] > p[1] && p[0] > p[2])printf("J");
	return 0;
}

```