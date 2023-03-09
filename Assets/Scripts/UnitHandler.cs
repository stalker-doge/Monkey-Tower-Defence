using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitHandler : MonoBehaviour
{
    public enum UnitType
    {
        Mage,
        Ranger,
        Warrior
    }
    public int cost = 100;
    public UnitType unitType;
    public int xp = 0;
    public int xpToLevel = 100;
    public int dmg = 1;
    public float fireRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnXP(int xp)
    {
        this.xp += xp;
    }
    public void LevelUp()
    {
        if (xp >= xpToLevel)
        {
            xp -= xpToLevel;
            xpToLevel *= 2;
            dmg++;
            fireRate=fireRate/2;
            
            LevelUp();
        }
    }

    public void ShowMenu()
    {
        GameObject.Find("Menu").transform.Find("Unit Panel").GetComponent<UnitPanelHandler>().TogglePanel();
        GameObject.Find("Menu").transform.Find("Unit Panel").GetComponent<UnitPanelHandler>().SetTower(gameObject);

    }
    private void OnMouseDown()
    {
        ShowMenu();
    }
}
