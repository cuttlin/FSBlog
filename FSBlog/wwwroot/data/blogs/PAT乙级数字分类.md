### PAT 乙级真题 1002.数字分类
#### 题目描述
给定一系列正整数，请按要求对数字进行分类，并输出以下5个数字：

A1 = 能被5整除的数字中所有偶数的和；  
A2 = 将被5除后余1的数字按给出顺序进行交错求和，即计算n1-n2+n3-n4...；  
A3 = 被5除后余2的数字的个数；  
A4 = 被5除后余3的数字的平均数，精确到小数点后1位；  
A5 = 被5除后余4的数字中最大数字。
#### 输入格式
每个输入包含1个测试用例。每个测试用例先给出一个不超过1000的正整数N，随后给出N个不超过1000的待分类的正整数。数字间以空格分隔。
#### 输出格式
对给定的N个正整数，按题目要求计算A1~A5并在一行中顺序输出。数字间以空格分隔，但行末不得有多余空格。
若其中某一类数字不存在，则在相应位置输出“N”。
#### 输入样例
~~~~
13 1 2 3 4 5 6 7 8 9 10 20 16 18
~~~~
#### 输出样例
~~~~
30 11 2 9.7 9
~~~~
#### 题目思路
```C++
#include <bits/stdc++.h>
using namespace std;

const int N = 1e5+10;
int q[N];

int main(){
    double a4 = 0.0;
    int a1=0,a2=0,a3=0,a5=0,count=0;
    int zed = 1;
    int n;
    scanf("%d",&n);
    for(int i=0;i<n;i++)scanf("%d",&q[i]);
    for(int i=0;i<n;i++){
        if(q[i]%5==0&&q[i]%2==0){
            a1+=q[i];
        }else if(q[i]%5==1){
            a2 += zed*q[i];
            zed = -zed;
        }else if(q[i]%5==2){
            a3++;
        }else if(q[i]%5==3){
            a4+=q[i];
            count++;
        }else if(q[i]%5==4){
            if(q[i]>a5){
                a5 = q[i];
            }
        }
    }
    if(a1!=0)printf("%d ",a1);
    else printf("N ");
    if(a2!=0)printf("%d ",a2);
    else printf("N ");
    if(a3!=0)printf("%d ",a3);
    else printf("N ");
    if(count!=0){
        double a = a4/count;
        printf("%.1f ",a);
    }else printf("N ");
    if(a5!=0)printf("%d",a5);
    else printf("N");
    
    return 0;
}

```