using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class HUDControls : MonoBehaviour
{
    public static HUDControls Instance;

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

    private int score;
    private int keysLeft;
    public Text scoreboard;
    public Text keysLeftHUD;
    public int killCount;
    public int killsToNextLevel;

    private int sceneNum;

    private void Awake()
    {
        if (Instance != null && sceneNum == 0)
        {
            Instance.sceneNum += 1;
            Instance.killCount = 0;
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        inputScript = player.GetComponent<PlayerInput>();
        keysLeftHUD = GameObject.FindWithTag("KeysLeft").GetComponent<Text>();
        killCount = 0;
        killsToNextLevel = 20;
        sceneNum = 1;

        keysDict = new Dictionary<string, KeyCode>();
    }

    void Update()
    {
        updateKeys();
        if (killCount >= killsToNextLevel)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
        }
    }

    public void RetrnToMainMenu()
    {
        sceneNum = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
    }

    void updateKeys()
    {
        keysDict = inputScript.getKeyBinds();
        keysLeft = inputScript.getKeysLeft();
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

        keysLeftHUD.text = keysLeft.ToString();
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

    public void addScore(int points)
    {
        killCount += 1;
    }
}
