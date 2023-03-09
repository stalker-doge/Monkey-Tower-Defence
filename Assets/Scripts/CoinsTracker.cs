using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsTracker : MonoBehaviour
{
    private int coins = 100;
    private int totalCoins = 100;
    [SerializeField] private TextMeshProUGUI scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text ="Coins: "+ coins.ToString();
    }

    public void SpendCoins(int amount)
    {
        coins -= amount;
    }

    public void EarnCoins(int amount)
    {
        coins += amount;
        totalCoins += amount;
    }
    public int GetCoins()
    {
        return coins;
    }
    public int GetTotal()
    {
        return totalCoins;
    }
}
