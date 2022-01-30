using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    public void Clear()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");

    }
}
