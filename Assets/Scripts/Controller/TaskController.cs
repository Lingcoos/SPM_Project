using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public static TaskController instance;
    public List<Task> tasks;
    public Task curTask;
    public Text taskName;
    public Text taskDescription;
    public Text taskStatus;
    public Text taskRewards;
    public bool isHaveTask;
    [HideInInspector]public int taskIndex = 1;
    public UnityEvent selectWeapon;
    public int status;
    public TextAsset xmlTaskFile;
    private int num;
    private void Awake()
    {
        InitTaskText();
        instance = this;
        PlayerPrefs.SetInt("KillNum", 0);


    }
    private void Start()
    {
        LoadTasks(taskIndex);
    }
    private void Update()
    {
        if (tasks.Count != 0) 
        {
            ChangeTasks(taskIndex);
            
            CheckTask();
        }
    }


    public void LoadTasks(int index)
    {
        if (index == 0) 
        {
            return;
        }
        XmlDocument xml = new XmlDocument();
        XmlNodeList nodes;
        xml.LoadXml(xmlTaskFile.text);
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            nodes = xml.SelectNodes($"/TaskList/Task{index}/Task_English");
        }
        else 
        {
            nodes = xml.SelectNodes($"/TaskList/Task{index}/Task_Chinese");            
        }
            
        foreach (XmlNode node in nodes)
        {
            tasks.Clear();
            Task task = new Task();            
            task.ID = int.Parse(node.SelectSingleNode("ID").InnerText);
            //Debug.Log("ID" + int.Parse(node.SelectSingleNode("ID").InnerText));
            task.Name = node.SelectSingleNode("Name").InnerText;
            task.Description = node.SelectSingleNode("Description").InnerText;
            task.Goal = int.Parse(node.SelectSingleNode("Goal").InnerText);
            task.Reward = node.SelectSingleNode("Reward").InnerText;
            tasks.Add(task);
            //Debug.Log("获得任务");
        }
        LoadTaskText();
        InitTask();
        isHaveTask = true;
        
    }
    public void ChangeTasks(int index)
    {
        if (index == 0)
        {
            return;
        }
        XmlDocument xml = new XmlDocument();
        XmlNodeList nodes;
        xml.LoadXml(xmlTaskFile.text);
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            nodes = xml.SelectNodes($"/TaskList/Task{index}/Task_English");
        }
        else
        {
            nodes = xml.SelectNodes($"/TaskList/Task{index}/Task_Chinese");
        }

        foreach (XmlNode node in nodes)
        {
            tasks.Clear();
            Task task = new Task();
            task.ID = int.Parse(node.SelectSingleNode("ID").InnerText);
            //Debug.Log("ID" + int.Parse(node.SelectSingleNode("ID").InnerText));
            task.Name = node.SelectSingleNode("Name").InnerText;
            task.Description = node.SelectSingleNode("Description").InnerText;
            task.Goal = int.Parse(node.SelectSingleNode("Goal").InnerText);
            task.Reward = node.SelectSingleNode("Reward").InnerText;
            tasks.Add(task);
            //Debug.Log("获得任务");
        }
        LoadTaskText();

    }
    public void LoadTaskText()
    {
        
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            taskName.text = "Task：" + tasks[0].Name.ToString();
            taskDescription.text = "Requirment：" + tasks[0].Description.ToString();
            taskRewards.text = "Reward：" + tasks[0].Reward.ToString();
            taskStatus.text = "Progress：" + $"{status} / {tasks[0].Goal}";
        }
        else 
        {
            taskName.text = "任务：" + tasks[0].Name.ToString();
            taskDescription.text = "要求：" + tasks[0].Description.ToString();
            taskRewards.text = "奖励：" + tasks[0].Reward.ToString();
            taskStatus.text = "进度：" + $"{status} / {tasks[0].Goal}";
        }



    }
    public void InitTaskText()
    {
        taskName.text = "";
        taskDescription.text = "";
        taskRewards.text = "";
        taskStatus.text = "";
        status = 0;
        num = 0;

    }
    public void FinishTask() 
    {
        tasks.Clear();
        isHaveTask = false;
    }
    public void InitTask() 
    {
        if (tasks.Count == 0)
        {
            return;
        }
        switch (tasks[0].ID)
        {

            case 1:
                num = PlayerPrefs.GetInt("KillNum");
                break;
            case 2:
                break;
        }
    }
    public void CheckTask()
    {
        if (tasks.Count == 0) 
        {
            return;
        }
        switch (tasks[0].ID) 
        {
            
            case 1:
 
                if (num + 1 == PlayerPrefs.GetInt("KillNum"))
                {
                    num = PlayerPrefs.GetInt("KillNum");
                    status++;
                    LoadTaskText();
                }
                if (status==10) 
                {
                    //Debug.Log("完成任务");
                    selectWeapon.Invoke();
                    InitTaskText();
                    FinishTask();
                }
                break;
            case 2:
                break;
        }
    }
}










[System.Serializable]
public class Task
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Goal { get; set; }
    public string Reward { get; set; }
}
