1.SingleBaseManager 单例化基类
用途：声明调用单例化
使用方法：
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