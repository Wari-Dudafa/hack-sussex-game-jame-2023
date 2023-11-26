using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControls : MonoBehaviour
{
    public Text up,
        down,
        left,
        right,
        up2,
        down2,
        left2,
        right2;

    public Animator animatorLEFT,
        animatorRIGHT,
        animatorUP,
        animatorDOWN;
    public PlayerInput inputScript;

    private Dictionary<string, KeyCode> keysDict;

    void Start()
    {

        GameObject player = GameObject.FindWithTag("Player");
        inputScript = player.GetComponent<PlayerInput>();

        keysDict = new Dictionary<string, KeyCode>();
        updateKeys();
    }

    void Update()
    {
        updateKeys();
    }


    void updateKeys()
    {
        keysDict = inputScript.getKeyBinds();
        displayKeys();
    }

    void displayKeys()
    {
        up.text = keysDict["up"].ToString();
        down.text = keysDict["down"].ToString();
        left.text = keysDict["left"].ToString();
        right.text = keysDict["right"].ToString();
        up2.text = keysDict["up"].ToString();
        down2.text = keysDict["down"].ToString();
        left2.text = keysDict["left"].ToString();
        right2.text = keysDict["right"].ToString();
    }

    public void keyUpdated(string keyName)
    {
        switch (keyName)
        {
            case "up":
                if (animatorUP != null)
                {
                    animatorUP.SetTrigger("UpAnimator");
                }
                break;
            case "down":
                if (animatorDOWN != null)
                {
                    animatorDOWN.SetTrigger("DownTrigger");
                }
                break;
            case "left":
                if (animatorLEFT != null)
                {
                    animatorLEFT.SetTrigger("LeftTrigger");
                }
                break;
            case "right":
                if (animatorRIGHT != null)
                {
                    animatorRIGHT.SetTrigger("RightInput");
                }
                break;
        }

    }
}