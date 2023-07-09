using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    bool isMuted = false;

    
    public GameObject muteObject;
    public GameObject unmuteObject;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.M)) MuteOrUnmute();
    }

    private void MuteOrUnmute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;

        switch (isMuted)
        {
            case true:
                muteObject.SetActive(true);
                unmuteObject.SetActive(false);

                break;
            case false:
                muteObject.SetActive(false);
                unmuteObject.SetActive(true);

                break;
        }
    }
}
