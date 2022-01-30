using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuElement;
    public GameObject LevelMenuElement;
    public GameObject OptionsMenuElement;
    public GameObject Level1Element;
    public GameObject Level2Element;
    public GameObject Level3Element;

    private int isLevelSelect;
    private int highestLevel;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("highestLevel"));

        if (!PlayerPrefs.HasKey("highestLevel"))
        {
            PlayerPrefs.SetInt("highestLevel", 0);
            Level1Element.SetActive(true);
        }
        else
        {
            highestLevel = PlayerPrefs.GetInt("highestLevel");

            if (highestLevel >= 0)
            {
                Level1Element.SetActive(true);
            }
            if (highestLevel >= 1)
            {
                Level2Element.SetActive(true);
            }
            if (highestLevel >= 2)
            {
                Level3Element.SetActive(true);
            }
        }
        //If the previous scene is Finish, and i click "level select", isLevelSelect = 1
        isLevelSelect = PlayerPrefs.GetInt("isLevelSelect", 0);
        if (isLevelSelect == 1)
        {
            LevelMenuElement.SetActive(true);
            MainMenuElement.SetActive(false);
            OptionsMenuElement.SetActive(false);

            PlayerPrefs.SetInt("isLevelSelect", 0);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void PlayL1()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene("Level1");
    }

    public void PlayL2()
    {
        PlayerPrefs.SetInt("currentLevel", 2);
        SceneManager.LoadScene("Level2");
    }

    public void PlayL3()
    {
        PlayerPrefs.SetInt("currentLevel", 3);
        SceneManager.LoadScene("Level3");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
