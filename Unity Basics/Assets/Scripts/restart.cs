using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // public void LoadMenu()
    // {
    //     SceneManager.LoadScene("Menu");
    // }

    public void LoadLevelSelection() {
        PlayerPrefs.SetInt("isLevelSelect", 1);
        SceneManager.LoadScene("Menu");

    }
}
