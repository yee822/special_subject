using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 取得道具 : MonoBehaviour
{
    public Item thisitem;
    public Inventory showcase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            AddNewItem();
        }
    }
    public void AddNewItem()
    {
        if (!showcase.itemList.Contains(thisitem))
        {
            showcase.itemList.Add(thisitem);
            InventoryManager.CreateNewItem(thisitem);
            thisitem.itemcount = 1;
        }
        else
        {
            thisitem.itemcount += 1;
        }
        InventoryManager.RefreshItem();
    }
}
