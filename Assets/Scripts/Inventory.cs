using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "New Inventory")]
public class Inventory : ScriptableObject
{
   public List<Item> itemList = new List<Item>();
    
}
