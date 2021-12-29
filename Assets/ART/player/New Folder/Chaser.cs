using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Animator anim;
    public float NeedTime;
    public AudioSource music;
    public AudioClip kill;
    // Update is called once per frame
    void Update()
    {
        NeedTime += Time.deltaTime;
        if(NeedTime >= 15)
        {
            StartCoroutine(Play());
           
        }
    }
    IEnumerator Play()
    {
        music.clip = kill;
        music.Play();
        anim.SetBool("Play", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Play", false);
        NeedTime = 0f;
       
    }
}
