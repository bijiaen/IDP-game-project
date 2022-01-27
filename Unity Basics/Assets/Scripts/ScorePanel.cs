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

            if (!PlayerPrefs.HasKey("L1highscore") || lCoin > highScore)
            {
                highScore = lCoin;
                PlayerPrefs.SetInt("L1highscore", lCoin);
            }
        }
        else if (currentLevel == 2)
        {
            if (PlayerPrefs.HasKey("L2highscore"))
            {
                highScore = PlayerPrefs.GetInt("L2highscore");
            }

            if (!PlayerPrefs.HasKey("L2highscore") || lCoin > highScore)
            {
                highScore = lCoin;
                PlayerPrefs.SetInt("L2highscore", lCoin);
            }
        }
        else if (currentLevel == 3)
        {
            if (PlayerPrefs.HasKey("L3highscore"))
            {
                highScore = PlayerPrefs.GetInt("L3highscore");
            }

            if (!PlayerPrefs.HasKey("L3highscore") || lCoin > highScore)
            {
                highScore = lCoin;
                PlayerPrefs.SetInt("L3highscore", lCoin);
            }
        }
        else
        {
            Debug.Log("highscore not found");
        }

        levelCoinsTextElement.text = "COINS EARNED: " + lCoin.ToString();
        totalCoinsTextElement.text = tCoin.ToString();
        highScoreTextElement.text = "HIGH SCORE: " + highScore.ToString();
    }

}
