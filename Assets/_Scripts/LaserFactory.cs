using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFactory : MonoBehaviour
{
    public GameObject playerLaser;

    public GameObject createLaser()
    {
        GameObject tempLaser = null;
        tempLaser = Instantiate(playerLaser);
        tempLaser.transform.parent = transform;
        tempLaser.SetActive(false);
        return tempLaser;
    }
}
