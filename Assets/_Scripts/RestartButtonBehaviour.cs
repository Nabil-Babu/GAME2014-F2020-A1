using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event Handler for the StartButton_Pressed Event
    public void OnRestartButtonPressed()
    {
        Debug.Log("RestartButton Pressed");
        SceneManager.LoadScene("Start");
    }
}
