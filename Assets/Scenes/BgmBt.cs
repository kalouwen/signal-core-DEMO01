using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmBt : MonoBehaviour
{
 

    public AudioSource audioSource;

    //开始、停止播放
    public void play_stop_music()
    {
        Debug.Log("s");
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    //暂停播放
    public void pause_music()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    //改变音量
    public void change_volume(float volume)
    {
        audioSource.volume = volume;
    }

}

