using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraPlayerSelector : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;

    void Start()
    {
        cinemachineCamera.Follow = GameObject.FindWithTag("Player").transform;
    }
}
