using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    public Transform player;
    private Rigidbody2D rb;

    private Vector2 targetPos;
    private Vector2 direction;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GoToPlayer();
    }

    void GoToPlayer()
    {
        targetPos = player.position;
        direction = targetPos - rb.position;

        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }
}
