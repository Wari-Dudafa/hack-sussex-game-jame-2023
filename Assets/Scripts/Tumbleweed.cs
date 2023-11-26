using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbleweed : MonoBehaviour
{
    public float anglesPerSecond;

    void Start()
    {
        anglesPerSecond = Random.Range(-135, 135);
    }

    void Update()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z += Time.deltaTime * anglesPerSecond;
        transform.localEulerAngles = rotation;
    }
}
