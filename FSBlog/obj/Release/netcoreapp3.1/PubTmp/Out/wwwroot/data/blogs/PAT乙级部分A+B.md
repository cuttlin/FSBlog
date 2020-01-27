### PAT 乙级真题 1006.1016.部分A+B
#### 题目描述
正整数A的“DA（为1位整数）部分”定义为由A中所有DA组成的新整数PA。例如：给定A = 3862767，DA = 6，则A的“6部分”PA是66，因为A中有2个6。
 
 现给定A、DA、B、DB，请编写程序计算PA + PB。
#### 输入格式
输入在一行中依次给出A、DA、B、DB，中间以空格分隔，其中0 < A, B < 1010。
#### 输出格式
在一行中输出PA + PB的值。
#### 输入样例
```text
3862767 6 13530293 3
```
#### 输出样例
```text
399
```
#### 题目思路

```C++
#include<bits/stdc++.h>
#define ll long long int
using namespace std;

int main()
{
    ll a,b;
    int c,d,e=0,f=0;
    scanf("%ld%d%ld%d",&a,&c,&b,&d);
    do
    {
        if(a%10==c)
            e=e==0?c:e*10+c;
    }while(a/=10);
    do
    {
        if(b%10==d)
            f=f==0?d:f*10+d;
    }while(b/=10);
    printf("%d",e+f);
    return 0;
}

```