using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Text levelCoinsTextElement, totalCoinsTextElement, highScoreTextElement;

    private int lCoin, tCoin, currentLevel, highScore;


    // Start is called before the first frame update
    void Start()
    {
        tCoin = PlayerPrefs.GetInt("totalcoins", 0);
        lCoin = PlayerPrefs.GetInt("levelcoins", 0);
        currentLevel = PlayerPrefs.GetInt("currentLevel");

        if (currentLevel == 1)
        {
            if (PlayerPrefs.HasKey("L1highscore"))
            {
                highScore = PlayerPrefs.GetInt("L1highscore");
            }
            else
            {
                highScore = lCoin;
                PlayerPrefs.SetInt("L1highscore", highScore);
            }
        }
        else if (currentLevel == 2)
        {
            if (PlayerPrefs.HasKey("L2highscore"))
            {
                highScore = PlayerPrefs.GetInt("L2highscore");
            }
            else
            {
                highScore = lCoin;
                PlayerPrefs.SetInt("L2highscore", highScore);
            }
        }
        else if (currentLevel == 3)
        {
            if (PlayerPrefs.HasKey("L3highscore"))
            {
                highScore = PlayerPrefs.GetInt("L3highscore");
            }
            else
            {
                highScore = lCoin;
                PlayerPrefs.SetInt("L3highscore", highScore);
            }
        }
        else
        {
            Debug.Log("No highscore found");
        }
        levelCoinsTextElement.text = "COINS EARNED: " + lCoin.ToString();
        totalCoinsTextElement.text = tCoin.ToString();
        highScoreTextElement.text = "HIGH SCORE: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
