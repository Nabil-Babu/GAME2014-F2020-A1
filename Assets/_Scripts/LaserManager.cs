using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public LaserFactory laserFactory;
    public int MaxPlayerLasers;
    public int MaxEnemyLasers;
    private Queue<GameObject> m_playerlaserPool;
    private Queue<GameObject> m_enemylaserPool;
    // Start is called before the first frame update
    void Start()
    {
        laserFactory = GetComponent<LaserFactory>();
        _BuildPlayerLaserPool();
        _BuildEnemyLaserPool();
    }

    private void _BuildPlayerLaserPool()
    {
        // create empty Queue structure
        m_playerlaserPool = new Queue<GameObject>();

        for (int count = 0; count < MaxPlayerLasers; count++)
        {
            var tempLaser = laserFactory.createLaser(false);
            m_playerlaserPool.Enqueue(tempLaser);
        }
    }

    private void _BuildEnemyLaserPool()
    {
        // create empty Queue structure
        m_enemylaserPool = new Queue<GameObject>();

        for (int count = 0; count < MaxEnemyLasers; count++)
        {
            var tempLaser = laserFactory.createLaser(true);
            m_enemylaserPool.Enqueue(tempLaser);
        }
    }
    public GameObject GetLaser(Vector3 position, bool enemyFlag)
    {
        GameObject newLaser;
        if(enemyFlag)
        {
            newLaser = m_enemylaserPool.Dequeue();
        } 
        else 
        {
            newLaser = m_playerlaserPool.Dequeue();
        }
        
        newLaser.SetActive(true);
        newLaser.transform.position = position;
        return newLaser;
    }

    public bool HasLasers(bool enemyFlag)
    {
        if(enemyFlag)
        {
            return m_enemylaserPool.Count > 0;
        } 
        else 
        {
            return m_playerlaserPool.Count > 0;
        }
        
    }

    public void ReturnLaser(GameObject returnedLaser, bool enemyFlag)
    {
        returnedLaser.SetActive(false);
        if(enemyFlag)
        {
            m_enemylaserPool.Enqueue(returnedLaser);
        } 
        else 
        {
            m_playerlaserPool.Enqueue(returnedLaser);
        }
        
    }
}
