using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{

    public Slot slot;
    public Inventory myBag;
    public Transform originalParent;
    private int currentItemID;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.position = eventData.position;
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject == null)
        {
            
            Destroy(transform.gameObject);
            slot.slotNum.text = (int.Parse(slot.slotNum.text) - 1).ToString();
            // 物品数量减一
            myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = null;
            //销毁背包列表中的物品
            //return;
            //if ((int.Parse(slot.slotNum.text) > 1))//如果物品数量大于一时
            //{
            //    Debug.Log("1111");
            //    slot.slotNum.text = (int.Parse(slot.slotNum.text) - 1).ToString();
            //    // 物品数量减一
            //    myBag.itemList[slot.slotID].itemHeld = int.Parse(slot.slotNum.text);
            //    //将减少后的值传递给背包列表中的值
            //}
            //else
            //{

            //    Destroy(transform.gameObject);
            //    myBag.itemList[slot.slotID] = null;//销毁背包列表中的物品
            //    return;
            //}
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Image")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            var temp = myBag.itemList[currentItemID];
            myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
            myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform  .position;
        myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemList[currentItemID];
        myBag.itemList[currentItemID] = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true; 
        
    }
     
    
}
