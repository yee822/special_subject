using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New UpItem", menuName = "UI/New UpItem")]
public class UpItem : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    [TextArea]
    public string itemInfo;
    public bool UpCheck;
}
