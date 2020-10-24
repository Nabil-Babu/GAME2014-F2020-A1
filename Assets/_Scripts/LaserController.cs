using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public LaserManager laserManager;
    public int damage;
    // Update is called once per frame

    void Start()
    {
        laserManager = FindObjectOfType<LaserManager>();
    }
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
    }
    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            laserManager.ReturnLaser(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        laserManager.ReturnLaser(gameObject);
    }
}
