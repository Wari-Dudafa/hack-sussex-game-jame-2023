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
    public PlayerInput playerInput;
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
        mousePos.z = -20;
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(gunTranform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        gunTranform.rotation = Quaternion.Euler(0, 0, angle);

        updateSpriteDirection();
    }

    void MovePlayer()
    {
        Vector2 direction = playerInput.PlayerDirection() * speed;
        transform.Translate(direction * Time.deltaTime, Space.World);
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
};
