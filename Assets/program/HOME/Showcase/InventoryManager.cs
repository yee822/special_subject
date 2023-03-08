using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory showcase;
    public GameObject SlotGird;
    public Slot slotprefebsl;
    public Text itemTextInfo;

    public static InventoryManager _instance;
    private void Awake()
    {
        _instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        _instance.itemTextInfo.text = "";
    }


    public static void CreateNewItem(Item item)
    {
        Slot newitem = Instantiate(_instance.slotprefebsl, _instance.SlotGird.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(_instance.SlotGird.transform);
        newitem.slotItem = item;
        newitem.SlotImage.sprite = item.itemSprite;
        newitem.SlotCount.text = item.itemcount.ToString();
    }
    public static void RefreshItem()
    {

        for (int i = 0; i < _instance.SlotGird.transform.childCount; i++)
        {
            if (_instance.SlotGird.transform.childCount == 0)
            {
                break;
            }
            Destroy(_instance.SlotGird.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < _instance.showcase.itemList.Count; i++)
        {
            CreateNewItem(_instance.showcase.itemList[i]);
        }
    }
    public static void UpdateInfo(string Description)
    {
        _instance.itemTextInfo.text = Description;
    }
}
