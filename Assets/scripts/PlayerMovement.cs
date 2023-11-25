using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform gunTranform;
    private Vector3 mousePos;
    private Vector3 objectPos;
    private float angle;
    public GameObject bullet;
    /*private int seconds = 1;
    private int miliseconds = 500;
    TimeSpan clock = new TimeSpan(0, 0, 0, seconds, miliseconds)*/
    

    void Update()
    {
        UpdateGunPosition();
        shot();
    }

    void UpdateGunPosition()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -20;
        objectPos = Camera.main.WorldToScreenPoint(gunTranform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void shot()
    {
        Instantiate(bullet);
    }
}
