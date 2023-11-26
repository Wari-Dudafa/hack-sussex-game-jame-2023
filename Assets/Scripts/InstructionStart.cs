using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InstructionStart : MonoBehaviour
{   
    public float delayInSeconds = 0.5f;

    
    public void OnStartClick()
    {
        StartCoroutine(LoadSceneAfterDelay(delayInSeconds)); 
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Load the scene.
        SceneManager.LoadScene(2);
    }
} 