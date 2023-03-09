using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAndShowMenu : MonoBehaviour
{
    public Canvas[] menu;
    public GameObject[] SpawnCubes;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnCubes = GameObject.FindGameObjectsWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMenu()
    {
        foreach (GameObject m in SpawnCubes)
        {
            if(m!=null)
            {
                m.transform.GetChild(0).gameObject.SetActive(!m.transform.GetChild(0).gameObject.activeSelf);

            }
        }
    }
    public void SetTowerType(GameObject tower)
    {
        foreach (GameObject t in SpawnCubes)
        {
            if(t!=null)
            {
                t.GetComponent<BuyTower>().SetTower(tower);
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        GameObject.Find("Menu").transform.Find("PauseMenu").gameObject.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameObject.Find("Menu").transform.Find("PauseMenu").gameObject.SetActive(false);
    }
}
