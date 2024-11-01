using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAudio : MonoBehaviour
{
    public static GlobalAudio instance;
    public AudioClip WhooshPages;
    public AudioClip clickSound;
    public AudioClip OpenWindow;
    public AudioClip CloseWindow;
    public AudioClip soundPurchase;
    public Slider volume;
    public AudioSource audioMusic;
    public AudioSource audioSound;

    void Awake()
    {
        instance = this;
    }

    //Apply volume audio source of all sounds and music with slider volume value
    //------------------------------------------------------------------------
    void Start()
    {
        audioMusic.volume = volume.value;
        audioSound.volume = volume.value;
    }

    //Function when change volume slider option
    //------------------------------------------------------------------------
    public void volumeChange()
    {
        audioMusic.volume = volume.value;
        audioSound.volume = volume.value;
    }

    //Function onclick button On/Off in option for sound
    //------------------------------------------------------------------------
    public void SoundChange(bool stat)
    {
        audioSound.enabled = stat;
    }

    //Function onclick button On/Off in option for music
    //------------------------------------------------------------------------
    public void MusicChange(bool stat)
    {
        audioMusic.enabled = stat;
    }

    //Play the sound when the switch pages
    //------------------------------------------------------------------------
    public void PlayWhooshPages()
    {
        audioSound.PlayOneShot(WhooshPages);
    }

    //Play the sound when the clicking button
    //------------------------------------------------------------------------
    public void PlaySoundClick()
    {
        audioSound.PlayOneShot(clickSound);
    }

    //Play the sound when the opening window shop or team
    //------------------------------------------------------------------------
    public void PlayOpenWindow()
    {
        audioSound.PlayOneShot(OpenWindow);
    }

    //Play the sound when the close window shop or team
    //------------------------------------------------------------------------
    public void PlayCloseWindow()
    {
        audioSound.PlayOneShot(CloseWindow);
    }

    //Play the sound when the purchase in shop and is playing sound, sound music is 0
    //------------------------------------------------------------------------
    public void PlayPurchase()
    {
        if (audioSound.isActiveAndEnabled)
        {
            audioMusic.volume = 0;
        }
        audioSound.PlayOneShot(soundPurchase);
    }

    //Reset the sound volume music after the end of sound purchased
    //------------------------------------------------------------------------
    public void resetAudioMusic()
    {
        audioMusic.volume = volume.value;
    }
}
