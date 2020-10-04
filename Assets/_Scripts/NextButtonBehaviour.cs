using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonBehaviour : MonoBehaviour
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
    public void OnNextButtonPressed()
    {
        Debug.Log("NextButton Pressed");
        SceneManager.LoadScene("End");
    }
}
