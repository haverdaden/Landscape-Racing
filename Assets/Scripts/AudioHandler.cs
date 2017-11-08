using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{

    private AudioSource[] GameAudio;
    private AudioSource MusicAudio;
    public Slider MusicSlider;
    public Slider GameSlider;

	// Use this for initialization
	void Start ()
    {
        SetStartVolumes();
    }

    private void SetStartVolumes()
    {
        //FIND ALL THE SCENE AUDIO
        GameAudio = FindObjectsOfType<AudioSource>();

        //FIND THE MUSIC AUDIO
        MusicAudio = GameObject.FindWithTag("Levelmusic").GetComponent<AudioSource>();
        
            MusicSlider.value = PlayerValues.Player.musicVolume;
            GameSlider.value = PlayerValues.Player.gameVolume;

            foreach (var audio in GameAudio)
            {
                if (audio != MusicAudio)
                {
                    audio.volume = GameSlider.value;
                }

            }

            MusicAudio.volume = PlayerValues.Player.musicVolume;
        }
    

    public void ChangeGameVolume(float volume)
    {
        foreach (var audio in GameAudio)
        {
            if (audio.gameObject.name != MusicAudio.gameObject.name)
            {
                    audio.volume = volume;
                    PlayerValues.Player.gameVolume = volume;
            }

        }
    }
    public void ChangeMusicVolume(float volume)
    {
        if (MusicAudio)
        {
            MusicAudio.volume = volume;
            PlayerValues.Player.musicVolume = volume;
           // SaveSystem.Save();
        }
    }
	
    
}
