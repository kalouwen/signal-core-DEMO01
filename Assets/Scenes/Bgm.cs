using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
  

    public AudioSource audioSource;

    //��ʼ��ֹͣ����
    public void Update()
    {
        play_stop_music();
    }
    public void play_stop_music()
    {
       
        
            audioSource.Play();
      
    }

    //��ͣ����
    public void pause_music()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    //�ı�����
    public void change_volume(float volume)
    {
        audioSource.volume = volume;
    }

}

