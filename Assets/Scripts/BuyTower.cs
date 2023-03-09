using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    public GameObject tower;
    public GameObject spawnlocation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyTowerButton()
    {
        if (FindObjectOfType<CoinsTracker>().GetCoins() >= tower.GetComponent<UnitHandler>().cost)
        {
            Instantiate(tower, spawnlocation.transform.position, Quaternion.identity);
            FindObjectOfType<CoinsTracker>().SpendCoins(tower.GetComponent<UnitHandler>().cost);
            Destroy(gameObject.transform.parent);
            Destroy(gameObject);
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i));
            }
        }
    }
    public void SetTower(GameObject tower)
    {
        this.tower = tower;
    }
}
