using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int level;
    public int currentLevel;
    public int maxLevel;
    // Start is called before the first frame update
    void Start()
    {
        maxLevel = SceneManager.sceneCountInBuildSettings-2;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void LoadNextLevel()
    {
        if (level < maxLevel)
        {
            level++;
            SceneManager.LoadScene(level);
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }
    public int GetCurrentLevel()
    {
        return level;
    }
    public void LoadLose()
    {
        SceneManager.LoadScene("Loss");
    }
}
