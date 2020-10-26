/**
    LoadScore.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadScore : MonoBehaviour
{
    public TextMeshProUGUI score; 
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Final Score: "+PlayerPrefs.GetInt("score").ToString();
    }
}
