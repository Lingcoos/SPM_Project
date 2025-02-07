using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is used to store the data of player. It is a singleton class.
/// If you want to add new attributes, you can add them here. 
/// Don't forget to add a constructor and its limits and set the maximum value, if you need:)
/// </summary>
public class PlayerData : SingleBaseManager<PlayerData>
{
    // The maximum value of each attribute
    private const int MAX_GOLD = 999999;
    private const int MAX_CRYSTAL = 999999;
    private const int MAX_LEVEL = 999;
    private const int MAX_EXP = 999999;
    private const int MAX_KILLNUM = 999999;

    private const float MAX_HEALTH = 9999;
    private const float MAX_ATTACK = 999;
    private const float MAX_DEFENSE = 999;
    private const float MAX_SPEED = 99;

    // The attributes of player
    [Header("Player Info")]
    private int gold;   // the number of gold
    private int crystal;    // the number of crystal(global)
    private int level;  // the level of player
    private int exp;    // the number of experience
    private int killNum;    // the number of killed monsters
    private int x_pos;  // the x position of player
    private int y_pos;  // the y position of player

    [Header("Player Base Attributes")]
    private float baseMaxHealth = 100;    // the basic curHealth of player
    private float baseAttack = 10;    // the basic attack of player
    private float baseDefense = 5;    // the basic defense of player
    private float baseSpeed = 5;    // the speed of player

    [Header("Player Buff Attributes")]
    private float healthBuff = 0;   // the curHealth buff of player
    private float attackBuff = 0;   // the attack buff of player
    private float defenseBuff = 0;  // the defense buff of player
    private float speedBuff = 0;    // the speed buff of player

    [Header("Player Current Attributes")]
    private float currentMaxHealth;    // currentMaxHealth = baseMaxHealth + level * 10 + healthBuff;  // the maximum curHealth of player
    private float currentHealth;    // the current curHealth of player
    private float currentAttack;    // currentAttack = baseAttack + level * 2 + attackBuff;  // the current attack of player
    private float currentDefense;   // currentDefense = baseDefense + level * 1 + defenseBuff;  // the current defense of player
    private float currentSpeed;   // currentSpeed = speed + speedBuff;  // the current speed of player


    // Constructor:
    // Goid, Crystal, Level, Exp, KillNum,
    // HealthBuff, AttackBuff, DefenseBuff, SpeedBuff,
    // MaxHealth, CurrentHealth, CurrentAttack, CurrentDefense, CurrentSpeed,
    // X_pos, Y_pos
    public int Gold
    {
        get { return gold; }
        set 
        {
            if (value < 0)
                gold = 0;
            else if (value > MAX_GOLD)
                gold = MAX_GOLD;
            else
                gold = value;
        }
    }

    public int Crystal
    {
        get { return crystal; }
        set 
        {
            if (value < 0)
                crystal = 0;
            else if (value > MAX_CRYSTAL)
                crystal = MAX_CRYSTAL;
            else
                crystal = value;
        }
    }

    public int Exp
    {
        get { return exp; }
        set
        {
            if (value < 0)
                exp = 0;
            else if (value > MAX_EXP)
                exp = MAX_EXP;
            else
                exp = value;
        }
    }

    public int KillNum
    {
        get { return killNum; }
        set
        {
            if (value < 0)
                killNum = 0;
            else if (value > MAX_KILLNUM)
                killNum = MAX_KILLNUM;
            else
                killNum = value;
        }
    }
    
    public float HealthBuff
    {
        get { return healthBuff; }
        set { healthBuff = value; }
    }

    public float AttackBuff
    {
        get { return attackBuff; }
        set { attackBuff = value; }
    }

    public float DefenseBuff
    {
        get { return defenseBuff; }
        set { defenseBuff = value; }
    }

    public float SpeedBuff
    {
        get { return speedBuff; }
        set { speedBuff = value; }
    }


