using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Texture[] tutorialImage;
    private int currentimage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NextImage()
    {
        if (currentimage < tutorialImage.Length)
        {
            GameObject.Find("Canvas").GetComponent<RawImage>().texture = tutorialImage[currentimage];
            currentimage++;
        }else
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }

    }
}
