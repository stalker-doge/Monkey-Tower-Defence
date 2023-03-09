using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] public float hp=1;
    [SerializeField] public float maxHP = 1;
    [SerializeField] public int tier=1;
    [SerializeField] public int dmg = 1;
    [SerializeField] public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Projectile")
        {
            if (hp <= 0)
            {
                FindObjectOfType<CoinsTracker>().EarnCoins(tier * 10);
                other.gameObject.transform.parent.GetComponent<UnitHandler>().EarnXP(tier * 10);

                gameObject.SetActive(false);
                Destroy(gameObject);


            }
            else
            {
                hp -= other.gameObject.transform.parent.GetComponent<UnitHandler>().dmg;
            }
        }
    }
    public int TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            FindObjectOfType<CoinsTracker>().EarnCoins(tier * 10);
            gameObject.SetActive(false);
            Destroy(gameObject);

            return tier*10;
        }
        else return 0;
    }
}
