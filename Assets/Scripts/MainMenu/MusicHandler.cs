using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicHandler : MonoBehaviour {

    private bool _musicEnabled = true;
    public Sprite MusicOff;
    public Sprite MusicOn;
    public AudioSource AudioHandler;
    public Image MusicImage;


    public void MusicToggler()
    {
        if (_musicEnabled)
        {
            MusicImage.sprite = MusicOff;
            AudioHandler.Pause();
            _musicEnabled = false;
            return;
        }
        MusicImage.sprite = MusicOn;
        AudioHandler.Play();
        _musicEnabled = true;
    }
}
