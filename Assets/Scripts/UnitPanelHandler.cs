using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitPanelHandler : MonoBehaviour
{
    private int xp;
    private GameObject currentTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTower != null)
        {
            xp = currentTower.GetComponent<UnitHandler>().xp;
            transform.Find("XP").transform.Find("XPImage").GetComponent<Image>().fillAmount = Mathf.Clamp(currentTower.GetComponent<UnitHandler>().xp / 100f, 0, 1f);
            transform.Find("XP").GetComponent<TextMeshProUGUI>().text = "XP: " + xp + "/100";
            transform.Find("Mode Text").GetComponent<TextMeshProUGUI>().text ="Current Mode: "+ currentTower.GetComponent<ShootBullets>().mode.ToString();
        }
    }
    public void SetTower(GameObject tower)
    {
        currentTower = tower;
        xp = tower.GetComponent<UnitHandler>().xp;
    }

    public void TogglePanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void Upgrade()
    {
        currentTower.GetComponent<UnitHandler>().LevelUp();
    }
    public void Strongest()
    {
        currentTower.GetComponent<ShootBullets>().mode = ShootBullets.ShootMode.Strongest;
    }
    public void Weakest()
    {
        currentTower.GetComponent<ShootBullets>().mode = ShootBullets.ShootMode.Weakest;
    }
    public void Closest()
    {
        currentTower.GetComponent<ShootBullets>().mode = ShootBullets.ShootMode.Closest;
    }
}
