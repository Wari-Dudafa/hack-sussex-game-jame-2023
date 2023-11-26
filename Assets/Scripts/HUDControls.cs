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
        fire;
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
        fire.text = keysDict["fire"].ToString();
    }

    public void keyUpdated(string keyName)
    {
        switch (keyName)
        {
            case "up":
                //
                break;
            case "down":
                //
                break;
            case "left":
                //
                break;
            case "right":
                //
                break;
            case "fire":
                //
                break;
        }
            
    }
}
