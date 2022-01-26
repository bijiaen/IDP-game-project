using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Text levelCoinsTextElement;
    //public Text totalCoinsTextElement;

    private int lCoin;
    //private int tCoin;

    
    // Start is called before the first frame update
    void Start()
    {
        lCoin = PlayerPrefs.GetInt("levelcoins", 0);
        //tCoin = PlayerPrefs.GetInt("totalcoins", 0);

        //Debug.Log("IN  GAMEOVER" + tCoin);

        levelCoinsTextElement.text = "LEVEL COINS: " + lCoin.ToString();
        //totalCoinsTextElement.text = "TOTAL COINS: " + tCoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
