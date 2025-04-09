using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
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

    public UnityEvent selectWeapon;

    public int status;

    private int num;

    private void Awake()
    {
        InitTaskText();
        instance = this;
        LoadTasks(1);

    }
    private void Update()
    {
        if (tasks.Count != 0) 
        {
            
            CheckTask();
        }
    }


    public void LoadTasks(int index)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("Assets/Tasks.xml");
        XmlNodeList nodes = xml.SelectNodes($"/TaskList/Task{index}/Task");
        foreach (XmlNode node in nodes)
        {
            Task task = new Task();            
            task.ID = int.Parse(node.SelectSingleNode("ID").InnerText);
            //Debug.Log("ID" + int.Parse(node.SelectSingleNode("ID").InnerText));
            task.Name = node.SelectSingleNode("Name").InnerText;
            task.Description = node.SelectSingleNode("Description").InnerText;
            task.Type = int.Parse(node.SelectSingleNode("Type").InnerText);
            task.Goal = int.Parse(node.SelectSingleNode("Goal").InnerText);
            task.Reward = node.SelectSingleNode("Reward").InnerText;
            tasks.Add(task);
            Debug.Log("获得任务");
        }
        LoadTaskText();
        InitTask();
    }
    public void LoadTaskText() 
    {
        taskName.text = "任务：" + tasks[0].Name.ToString();
        taskDescription.text = "要求：" + tasks[0].Description.ToString();
        taskRewards.text = "奖励：" + tasks[0].Reward.ToString();
        taskStatus.text = "进度：" + $"{status} / {tasks[0].Goal}";


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
                num = PlayerData.getInstance().KillNum;
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
                
                if (num +1 == PlayerData.getInstance().KillNum )
                {
                    num = PlayerData.getInstance().KillNum;
                    Debug.Log("任务进度+1");
                    status++;
                    LoadTaskText();
                }
                if (status==10) 
                {
                    Debug.Log("完成任务");
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
    public int Type { get; set; }
    public int Goal { get; set; }
    public string Reward { get; set; }
}
