using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public string mapName;
    private Outline outline;
    public Outline[] otherMap;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void ChangeOutline() 
    {
        outline.enabled = true;
        StartGameController.instance.startGameTarget = mapName;
        foreach(var map in otherMap) 
        {
            map.enabled = false;
        }
        
    }

}
