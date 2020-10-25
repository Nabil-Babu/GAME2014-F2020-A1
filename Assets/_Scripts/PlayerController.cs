﻿/**
    PlayerController.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public LaserManager laserManager;

    [Header("Boundary Check")]
    public float horizontalBoundary;
    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    [Header("Player Attributes")]
    public float burstFireTime;
    public float invincibleModeTime;
    [Range(0.01f, 0.99f)]
    public float fireDelayDecayRate;
    [Header("Player UI")]
    public Image[] lifeIcons;
    public float horizontalTValue;
    [Header("Bullet Firing")]
    public float startingFireDelay;  
    public float fireDelay;
    public bool Firing 
    {
        get 
        {
            return _firing; 
        }
        set
        {
            _firing = value;
            if(_firing)
            {
                StartCoroutine(FireTheLasers());
            } 
            else 
            {
                StopAllCoroutines(); 
            }
        }
    }
    
    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
            UpdateIconUI();
        }
    }
    // Private variables
    private int _lives = 3;   
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;
    private bool _firing = false;
    private bool canTakeDamage = true; 
    private bool canFire = true;
    
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
        _Move();
        _CheckBounds();
        _CheckIfFiring();
    }

    private void _CheckIfFiring()
    {
        if(Input.touches.Length > 0)
        {
            if(!Firing)
            {
                Firing = true; 
            }
        } 
        else 
        {
            Firing = false; 
        }
    }

    IEnumerator FireTheLasers()
    {
        if(laserManager.HasLasers(true))
        {
            laserManager.GetLaser(transform.position, false);
        }
        yield return new WaitForSeconds(fireDelay);
        StartCoroutine(FireTheLasers()); 
    }


    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.x != 0.0f)
        {
           transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.x, horizontalTValue), transform.position.y);
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        // check left bounds
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpController powerUp; 
        if(other.GetComponent<LaserController>())
        {
            if(other.GetComponent<LaserController>().isEnemyLaser)
            {
                if(canTakeDamage)
                {
                    if(Lives > 0)
                    {
                        Lives--;
                    }
                }
            }
        }

        if(other.TryGetComponent<PowerUpController>(out powerUp))
        {
            Debug.Log("Getting Power Up");
            switch(powerUp.powerUpType)
            {
                case PowerUpType.BOLT:
                    StartCoroutine(BurstFireMode());
                    break;
                case PowerUpType.SHIELD:
                    StartCoroutine(InvincibleMode());
                    break;
                case PowerUpType.STAR:
                    Debug.Log("Getting Star");
                    break;
            }
        }
    }

    IEnumerator BurstFireMode()
    {
        fireDelay *= fireDelayDecayRate; 
        yield return new WaitForSeconds(burstFireTime);
        fireDelay = startingFireDelay; 
    }

    IEnumerator InvincibleMode()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invincibleModeTime);
        canTakeDamage = true;  
    }

    IEnumerator StarMode()
    {
        yield return new WaitForSeconds(3.0f);
    }

    void UpdateIconUI()
    {
        foreach (Image icon in lifeIcons)
        {
            icon.gameObject.SetActive(false); 
        }

        for (int i = 0; i < Lives; i++)
        {
            lifeIcons[i].gameObject.SetActive(true);
        }
    }
}
