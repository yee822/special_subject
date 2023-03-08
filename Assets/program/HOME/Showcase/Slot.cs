using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image SlotImage;
    public Text SlotCount;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateInfo(slotItem.itemInfo);
    }
}
