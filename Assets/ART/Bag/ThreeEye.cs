using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeEye : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Animator anim;//WALK & ATTACK Animation
    private Transform target;
    private SpriteRenderer sp;
    private Material defaultMat;
    [SerializeField] private Material hurtMat;
    [SerializeField] private GameObject fireExplosion;
    public Transform fireExplosionTrans;
    public Collider2D playerDetected;
    public int face = -1;
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public float FindRadius;
    [SerializeField] public Transform attackPos;
    //MARKER If you want to save your enemy status by Serialization
    public bool isDead;
    [HideInInspector]
    public float batPositionX, batPositionY;
    public AudioSource music;
    public AudioClip kill;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        defaultMat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        batPositionX = transform.position.x;
        batPositionY = transform.position.y;
        UpdateDirection();
        Detect();
        if (!isDead&&playerDetected!=null)
        {
            //MARKER MoveTowards to the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            Debug.Log("111");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "gun" )
        {
            StartCoroutine(HurtEffect());
        }
    }

    IEnumerator HurtEffect()
    {
        Debug.Log("111");
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(0.2f);
        Destroy();
    }

    //MARKER ATTACH to the last frame on the Death Animation
    public void Destroy()
    {
     
        Destroy(gameObject,1f);
        music.clip = kill;
        music.Play();
    }
    public virtual void Detect()
    {
       
        playerDetected = Physics2D.OverlapCircle((Vector2)transform.position, FindRadius, playerLayer);
    }
    public void UpdateDirection()
    {
        if (playerDetected != null)
        {
            int direction;
            if (playerDetected.transform.position.x < transform.position.x)
            {
                direction = 1;//����ڵ��˵����
            }
            else
            {
                direction = -1;//����ڵ��˵��ұ�
            }
            if (direction != face)//��ʾ����һ��
            {
                //Debug.Log(direction);
                Flip();
            }
        }
    }
    void Flip()//��ת��ɫ����
    {
        face = (face == 1) ? -1 : 1;
        transform.localScale = new Vector2(face * 1, 1);//��-1����Ϊ��ʼ���������ǳ�����ߵģ����ǳ�ʼ����ȴ��1�����෴��
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, FindRadius);
       
    }
}

