using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        Shot();
    }

    void Shot()
    {
        Instantiate(bullet);
    }
}
