using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public int bulletSpeed;

    void Start()
    {
        GameObject bulletsMoveTo = GameObject.FindWithTag("BulletsMoveTo");
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce((bulletsMoveTo.transform.position - transform.position) * bulletSpeed);

        Debug.Log(bulletsMoveTo.transform.position);
        Invoke(nameof(DisableRendererAndDestroy), 10f);
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

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Foliage"))
        {
            // Do nothing
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
