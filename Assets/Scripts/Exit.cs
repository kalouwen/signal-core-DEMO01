using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public AudioSource music;
    public AudioClip kill;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            music.clip = kill;
            music.Play();
            Debug.Log("111");
            SceneManager.LoadScene("Ship");
        }
    }

}
