using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Button btnSoundOn;
    public Button btnSoundOff;
    public Button btnMusicOn;
    public Button btnMusicOff;

    //Sound On/Off
    //------------------------------------------------------------------------
    public void SoundOnOff()
    {
        if (!btnSoundOn.interactable)
        {
            GlobalAudio.instance.SoundChange(false);
            btnSoundOn.interactable = true;
            btnSoundOff.interactable = false;
        }
        else
        {
            GlobalAudio.instance.SoundChange(true);
            btnSoundOn.interactable = false;
            btnSoundOff.interactable = true;
        }
    }

    //Music On/Off
    //------------------------------------------------------------------------
    public void MusicOnOff()
    {
        if (!btnMusicOn.interactable)
        {
            GlobalAudio.instance.MusicChange(false);
            btnMusicOn.interactable = true;
            btnMusicOff.interactable = false;
        }
        else
        {
            GlobalAudio.instance.MusicChange(true);
            btnMusicOn.interactable = false;
            btnMusicOff.interactable = true;
        }
    }
}
