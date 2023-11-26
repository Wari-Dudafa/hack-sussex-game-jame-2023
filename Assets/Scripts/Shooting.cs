using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;

    void Start()
    {
        gun = GameObject.FindWithTag("Gun").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, gun.position, Quaternion.identity);
    }
}
