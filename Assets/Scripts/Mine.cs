using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    
    private Rigidbody2D rb;
    public bool isMine;
    public Animator anim;
    public AudioSource music;
    public AudioClip mine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
      
    }

   
    
    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
           
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
            if (other.tag == "gun")
            {
              
                AddNewItem();
                anim.SetBool("break", true);
                Destroy(gameObject, 1.9f);
                music.clip = mine;
                music.Play();
            }

        
    }
}
