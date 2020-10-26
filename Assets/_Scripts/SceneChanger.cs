/**
    SceneChanger.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneDestination; 

    public void ChangeScene()
    {
        SoundManager.instance.PLaySE("ButtonSelected");
        SceneManager.LoadScene(sceneDestination);
    }
}
