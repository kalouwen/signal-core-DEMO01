using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmBt : MonoBehaviour
{
 

    public AudioSource audioSource;

    //��ʼ��ֹͣ����
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

