using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "UI/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemcount;
    [TextArea]
    public string itemInfo;
    public bool isEquip;
}
