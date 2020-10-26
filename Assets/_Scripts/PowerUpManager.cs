/**
    PowerUpManager.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PowerUpFactory))]
public class PowerUpManager : MonoBehaviour
{
    public int maxBolts;
    public int maxShield;
    public int maxStars;
    public PowerUpFactory powerUpFactory;  
    private Queue<GameObject> m_boltPool;
    private Queue<GameObject> m_shieldPool;
    private Queue<GameObject> m_starPool;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        powerUpFactory = GetComponent<PowerUpFactory>();
        _BuildPowerUpPools();
        StartCoroutine(SpawnPowerUp()); 
    }

    IEnumerator SpawnPowerUp()
    {
        int powerUpRoll = Random.Range(1, 100);
        if(powerUpRoll >= 1 && powerUpRoll < 75)
        {
            GetPowerUp(new Vector3(transform.position.x+(Random.Range(-2,2)), transform.position.y, 0), PowerUpType.BOLT); 
        } 
        else if(powerUpRoll >= 76 && powerUpRoll < 95) 
        {
            GetPowerUp(new Vector3(transform.position.x+(Random.Range(-2,2)), transform.position.y, 0), PowerUpType.SHIELD);
        } 
        else 
        {
            GetPowerUp(new Vector3(transform.position.x+(Random.Range(-2,2)), transform.position.y, 0), PowerUpType.STAR);
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnPowerUp());
    }

    private void _BuildPowerUpPools()
    {
        // create empty Queue structure
        m_boltPool = new Queue<GameObject>();
        m_shieldPool = new Queue<GameObject>();
        m_starPool = new Queue<GameObject>();

        for (int count = 0; count < maxBolts; count++)
        {
            var tempPowerup = powerUpFactory.createPowerUp(PowerUpType.BOLT);
            m_boltPool.Enqueue(tempPowerup);
        }
        for (int count = 0; count < maxShield; count++)
        {
            var tempPowerup = powerUpFactory.createPowerUp(PowerUpType.SHIELD);
            m_shieldPool.Enqueue(tempPowerup);
        }
        for (int count = 0; count < maxStars; count++)
        {
            var tempPowerup = powerUpFactory.createPowerUp(PowerUpType.STAR);
            m_starPool.Enqueue(tempPowerup);
        }
    }
    public GameObject GetPowerUp(Vector3 position, PowerUpType type)
    {
        GameObject newPowerUp = null;
        switch(type)
        {
            case PowerUpType.BOLT:
                newPowerUp = m_boltPool.Dequeue();
                break;
            case PowerUpType.SHIELD:
                newPowerUp = m_shieldPool.Dequeue();
                break;
            case PowerUpType.STAR:
                newPowerUp = m_starPool.Dequeue();
                break;
        }
        
        newPowerUp.SetActive(true);
        newPowerUp.transform.position = position;
        return newPowerUp;
    }

    public bool HasPower(PowerUpType type)
    {
        switch(type)
        {
            case PowerUpType.BOLT:
                return m_boltPool.Count > 0;
            case PowerUpType.SHIELD:
                return m_shieldPool.Count > 0;
            case PowerUpType.STAR:
                return m_starPool.Count > 0;
        }
        return false; 
    }

    public void returnPowerUp(GameObject powerUp)
    {   
        switch(powerUp.GetComponent<PowerUpController>().powerUpType)
        {
            case PowerUpType.BOLT:
                m_boltPool.Enqueue(powerUp);
                break;
            case PowerUpType.SHIELD:
                m_shieldPool.Enqueue(powerUp);
                break;
            case PowerUpType.STAR:
                m_starPool.Enqueue(powerUp);
                break;
        }
        powerUp.SetActive(false);
    }
}
