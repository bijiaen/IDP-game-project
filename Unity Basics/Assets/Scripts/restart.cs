using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{

    private int currentLevel;
    private int highestLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        highestLevel = PlayerPrefs.GetInt("highestLevel");

        if (currentLevel > highestLevel)
        {
            PlayerPrefs.SetInt("highestLevel", currentLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        if (currentLevel == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (currentLevel == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentLevel == 3)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevelSelection()
    {
        PlayerPrefs.SetInt("isLevelSelect", 1);
        SceneManager.LoadScene("Menu");

    }
}
