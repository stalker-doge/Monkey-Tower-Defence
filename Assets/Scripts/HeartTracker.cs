using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartTracker : MonoBehaviour
{
    private int hearts = 100;
    [SerializeField] private TextMeshProUGUI heartUI;
    // Start is called before the first frame update
    void Start()
    {
        heartUI.text = "Hearts: " + hearts.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        heartUI.text = "Hearts: " + hearts.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (hearts == 0)
            {
                FindObjectOfType<CoinsTracker>().SpendCoins(FindObjectOfType<CoinsTracker>().GetCoins());
                FindObjectOfType<LevelLoader>().LoadLose();
            }
            else
            {
                hearts = hearts - other.gameObject.GetComponent<EnemyDestroyer>().dmg;
            }
            Destroy(other.gameObject);
        }
    }
}

