using Cinemachine;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlNetWork : NetworkBehaviour
{
    private CinemachineVirtualCamera cinemachine;
    public override void OnStartLocalPlayer()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        cinemachine.Follow = FindAnyObjectByType<PlayerNetWrok>().transform;
    }
}
