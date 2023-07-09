using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    float audioVolume = 0.5f;
    [SerializeField] AudioMixer myAudioMixer;
    [SerializeField] TMP_Text volumeText;


    public void SetVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("MasterVolume", Mathf.Clamp(Mathf.Log10(sliderValue) * 20, 0.0001f, 1f));
        myAudioMixer.GetFloat("MasterVolume", out audioVolume);
        volumeText.text = "Volume: " + Mathf.RoundToInt(sliderValue * 100) + "%";
        Debug.Log(sliderValue);
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            SetVolume(audioVolume -= 0.01f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetVolume(audioVolume += 0.01f);
        }
    }
}
