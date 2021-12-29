using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public Inventory MyBag;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public GameObject slotGrid;
    public Image AllImage;
    public Sprite bag;
    public Sprite column;
    public RectTransform size;
    public List<GameObject> slot = new List<GameObject>();
    public bool isColumn;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void Update()
    {
        IsColumn();
        SpriteChange();


    }

    private void OnEnable()
    {
        RefreshItem();
    }
    //public static void CreateNewItem(Item item)
    //{
    //    Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //    newItem.slotItem = item;
    //    newItem.slotImage.sprite = item.ItemImage;
    //    newItem.slotNum.text = item.itemHeld.ToString();
    //}
    public static void RefreshItem()
    {
        
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slot.Clear();
        }
        
        
            for (int i = 0; i < instance.MyBag.itemList.Count; i++)
            {
                //CreateNewItem(instance.MyBag.itemList[i]);
                instance.slot.Add(Instantiate(instance.emptySlot));
                instance.slot[i].transform.SetParent(instance.slotGrid.transform);
                instance.slot[i].GetComponent<Slot>().SetupSlot(instance.MyBag.itemList[i]);
                instance.slot[i].GetComponent<Slot>().slotID = i;
            }
        
       
        if (instance.isColumn)
        {
            for (int i = 4; i < instance.MyBag.itemList.Count; i++)
            {
                instance.slot[i].SetActive(false);

            }
        }
    }
    public void IsColumn()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            isColumn = !isColumn;
            RefreshItem();
        }
    }
    public void SpriteChange()
    {

        if (!isColumn)
        {
            AllImage.sprite = bag;
           
        }
        else
        {
            AllImage.sprite = column;
        }
       
    }
   
}
