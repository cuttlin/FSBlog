### C++自定义sort函数
#### 前言

> 在C++中可能会出现给结构体等进行排序的情况，C++中的sort函数支持自定义比较器的功能。

#### 函数参数

```C++
// 比较器函数
bool compare(参与比较的第一个元素, 参与比较的第二个元素)
{
    return 参与比较的第一个元素 > 参与比较的第二个元素; // 降序
    // return 参与比较的第一个元素 < 参与比较的第二个元素; 升序
}

// sort函数
void sort(排序的首地址, 排序的末地址 + 1, 比较器函数名称);
```

#### 使用示例
比较Student结构体，按a降序排序，a相同时，按b升序排序  
```C++
#include<iostream>
using namespace std;

// Student结构体
typedef struct Student
{
    int a;
    int b
}Student;

// 比较器函数
bool compare(Student s1, Student s2)
{
    if(s1.a != s2.a)
        return s1.a > s2.a;
    else
        return s1.b < s2.b;
}

int main()
{
    Student s[10];
    for(int i=0;i<10;i++)
        scanf("%d%d",&s[i].a,&s[i].b);
    
    sort(s,s+10,compare); // 使用自定义sort函数

    for(int i=0;i<10;i++)
        printf("%d %d\n",s[i].a,s[i].b);

    return 0;
}
```