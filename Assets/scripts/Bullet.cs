using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;

    public PlayerMovement playerMovement;
    bool snap;
    float speedMoulus = 3;
    private Vector2 originalPosition;
    //int dmg = 10;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        transform.position = player.transform.position;
        originalPosition = transform.position;
        Invoke("DisableRendererAndDestroy", 3f);
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

        float x = mousePos.x - 600 - originalPosition.x;
        float y = mousePos.y - 280 - originalPosition.y;
        float modulus = Mathf.Sqrt(x * x + y * y);
        float diff = modulus / speedMoulus;

        direction.x = x / diff;
        direction.y = y / diff;
    }

    void DisableRendererAndDestroy()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        Destroy(gameObject, 0.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }
}