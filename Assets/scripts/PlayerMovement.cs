using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform gunTranform;
    public Transform playerTransform;
    private Vector3 mousePos;
    private Vector3 objectPos;
    public PlayerInput playerInput;
    private float angle;
<<<<<<< HEAD
    public GameObject bullet;
    /*private int seconds = 1;
    private int miliseconds = 500;
    TimeSpan clock = new TimeSpan(0, 0, 0, seconds, miliseconds)*/
    
=======
    public float speed;
>>>>>>> b805e848b690418c66a8494ef3dd1889435d9aea

    void Update()
    {
        MovePlayer();
        UpdateGunPosition();
        shot();
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
    }

<<<<<<< HEAD
    void shot()
    {
        Instantiate(bullet);
    }
}
=======
    void MovePlayer()
    {
        Vector2 direction = playerInput.PlayerDirection() * speed;

        transform.Translate(direction * Time.deltaTime, Space.World);
    }
};
>>>>>>> b805e848b690418c66a8494ef3dd1889435d9aea
