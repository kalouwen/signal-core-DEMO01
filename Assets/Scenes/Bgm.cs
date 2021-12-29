using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
  

    public AudioSource audioSource;

    //开始、停止播放
    public void Update()
    {
        play_stop_music();
    }
    public void play_stop_music()
    {
       
        
            audioSource.Play();
      
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

