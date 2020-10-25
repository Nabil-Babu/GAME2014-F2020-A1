using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [Header("Enemy Types")]
    public GameObject regularEnemy;
    // Start is called before the first frame update
    public GameObject createEnemy()
    {
        GameObject tempEnemy = null;

        tempEnemy = Instantiate(regularEnemy);
        tempEnemy.transform.parent = transform;
        tempEnemy.SetActive(false);

        return tempEnemy;
    }
}
