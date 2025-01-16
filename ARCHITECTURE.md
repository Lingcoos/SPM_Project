# 开发文档
## 说明
本篇文档用于介绍开发过程中，项目的基本架构以及各个函数使用的方法。
> 所有的文档都可以根据实际情况进行修改和完善



## 架构
### 项目架构
基于组件的自底向上架构

玩家（与I/O系统直接交互） - 屏幕（显示画面） - 系统（处理数据）

### 文件架构
#### Assets
用于储存所有项目相关的素材和资源
+ Animation: 动画资源
+ Animator: 动画资源
+ Materials: 素材源文件
  + characters: 角色相关
  + items: 物品、道具相关
  + monsters: 怪物、敌人相关
  + tilemaps: 地图
+ Prefabs: 预制体
+ Scenes: 场景
+ Scrips: 脚本
#### images
存放项目文档中的相关图片
#### ARCHITECTURE.md
开发手册，即本篇文档
#### README.md
项目说明文档
#### LICENCE.txt
软件许可协议。本项暂未开源。若开源，请遵守 `MIT协议`
#### 其他
未说明的文件一般情况下**不需要**手动修改。


<!-- 以下部分可自行添加您打算或已经实现的功能 -->
## 函数
### 功能类
#### 移动
#### 攻击
#### PlayerData 玩家数据储存
用途：储存玩家数据
调用方法：
```c#
int currentgold = PlayerData.getInstance().Gold;   // 获取 `gold 并且赋值给 `currentgold
PlayerData.getInstance().Gold = 0;   // 设置 `gold 为 0
PlayerData.getInstance().Gold += 100;   // 增加 100 `gold
```
#### 音效

### 非功能类
#### SingleBaseManager 单例化基类
用途：声明调用单例化
> 经常需要调用的变量/函数建议使用单例化
定义单例化：
```c#
public class CLASS : SingleBaseManager<CLASS>       // 定义需要单例化的类 `CLASS
{
    int var;                        // 定义单例化变量
    public void FUNCTION(){}        // 定义单例化方法 
}
```

调用单例化：
```c#
public class ANY_CLASS      // 在任意类中调用单例化的数据
{
    CLASS.getInstance().var;            // 调用变量
    CLASS.getInstance().FUNCTION();     // 调用函数
}
```
