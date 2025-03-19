# Development Document
## Description

This document is used to introduce the basic architecture of the project and the methods of using each function during the development process.

> All documents can be modified and improved according to actual conditions

## Architecture
### Project Architecture
+ Component-based
+ bottom-up architecture

Player (directly interacts with the I/O system) - Screen (displays the screen) - System (processes data)

### File Tree
#### Assets
Used to store all project-related materials and resources
+ Animation: animation resources
+ Animator: animation resources
+ Materials: material source files
+ characters: character-related
+ items: items and props-related
+ monsters: monsters and enemies-related
+ tilemaps: maps
+ Prefabs: prefabs
+ Scenes: scenes
+ Scrips: scripts
#### images
Store related pictures in project documents
#### ARCHITECTURE.md
Development Manual, which is this document
#### README.md
Project description document
#### LICENCE.txt
Software License Agreement. This project is not open source yet. If open source, please comply with the `MIT Agreement`
#### Others
Undocumented files generally **do not need** to be modified manually.



<!-- You can add the functions you intend to or have already implemented in the following part -->
## Functions
### Main Features
#### About Player Data
`./Assets/Scripts/.PlayerData.cs`
Stores player data. Generally, this function is used to call or change variables.
##### Define Constant
Defines the maximum value for the character. Normally, **do not** change constants.
+ MAX_GOLD
+ MAX_CRYSTAL
+ MAX_LEVEL
+ MAX_EXP
+ MAX_KILLNUM
+ MAX_HEALTH
+ MAX_ATTACK
+ MAX_DEFFENSE
+ MAX_SPEED

##### Stored Character Data
The function operates on the following variables:
+ gold
+ crystal
+ level
+ exp
+ killNum
+ x_pos
+ y_pos
+ baseMaxHealth
+ baseAttack
+ baseDefense
+ baseSpeed
+ healthBuff
+ attackBuff
+ defenseBuff
+ speedBuff
+ currentMaxHealth
+ currentHealth
+ currentAttack
+ currentDefense
+ currentSpeed

##### Constructor
Use get/set methods to define the constructor.
In general, **do not modify** the logic processing method of the constructor.

##### Calling method
Use `PlayerData.getInstance().[Variable];` to call.
```c#
// Data processing: Gold, Crystal, Exp, KillNum, HealthBuff, AttackBuff, DefenseBuff, SpeedBuff, CurrentMaxHealth, CurrentHealth, CurrentAttack, CurrentDefense, CurrentSoeed, X_pos, Y_pos
int currentgold = PlayerData.getInstance().Gold;   // Get `gold and assign it to `currentgold
PlayerData.getInstance().Gold = 0;   // Set `gold as 0
PlayerData.getInstance().Gold += 100;   // Add 100 `gold
```

Use `PlayerData.getInstance().[Function()];` to call.
+ UpgradeAttribute: Update character attribute values
+ Upgrade: Perform upgrade processing
+ UpdateAllData: Update all character data

Generally, you only need to call the `PlayerData.getInstance().UpdateAllData();` method.
+ InitData: Initialize character data
+ SaveData: Save data
+ LoadData: Read data

```c#
//Data operations: UpgradeAttribute, Upgrade, UpdateAllData, InitData, SaveData, LoadData
PlayerData.getInstance().UpdateAllData();
```

#### About New Weapons
If you want to design new weapon, please locate the two file first. 
`./Assets/Scripts/Weapon`: create the object of weapon (e.g., NewWep.cs)
`./Assets/Scripts/Weapon/Controller`: create the controller of the weapon (e.g., NewWepController.cs)

You can refer other code to design.

#### About New Monsters
<!-- Add Here -->

#### About New Characters
<!-- Add Here -->

#### BGM/SE
<!-- Add Here -->

#### About Level Up Bonus
<!-- Add Here -->

#### About Game Flow Control
<!-- Add Here -->

#### About Multi-Player
<!-- Add Here -->

#### About Localization
<!-- Add Here -->

#### About GameSetting
<!-- Add Here -->

### Helper Function
#### SingleBaseManager
Purpose: Declare and call singleton
> It is recommended to use singleton for variables/functions that need to be called frequently
Define singleton: 
```c#
public class CLASS : SingleBaseManager<CLASS>       // 定义需要单例化的类 `CLASS
{
    int var;                        // 定义单例化变量
    public void FUNCTION(){}        // 定义单例化方法 
}
```


Calling singleton:
```c#
public class ANY_CLASS      // 在任意类中调用单例化的数据
{
    CLASS.getInstance().var;            // 调用变量
    CLASS.getInstance().FUNCTION();     // 调用函数
}
```
