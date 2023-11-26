using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody2D rb;

    private Vector2 targetPos;
    private Vector2 direction;
    public SpriteRenderer spriteRenderer;
    public Health health;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (health.IsAlive())
        {
            GoToPlayer();
            FlipToPlayer();
            health.UpdateHealthBar();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void GoToPlayer()
    {
        targetPos = player.position;
        direction = targetPos - rb.position;

        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    void FlipToPlayer()
    {
        spriteRenderer.flipX = player.position.x > transform.position.x;
    }
}
