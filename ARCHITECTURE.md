# 开发文档
本篇文档用于介绍开发过程中，软件的基本架构以及各个函数使用的方法。

## 架构
基于组件自底向上的架构

### 类图

## 函数
### 功能类
#### 移动
#### 攻击

### 非功能类
#### SingleBaseManager 单例化基类
用途：声明调用单例化
实现方法：
```c#
public class Test : SingleBaseManager<Test>
{
    public void TestSingleBase() 
}

```
调用单例化：
```c#
public class Test1
{
     Test.getInstance().TestSingleBase();
}
```
