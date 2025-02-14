using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpController : MonoBehaviour
{
    public int currentExperience;
    public List<int> expLevels;
    public int currentLevel = 1, levelCount;
    public UnityEvent levelUpEvent;

    private UIController UIController;

    private void Start()
    {
        PlayerData.getInstance().Exp = 0;
        PlayerData.getInstance().Level = currentLevel;
        UIController = GetComponent<UIController>();
        while (expLevels.Count < levelCount) 
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count-1]*1.1f));
        }
    }
    private void Update()
    {
        currentExperience = PlayerData.getInstance().Exp;
        if (currentExperience >= expLevels[currentLevel]) 
        {

            LevelUp();
            levelUpEvent?.Invoke();
        }
        UIController.UpdateExp(currentExperience, expLevels[currentLevel],currentLevel);
    }
    private void LevelUp() 
    {
        currentExperience -=expLevels[currentLevel];
        PlayerData.getInstance().Exp =currentExperience;
        currentLevel++;
        if (currentLevel > expLevels.Count) 
        {
            currentLevel =expLevels.Count-1;
        }
    }
}
