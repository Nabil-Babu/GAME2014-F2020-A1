/**
    BackgroundController.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    // reseting the position of the background in portrait mode
    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBoundary);
    }
    // Moving background in portrait mode
    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
}
