### PAT 乙级真题 1010.月饼
#### 题目描述
月饼是中国人在中秋佳节时吃的一种传统食品，不同地区有许多不同风味的月饼。现给定所有种类月饼的库存量、总售价、以及市场的最大需
求量，请你计算可以获得的最大收益是多少。

注意：销售时允许取出一部分库存。样例给出的情形是这样的：假如我们有3种月饼，其库存量分别为18、15、10万吨，总售价分别为75、
72、45亿元。如果市场的最大需求量只有20万吨，那么我们最大收益策略应该是卖出全部15万吨第2种月饼、以及5万吨第3种月饼，获得
 72 + 45/2 = 94.5（亿元）。
#### 输入格式
每个输入包含1个测试用例。每个测试用例先给出一个不超过1000的正整数N表示月饼的种类数、以及不超过500（以万吨为单位）的正整数
D表示市场最大需求量。随后一行给出N个正数表示每种月饼的库存量（以万吨为单位）；最后一行给出N个正数表示每种月饼的总售价（以亿
元为单位）。数字间以空格分隔。
#### 输出格式
对每组测试用例，在一行中输出最大收益，以亿元为单位并精确到小数点后2位。
#### 输入样例
```text
3 20
18 15 10
75 72 45
```
#### 输出样例
```text
94.50
```
#### 题目思路
```C++
#include<iostream>
#include<algorithm>
using namespace std;
const int N = 1000 + 10;

typedef struct yb
{
	double kucun;
	double zongjia;
	double danjia;
}yb;

bool compare(yb y1, yb y2)
{
	return y1.danjia > y2.danjia;
}

int main()
{
	yb y[N];
	int z;
	double d;
	scanf("%d%lf", &z, &d);
	for (int i = 0; i < z; i++)scanf("%lf", &y[i].kucun);
	for (int i = 0; i < z; i++)
	{
		scanf("%lf", &y[i].zongjia);
		y[i].danjia = y[i].zongjia / y[i].kucun;
	}
	sort(y, y + z, compare);
	int i = 0;
	double res = 0.0;
	while (d > 0.0)
	{
		if (d - y[i].kucun <= 0.0)
		{
			res += d * y[i].danjia;
			break;
		}
		else
		{
			res += y[i].zongjia;
			d -= y[i].kucun;
			i++;
		}
	}
	printf("%.2lf", res);
	return 0;
}
```