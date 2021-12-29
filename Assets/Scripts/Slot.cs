using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public GameObject itemInSlot;

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.ItemImage;
        slotNum.text = item.itemHeld.ToString();
    }
}
