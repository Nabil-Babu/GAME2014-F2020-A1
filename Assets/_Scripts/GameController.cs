/**
    GameController.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
[RequireComponent(typeof(SceneChanger))]
public class GameController : MonoBehaviour
{
    public int PlayerScore;
    public bool playerAlive = true;
    public PlayerController player;
    public TextMeshProUGUI score; 
    private SceneChanger sceneChanger;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
        sceneChanger = GetComponent<SceneChanger>();
        score.text = PlayerScore.ToString();
    }

    public void Update()
    {
        CheckForPlayerDeath();
    }
    public void IncreaseScore(int value)
    {
        PlayerScore+=value;
        score.text = PlayerScore.ToString(); 
    }

    public void CheckForPlayerDeath()
    {
        if(player.lives > 0)
        {
            playerAlive = true;
        } 
        else 
        {
            playerAlive = false;
            player.gameObject.SetActive(false);
            Invoke("GameOver", 3.0f);     
        }
    }

    public void GameOver()
    {
        sceneChanger.ChangeScene();
    }

    // Update UI for and Lives

}
