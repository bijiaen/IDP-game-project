using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeTextElement;

    void Start()
    {
        LoadValues();
    }
    public void VolumeSlider(float vol)
    {
        volumeTextElement.text = vol.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volumeValue", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue", 0.7f);
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
