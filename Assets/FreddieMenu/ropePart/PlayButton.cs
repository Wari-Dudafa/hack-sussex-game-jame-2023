using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{   
    public string parameterName = "PlayParam";
    public Animator animator; // Reference to the Animator component
    public float delayInSeconds = 2f;

    void Start() 
    {
        
    }
    void Update()
    {

    }
    
    public void OnButtonClick()
    {
        if (animator != null)
        {
            animator.SetInteger(parameterName, 1);
        }

        StartCoroutine(LoadSceneAfterDelay(delayInSeconds)); 
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Load the scene.
        SceneManager.LoadScene(1);
    }
} 