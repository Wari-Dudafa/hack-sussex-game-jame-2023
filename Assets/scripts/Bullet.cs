using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;

    bool snap;
    float speedMoulus = 3;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Gun");
        transform.position = player.transform.position;
    }

    void Update()
    {
        if (!snap)
        {
            GetDirection();
        }

        transform.Translate(direction * Time.deltaTime);
    }

    void GetDirection()
    {
        mousePos = Input.mousePosition;
        snap = true;

        float x = mousePos.x - 590;
        float y = mousePos.y - 280;
        float modulus = Mathf.Sqrt(x * x + y * y);
        float diff = modulus / speedMoulus;

        direction.x = x / diff;
        direction.y = y / diff;
    }
}
