using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text totalCoinsTextElement;
    private int tCoin;


    // Start is called before the first frame update
    void Start()
    {
        tCoin = PlayerPrefs.GetInt("totalcoins", 0);
        totalCoinsTextElement.text = tCoin.ToString();
    }

}
