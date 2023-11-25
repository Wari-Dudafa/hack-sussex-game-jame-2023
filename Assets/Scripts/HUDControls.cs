using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControls : MonoBehaviour
{
    public Text up, down, left, right, fire;
    public PlayerInput inputScript;

    private Dictionary<string, KeyCode> keysDict;

    void Start()
    {
        inputScript = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        keysDict = new Dictionary<string, KeyCode>();
        updateKeys();
    }

    void Update() { }

    public void updateKeys()
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
}
