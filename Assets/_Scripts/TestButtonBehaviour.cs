using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestButtonBehaviour : MonoBehaviour
{
    public TMP_Text sceneLabel; 
    public TMP_Text LivesLabel;
    public TMP_Text ScoreLabel; 
   

    // Event Handler for the StartButton_Pressed Event
    public void OnTestButtonPressed()
    {
        Debug.Log("TestButton Pressed");
        
    }
}
