using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;
    bool snap;
    int speedMoulus=4;
    int xPos = 0;
    int yPos = 0;

    public void Start()
    {
    }

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
        
        float x = mousePos.x - 580 - xPos;
        float y = mousePos.y - 270 - yPos;
        float modulus = Mathf.Sqrt(x*x + y*y);
        float diff = modulus / speedMoulus;

        Debug.Log("so object is moving on " + x + " and " + y);

        
        
        direction.x = x/diff;
        direction.y = y/diff;
    }

}