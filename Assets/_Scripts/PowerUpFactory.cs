/**
    PlayerController.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory : MonoBehaviour
{
    public GameObject bolt;
    public GameObject shield;
    public GameObject star;

    public GameObject createPowerUp(PowerUpType type)
    {
        GameObject powerUp = null;
        switch(type)
        {
            case PowerUpType.BOLT:
                powerUp = Instantiate(bolt);
                break;
            case PowerUpType.SHIELD:
                powerUp = Instantiate(shield);
                break;
            case PowerUpType.STAR:
                powerUp = Instantiate(star);
                break;
            default:
                break;
        }
        powerUp.transform.parent = this.transform;
        powerUp.SetActive(false);  
        return powerUp;
    }
}
