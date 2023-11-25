using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    private float angle;
    public float speed;
    public bool isFacingRight;

    void Update()
    {
        MovePlayer();
        UpdateGunPosition();
    }

    void UpdateGunPosition()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -20;
        objectPos = Camera.main.WorldToScreenPoint(gunTranform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        gunTranform.rotation = Quaternion.Euler(0, 0, angle);

        updateSpriteDirection();
    }

    void MovePlayer()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        playerTransform.Translate(direction, Space.World);
    }

    void FlipSprite()
    {
        Vector3 newScale = playerSpriteTransform.localScale;
        newScale.x *= -1;
        playerSpriteTransform.localScale = newScale;
    }

    void updateSpriteDirection()
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
}
