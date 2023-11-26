using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody2D rb;
    private HUDControls scoreManager;


    private Vector2 targetPos;
    private Vector2 direction;
    public SpriteRenderer spriteRenderer;
    public Health health;

    public int score;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        scoreManager = GameObject.FindWithTag("HUD").GetComponent<HUDControls>();
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
            scoreManager.addScore(score);
            Destroy(gameObject);
        }
    }

    void GoToPlayer()
    {
        targetPos = player.position;
        direction = targetPos - rb.position;

        rb.MovePosition(rb.position + speed * Time.deltaTime * direction);
    }

    void FlipToPlayer()
    {
        if (!flip)
        {
            spriteRenderer.flipX = player.position.x > transform.position.x;
        }
        else
        {
            spriteRenderer.flipX = !(player.position.x > transform.position.x);
        }
    }
}
