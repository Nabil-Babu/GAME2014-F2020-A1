/**
    PlayerController.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    BOLT,
    SHIELD,
    STAR
}
public class PowerUpController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public PowerUpType powerUpType; 
    public PowerUpManager powerUpManager; 

    void Start()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>(); 
    }

    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, -verticalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.y < -verticalBoundary)
        {
            powerUpManager.returnPowerUp(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        powerUpManager.returnPowerUp(gameObject);
    }
}
