using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;

    public PlayerMovement playerMovement;
    bool snap;
    int speedMoulus;
    int xPos;
    int yPos;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        playerMovement = player.GetComponent<PlayerMovement>();

        transform.rotation = Quaternion.Euler(0, 0, playerMovement.GetAngle());
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

        float x = mousePos.x - 580 - xPos;
        float y = mousePos.y - 270 - yPos;
        float modulus = Mathf.Sqrt(x * x + y * y);
        float diff = modulus / speedMoulus;

        direction.x = x / diff;
        direction.y = y / diff;

        direction.x = x / diff;
        direction.y = y / diff;
    }
}
