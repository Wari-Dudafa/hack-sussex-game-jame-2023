using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    private int timer = 0;
    private int shootspeed = 400;

    void Update()
    {
        if (timer % shootspeed == 0)
        {
            shot();
        }
        timer++;
    }

    void shot()
    {
        Instantiate(bullet);
    }
}
