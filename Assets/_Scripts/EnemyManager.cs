/**
    EnemyManager.cs
    Nabil Babu
    101214336
    Oct 24th 2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyFactory))]
public class EnemyManager : MonoBehaviour
{
    public EnemyFactory enemyFactory;
    public int MaxEnemies; 
    private Queue<GameObject> m_EnemyPool;
    public float spawnDelay; 
    void Start()
    {
        _BuildEnemyPool();
        StartCoroutine(SpawnEnemy());
    }
    
    IEnumerator SpawnEnemy()
    {
        GetEnemy(new Vector3(transform.position.x+(Random.Range(-2,2)), transform.position.y, 0));
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnEnemy());
    }
    private void _BuildEnemyPool()
    {
        // create empty Queue structure
        m_EnemyPool = new Queue<GameObject>();

        for (int count = 0; count < MaxEnemies; count++)
        {
            var tempEnemy = enemyFactory.createEnemy();
            m_EnemyPool.Enqueue(tempEnemy);
        }
    }
    public GameObject GetEnemy(Vector3 position)
    {
        var newEnemy = m_EnemyPool.Dequeue();
        newEnemy.SetActive(true);
        newEnemy.transform.position = position;
        return newEnemy;
    }
    public bool HasEnemies()
    {
        return m_EnemyPool.Count > 0;
    }
    public void ReturnEnemy(GameObject returnedEnemy)
    {
        returnedEnemy.SetActive(false);
        m_EnemyPool.Enqueue(returnedEnemy);
    }
}
