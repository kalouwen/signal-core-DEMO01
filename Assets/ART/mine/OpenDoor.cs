using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;
    public AudioClip kill;

    public AudioSource music;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("123");

        if (other.tag == "Player")
        {
            music.clip = kill;
            music.Play();
            anim.SetBool("open", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
           
            anim.SetBool("open", false);
        }
    }
}
