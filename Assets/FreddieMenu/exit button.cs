using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{   
    public float delayInSeconds = 1f;

    
    public void OnStart2Click()
    {
        StartCoroutine(LoadSceneAfterDelay(delayInSeconds)); 
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Load the scene.
        SceneManager.LoadScene(0);
    }
} 