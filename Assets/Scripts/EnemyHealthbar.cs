using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{

    public Image healthBar;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(enemy.GetComponent<EnemyDestroyer>().hp/ enemy.GetComponent<EnemyDestroyer>().maxHP, 0, 1f);
    }
}
