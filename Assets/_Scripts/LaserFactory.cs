/**
    LaserFactory.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFactory : MonoBehaviour
{
    public GameObject playerLaser;
    public GameObject enemyLaser; 
    public GameObject createLaser(bool enemyLaserFlag)
    {
        GameObject tempLaser = null;
        if(!enemyLaserFlag)
        {
            tempLaser = Instantiate(playerLaser);
        }
        else 
        {
            tempLaser = Instantiate(enemyLaser);
        }
        
        tempLaser.transform.parent = transform;
        tempLaser.SetActive(false);
        return tempLaser;
    }
}
