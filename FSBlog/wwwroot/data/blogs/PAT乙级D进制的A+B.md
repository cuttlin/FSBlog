### PAT 乙级真题 1012.D进制的A+B
#### 题目描述
输入两个非负10进制整数A和B(<=230-1)，输出A+B的D (1 < D <= 10)进制数。
#### 输入格式
输入在一行中依次给出3个整数A、B和D。
#### 输出格式
输出A+B的D进制数。
#### 输入样例
```text
123 456 8
```
#### 输出样例
```text
1103
```
#### 题目思路
```C++
#include<bits/stdc++.h>
#define ll long long int
using namespace std;

int main()
{
    ll a,b;
    int d;
    scanf("%lld%lld%d",&a,&b,&d);
    a += b;
    if(a==0)
    {
        printf("0");
    }
    else
    {
        stack<int> s;
        while(a/d)
        {
            s.push(a%d);
            a/=d;
        }
        s.push(a);
        while(!s.empty())
        {
            printf("%d",s.top());
            s.pop();
        }
    }
    return 0;
}
```