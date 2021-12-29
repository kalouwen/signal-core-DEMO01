using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="New Prefeb")]
public class Item :ScriptableObject
{
    public string itemName;
    public Sprite ItemImage;
    public int itemHeld;
}
