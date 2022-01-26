﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuElement;
    public GameObject LevelMenuElement;
    public GameObject OptionsMenuElement;

    private int isLevelSelect;

    void Start() 
    {
        isLevelSelect = PlayerPrefs.GetInt("isLevelSelect", 0);
        if (isLevelSelect == 1) {
            LevelMenuElement.SetActive(true);
            MainMenuElement.SetActive(false);
            OptionsMenuElement.SetActive(false);

            PlayerPrefs.SetInt("isLevelSelect", 0);
        }
    }

   

    // public void PlayGame()
    // {
    //     SceneManager.LoadScene("Level1");
    // }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void PlayL1() {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene("Level1");
    }

    public void PlayL2() {
        PlayerPrefs.SetInt("currentLevel", 2);
        SceneManager.LoadScene("Level2");
    }

    public void PlayL3() {
        PlayerPrefs.SetInt("currentLevel", 3);
        SceneManager.LoadScene("Level3");
    }
}
