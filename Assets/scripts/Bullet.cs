using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;
    public Vector2 objectPos;
    bool snap;
    int speedMoulus = 1;

    void Start() { }

    void Update()
    {
        if (!snap)
        {
            getDirection();
        }

        transform.Translate(direction * Time.deltaTime);
    }

    void getDirection()
    {
        mousePos = Input.mousePosition;
        snap = true;

        float x = mousePos.x - objectPos.x;
        float y = mousePos.y - objectPos.y;
        float modulus = Mathf.Sqrt(x * x + y * y);
        float diff = modulus / speedMoulus;

        direction.x = x / diff;
        direction.y = y / diff;
    }
}
