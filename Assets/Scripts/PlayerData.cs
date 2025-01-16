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

    // The attributes of player
    private int gold;   // the number of gold
    private int crystal;    // the number of crystal(global)
    private int level;  // the level of player
    private int exp;    // the number of experience
    private int killNum;    // the number of killed monsters

    private float maxHealth;    // the maximum health of player
    private float currentHealth;    // the current health of player
    private float currentAttack;    // the current attack of player
    private float currentDefense;   // the current defense of player

    // Constructor
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

    public float MaxHealth
    {
        get { return maxHealth; }
        set 
        {
            if (value < 0)
                maxHealth = 0;
            else if(value > MAX_HEALTH)
                maxHealth = MAX_HEALTH;
            else
                maxHealth = value; 
        }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
                currentHealth = 0;
            else if (value > maxHealth)
                currentHealth = maxHealth;
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
}
