using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public HUDControls HUDControlsScript;
    private List<KeyCode> availableKeys;
    public Dictionary<KeyCode, int> currentKeys;
    private int keysLeft;
    public Vector2 playerDirection;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode fire;

    public int lengthOfTimeUsed;

    void Start()
    {
        availableKeys = new List<KeyCode>()
        {
            KeyCode.Q,
            KeyCode.E,
            KeyCode.R,
            KeyCode.T,
            KeyCode.Y,
            KeyCode.U,
            KeyCode.I,
            KeyCode.O,
            KeyCode.P,
            KeyCode.F,
            KeyCode.G,
            KeyCode.H,
        };

        keysLeft = availableKeys.Count;

        up = KeyCode.W;
        down = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
        fire = KeyCode.Mouse0;

        currentKeys = new Dictionary<KeyCode, int>()
        {
            { up, 0 },
            { down, 0 },
            { left, 0 },
            { right, 0 },
            { fire, 0 },
        };
    }

    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        Vector2 tempVector = new Vector2(0, 0);

        if (Input.GetKey(up))
        {
            up = HandleInput(up);
            tempVector = new Vector2(tempVector.x, 1);
        }
        if (Input.GetKeyUp(up))
        {
            up = HandleInput(up);
            tempVector = new Vector2(tempVector.x, 0);
        }

        if (Input.GetKey(down))
        {
            down = HandleInput(down);
            tempVector = new Vector2(tempVector.x, -1);
        }
        if (Input.GetKeyUp(down))
        {
            down = HandleInput(down);
            tempVector = new Vector2(tempVector.x, 0);
        }

        if (Input.GetKey(left))
        {
            left = HandleInput(left);
            tempVector = new Vector2(-1, tempVector.y);
        }
        if (Input.GetKeyUp(left))
        {
            left = HandleInput(left);
            tempVector = new Vector2(0, tempVector.y);
        }
        if (Input.GetKey(right))
        {
            right = HandleInput(right);
            tempVector = new Vector2(1, tempVector.y);
        }
        if (Input.GetKeyUp(right))
        {
            right = HandleInput(right);
            tempVector = new Vector2(0, tempVector.y);
        }

        if (Input.GetKey(fire))
        {
            fire = HandleInput(fire);
        }

        this.playerDirection = tempVector;
    }

    public Vector2 PlayerDirection()
    {
        return this.playerDirection;
    }

    KeyCode HandleInput(KeyCode key)
    {
        // key pressed
        currentKeys[key] += 1;

        if (currentKeys[key] > 999999999)
        {
            currentKeys.Remove(key);
            keysLeft -= 1;

            if (keysLeft <= 0)
            {
                // No more keys available
                key = KeyCode.None;
            }
            else
            {
                key = availableKeys.ToArray<KeyCode>()[UnityEngine.Random.Range(0, keysLeft - 1)];
                availableKeys.Remove(key);

                // New key
                currentKeys.Add(key, 0);

                HUDControlsScript.updateKeys();
                Debug.Log("New key = " + key);
            }
        }
        return key;
    }

    public Dictionary<string, KeyCode> getKeyBinds()
    {
        Dictionary<string, KeyCode> temp = new Dictionary<string, KeyCode>()
        {
            { "up", up },
            { "down", down },
            { "left", left },
            { "right", right },
            { "fire", fire },
        };

        return temp;
    }
}
