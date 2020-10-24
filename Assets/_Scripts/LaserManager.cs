using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public LaserFactory laserFactory;
    public int MaxLasers;
     private Queue<GameObject> m_laserPool; 
    // Start is called before the first frame update
    void Start()
    {
        laserFactory = GetComponent<LaserFactory>();
        _BuildLaserPool();
    }

    private void _BuildLaserPool()
    {
        // create empty Queue structure
        m_laserPool = new Queue<GameObject>();

        for (int count = 0; count < MaxLasers; count++)
        {
            var tempLaser = laserFactory.createLaser();
            m_laserPool.Enqueue(tempLaser);
        }
    }
    public GameObject GetLaser(Vector3 position)
    {
        var newLaser = m_laserPool.Dequeue();
        newLaser.SetActive(true);
        newLaser.transform.position = position;
        return newLaser;
    }

    public bool HasLasers()
    {
        return m_laserPool.Count > 0;
    }

    public void ReturnLaser(GameObject returnedLaser)
    {
        returnedLaser.SetActive(false);
        m_laserPool.Enqueue(returnedLaser);
    }
}
