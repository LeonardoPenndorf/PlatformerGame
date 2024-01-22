using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource music;
    public bool mutedMusic = false, mutedSfx = false;
    public Button musicButton, sfxButton, musicButtonPauseMenu, sfxButtonPauseMenu;
    public Color greyedOut;

    // Start is called before the first frame update
    public void muteUnmuteMusic()
    {
        music.mute = !mutedMusic;
        mutedMusic = !mutedMusic;

        if(mutedMusic)
        {
            musicButton.image.color = greyedOut;
            musicButtonPauseMenu.image.color = greyedOut;

        }
        else
        {
            musicButton.image.color = Color.white;
            musicButtonPauseMenu.image.color = Color.white;
        }
    }

    public void muteUnmuteSfx()
    {
        foreach(AudioSource As in sfx)
        {
            As.mute = !mutedSfx;
        }
        mutedSfx = !mutedSfx;

        if (mutedSfx)
        {
            sfxButton.image.color = greyedOut;
            sfxButtonPauseMenu.image.color = greyedOut;
        }
        else
        {
            sfxButton.image.color = Color.white;
            sfxButtonPauseMenu.image.color = Color.white;

        }
    }

    public void playSound(AudioSource source)
    {
        source.Play();
    }
}
