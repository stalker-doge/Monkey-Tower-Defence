using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }
    public GameObject FindStrongestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject strongest = null;
        int currentHighest = -1;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyDestroyer>() != null)
            {
                if (enemy.GetComponent<EnemyDestroyer>().tier > currentHighest)
                {
                    strongest = enemy;
                    currentHighest = enemy.GetComponent<EnemyDestroyer>().tier;

                }
            }
            else
            {
                if (enemy.transform.root.GetComponent<EnemyDestroyer>().tier > currentHighest)
                {
                    strongest = enemy;
                    currentHighest = enemy.GetComponent<EnemyDestroyer>().tier;

                }
            }
        }
        return strongest;
    }
    public GameObject FindWeakestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject weakest = null;
        float currentLowest = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyDestroyer>()!=null)
            {
                if (enemy.GetComponent<EnemyDestroyer>().hp < currentLowest)
                {
                    weakest = enemy;
                    currentLowest = enemy.GetComponent<EnemyDestroyer>().hp;

                }
            }
            else
            {
               if( enemy.transform.root.GetComponent<EnemyDestroyer>().hp<currentLowest)
                {
                    weakest = enemy;
                    currentLowest = enemy.GetComponent<EnemyDestroyer>().hp;
                }
            }

        }
        return weakest;
    }
}
