using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;
    bool snap;
<<<<<<< HEAD:Assets/Scripts/Bullet.cs
    int speedMoulus=4;
    int xPos = 0;
    int yPos = 0;

    public void Start()
    {
    }
=======
    int speedMoulus = 1;

    void Start() { }
>>>>>>> b805e848b690418c66a8494ef3dd1889435d9aea:Assets/scripts/Bullet.cs

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
<<<<<<< HEAD:Assets/Scripts/Bullet.cs
        
        float x = mousePos.x - 580 - xPos;
        float y = mousePos.y - 270 - yPos;
        float modulus = Mathf.Sqrt(x*x + y*y);
        float diff = modulus / speedMoulus;

        Debug.Log("so object is moving on " + x + " and " + y);

        
        
        direction.x = x/diff;
        direction.y = y/diff;
    }
=======

        float x = mousePos.x - objectPos.x;
        float y = mousePos.y - objectPos.y;
        float modulus = Mathf.Sqrt(x * x + y * y);
        float diff = modulus / speedMoulus;
>>>>>>> b805e848b690418c66a8494ef3dd1889435d9aea:Assets/scripts/Bullet.cs

        direction.x = x / diff;
        direction.y = y / diff;
    }
}
