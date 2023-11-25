using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 mousePos;

    private Rigidbody2D rb;

    public int bulletSpeed;

    public PlayerMovement playerMovement;
    private Vector2 originalPosition;

    void Start()
    {
        GameObject bulletsMoveTo = GameObject.FindWithTag("BulletsMoveTo");
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(bulletsMoveTo.transform.position * bulletSpeed);
        Invoke(nameof(DisableRendererAndDestroy), 3f);
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
