using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

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

    private void Awake()
    {
        if (Instance != null)
        {
            Instance.gameObject.transform.position = Vector3.zero;
            Instance.gameObject.GetComponent<Health>().regen();
            Instance.gameObject.GetComponent<Health>().healthBarGameObject.SetActive(false);
           
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        HUDControlsScript = GameObject.FindWithTag("HUD").GetComponent<HUDControls>();

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
            KeyCode.J,
            KeyCode.K,
            KeyCode.L,
            KeyCode.Z,
            KeyCode.X,
            KeyCode.C,
            KeyCode.V,
            KeyCode.B,
            KeyCode.N,
            KeyCode.M,

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
            up = HandleInput("up", up);
            tempVector = new Vector2(tempVector.x, 1);
        }
        if (Input.GetKeyUp(up))
        {
            up = HandleInput("up", up);
            tempVector = new Vector2(tempVector.x, 0);
        }

        if (Input.GetKey(down))
        {
            down = HandleInput("down", down);
            tempVector = new Vector2(tempVector.x, -1);
        }
        if (Input.GetKeyUp(down))
        {
            down = HandleInput("down", down);
            tempVector = new Vector2(tempVector.x, 0);
        }

        if (Input.GetKey(left))
        {
            left = HandleInput("left", left);
            tempVector = new Vector2(-1, tempVector.y);
        }
        if (Input.GetKeyUp(left))
        {
            left = HandleInput("left", left);
            tempVector = new Vector2(0, tempVector.y);
        }
        if (Input.GetKey(right))
        {
            right = HandleInput("right", right);
            tempVector = new Vector2(1, tempVector.y);
        }
        if (Input.GetKeyUp(right))
        {
            right = HandleInput("right", right);
            tempVector = new Vector2(0, tempVector.y);
        }

        if (Input.GetKey(fire))
        {
            fire = HandleInput("fire", fire);
        }

        this.playerDirection = tempVector;
    }

    public Vector2 PlayerDirection()
    {
        return this.playerDirection;
    }

    KeyCode HandleInput(string keyName, KeyCode key)
    {
        if (key != KeyCode.None) {
        // key pressed
        currentKeys[key] += 1;


            if (currentKeys[key] > lengthOfTimeUsed)
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
                    HUDControlsScript.keyUpdated(keyName);
                }

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

    public int getKeysLeft()
    {
        return keysLeft;
    }
}
