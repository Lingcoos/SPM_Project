using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNetWorkHub : MonoBehaviour
{
    private NetworkManager networkManager;
    private GameObject startHost;
    private GameObject startClient;
    private GameObject stopHost;
    void Awake()
    {
        networkManager = GetComponent<NetworkManager>();

    }


    private void Update()
    {
        try 
        {
            startHost = GameObject.Find("StartHost");
            startClient = GameObject.Find("StartClient");
            stopHost = GameObject.Find("StopHost");
            startHost.GetComponent<Button>().onClick.AddListener(onStartHost);
            startClient.GetComponent<Button>().onClick.AddListener(onStartClient);
            stopHost.GetComponent<Button>().onClick.AddListener(onStopHost);
            if (!NetworkClient.isConnected && !NetworkServer.active)
            {
                startHost.SetActive(true);
                startClient.SetActive(true);
                stopHost.SetActive(false);
            }
            else
            {
                startHost.SetActive(false);
                startClient.SetActive(false);
                stopHost.SetActive(true);
            }
        }
        catch { }

        


    }


    private void onStartHost()
    {
        networkManager.StartHost();
    }
    private void onStartClient() 
    {
        networkManager.StartClient();
    }
    private void onStopHost() 
    {
        networkManager.StartHost();
    }
}
