using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public EnemyManager enemyManager; 
    public LaserManager laserManager;
    public GameController gameController;
    public float horizontalSpeed;
    public float verticalSpeed;
    public float fireDelay;
    public float horizontalBoundary;
    public float verticalBoundary;
    private float direction = 1;
    [SerializeField]
    private int value;
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        laserManager = FindObjectOfType<LaserManager>();
        gameController = FindObjectOfType<GameController>();
        StartCoroutine(FireLasers());  
    }
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, -verticalSpeed * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }
        // check left boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }
        // check bottom boundary
        if(transform.position.y <= -verticalBoundary)
        {
            enemyManager.ReturnEnemy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        gameController.IncreaseScore(value);
        enemyManager.ReturnEnemy(gameObject);
    }

    IEnumerator FireLasers()
    {
        if(transform.position.y <= verticalBoundary && laserManager.HasLasers(true))
        {
            Debug.Log("Firing laser enemy");
            laserManager.GetLaser(transform.position, true);
        }
        yield return new WaitForSeconds(fireDelay);
        StartCoroutine(FireLasers());
    }
}