    public float CurrentMaxHealth
    {
        get { return currentMaxHealth; }
        set 
        {
            if (value < 0)
                currentMaxHealth = 0;
            else if(value > MAX_HEALTH)
                currentMaxHealth = MAX_HEALTH;
            else
                currentMaxHealth = value; 
        }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
                currentHealth = 0;
            else if (value > currentMaxHealth)
                currentHealth = currentMaxHealth;
            else
                currentHealth = value;
        }
    }

    public float CurrentAttack
    {
        get { return currentAttack; }
        set
        {
            if (value < 0)
                currentAttack = 0;
            else if (value > MAX_ATTACK)
                currentAttack = MAX_ATTACK;
            else
                currentAttack = value;
        }
    }

    public float CurrentDefense
    {
        get { return currentDefense; }
        set
        {
            if (value < 0)
                currentDefense = 0;
            else if (value > MAX_DEFENSE)
                currentDefense = MAX_DEFENSE;
            else
                currentDefense = value;
        }
    }

    public float CurrentSpeed
    {
        get { return currentSpeed; }
        set
        {
            if (value < 0)
                currentSpeed = 0;
            else if (value > MAX_SPEED)
                currentSpeed = MAX_SPEED;
            else
                currentSpeed = value;
        }
    }

    public int X_pos
    {
        get { return x_pos; }
        set { x_pos = value; }
    }

    public int Y_pos
    {
        get { return y_pos; }
        set { y_pos = value; }
    }




    public void UpdateAttribute()
    {
        currentMaxHealth = baseMaxHealth + level * 10 + healthBuff;  // the maximum curHealth of player
        currentHealth = baseMaxHealth + level * 10 + healthBuff;  // the current curHealth of player
        currentAttack = baseAttack + level * 2 + attackBuff;  // the current attack of player
        currentDefense = baseDefense + level * 1 + defenseBuff;  // the current defense of player
        currentSpeed = baseSpeed + speedBuff;  // the current speed of player
    }

    public void Upgrade()
    {
        while(exp >= level * 100)
        {
            exp -= level * 100;
            level++;
        }
        UpdateAttribute();
    }

    public void UpdateAllData()
    {
        Upgrade();
        UpdateAttribute();
    }

    public void InitData()  // init data for a new game
    {
        PlayerPrefs.SetInt("Gold", 0);
        //PlayerPrefs.SetInt("Crystal", 0);     // global crystal
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Exp", 0);
        PlayerPrefs.SetInt("KillNum", 0);
        PlayerPrefs.SetFloat("MaxHealth", baseMaxHealth);
        PlayerPrefs.SetFloat("CurrentHealth", baseMaxHealth);
        PlayerPrefs.SetFloat("CurrentAttack", baseAttack);
        PlayerPrefs.SetFloat("CurrentDefense", baseDefense);
        PlayerPrefs.SetFloat("CurrentSpeed", baseSpeed);
    }
    public void SaveData()
    {
        UpdateAllData();
        PlayerPrefs.SetInt("Gold", Gold);
        PlayerPrefs.SetInt("Crystal", Crystal);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("KillNum", KillNum);
        PlayerPrefs.SetFloat("MaxHealth", currentMaxHealth);
        PlayerPrefs.SetFloat("CurrentHealth", CurrentHealth);
        PlayerPrefs.SetFloat("CurrentAttack", CurrentAttack);
        PlayerPrefs.SetFloat("CurrentDefense", CurrentDefense);
        PlayerPrefs.SetFloat("CurrentSpeed", CurrentSpeed);
    }
    public void LoadData()
    {
        Gold = PlayerPrefs.GetInt("Gold", gold);
        Crystal = PlayerPrefs.GetInt("Crystal", crystal);
        level = PlayerPrefs.GetInt("Level", level);
        Exp = PlayerPrefs.GetInt("Exp", exp);
        KillNum = PlayerPrefs.GetInt("KillNum", killNum);
        currentMaxHealth = PlayerPrefs.GetFloat("MaxHealth", currentMaxHealth);
        CurrentHealth = PlayerPrefs.GetFloat("CurrentHealth", currentHealth);
        CurrentAttack = PlayerPrefs.GetFloat("CurrentAttack", currentAttack);
        CurrentDefense = PlayerPrefs.GetFloat("CurrentDefense", currentDefense);
        CurrentSpeed = PlayerPrefs.GetFloat("CurrentSpeed", currentSpeed);
    }
}
