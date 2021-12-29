using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject lazer;
    private Rigidbody2D rb;
    private float moveH, moveV;
    public Animator anim;
    public bool isAttack;
    public GameObject gun;
    [SerializeField] private float moveSpeed;
    public AudioSource music;
    public AudioClip kill;
    public void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    if (instance != this)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") ;
        moveV = Input.GetAxisRaw("Vertical") ;
        rb.velocity = new Vector2(moveH * moveSpeed, moveV * moveSpeed/2) ;
        anim.SetFloat("run", Mathf.Abs(rb.velocity.x));
        if (moveH != 0)
        {
            transform.localScale = new Vector3(-moveH, 1, 1);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttack = !isAttack;
            if (isAttack)
            {
                gun.SetActive(true);
                lazer.SetActive(true);
                music.clip = kill;
                music.Play();
                
                
            }
            else
            {
                gun.SetActive(false);
                lazer.SetActive(false);
                music.clip = kill;
                music.Stop();
                
                
            }
            
        }
       



    }

}
