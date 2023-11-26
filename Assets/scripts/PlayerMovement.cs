using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Transform gunTranform;
    public Transform playerTransform;
    public Transform playerSpriteTransform;
    private Vector3 mousePos;
    private Vector3 objectPos;
    public PlayerInput playerInput;
    private Rigidbody2D rb;
    private float angle;
    public Health health;

    public float speed;

    public bool isFacingRight;

    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (health.IsAlive())
        {
            UpdateGunPosition();
        }
    }

    void FixedUpdate()
    {
        if (health.IsAlive())
        {
            MovePlayer();
        }
    }

    void UpdateGunPosition()
    {
        mousePos.z = -20;
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(gunTranform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        gunTranform.rotation = Quaternion.Euler(0, 0, angle);

        UpdateSpriteDirection();
    }

    void MovePlayer()
    {
        Vector2 direction = playerInput.PlayerDirection();
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    public float GetAngle()
    {
        return angle;
    }

    void FlipSprite()
    {
        Vector3 newScale = playerSpriteTransform.localScale;
        newScale.x *= -1;
        playerSpriteTransform.localScale = newScale;
    }

    void UpdateSpriteDirection()
    {
        if (mousePos.x < 0 && isFacingRight)
        {
            FlipSprite();
            isFacingRight = false;
        }
        else if (mousePos.x >= 0 && !isFacingRight)
        {
            FlipSprite();
            isFacingRight = true;
        }
    }

    public Vector2 getPos()
    {
        return transform.position;
    }
}
