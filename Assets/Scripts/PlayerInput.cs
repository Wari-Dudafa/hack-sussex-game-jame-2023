using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private List<KeyCode> availableKeys;
    public Dictionary<KeyCode, int> currentKeys;
    private int keysLeft;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode fire;

    public int maxTimesUsed = 5;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(up))
        {
            up = handleInput(up);
        }

        if (Input.GetKeyDown(down))
        {
            down = handleInput(down);
        }

        if (Input.GetKeyDown(left))
        {
            left = handleInput(left);
        }

        if (Input.GetKeyDown(right))
        {
            right = handleInput(right);
        }

        if (Input.GetKeyDown(fire))
        {
            fire = handleInput(fire);
        }
    }

    KeyCode handleInput(KeyCode key)
    {

        Debug.Log("Key pressed" + key);
        currentKeys[key] += 1;

        if (currentKeys[key] > maxTimesUsed)
        {
            currentKeys.Remove(key);
            keysLeft -= 1;

            if (keysLeft <= 0)
            {
                key = KeyCode.None;
                Debug.Log("No more keys available!");
            }
            else
            {
                key = availableKeys.ToArray<KeyCode>()[Random.Range(0, keysLeft - 1)];
                availableKeys.Remove(key);

                currentKeys.Add(key, 0);

                Debug.Log("New key = " + key);
            }
        }
        return key;
    }
}
