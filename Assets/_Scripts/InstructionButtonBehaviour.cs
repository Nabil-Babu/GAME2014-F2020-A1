/**
    InstructionButtonBehaviour.cs
    Nabil Babu
    101214336
    Oct 4th 2020
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionButtonBehaviour : MonoBehaviour
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
    public void OnInstructionButtonPressed()
    {
        Debug.Log("Instruction Button Pressed");
        SceneManager.LoadScene("Instructions");
    }
}
