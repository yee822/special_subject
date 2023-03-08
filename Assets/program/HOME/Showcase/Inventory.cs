using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "UI/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
    public List<MoneyItem> moneyList = new List<MoneyItem>();
    public List<UpItem> upList = new List<UpItem>();
    public List<HealthItem> healtList = new List<HealthItem>();
}
