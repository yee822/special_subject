using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "UI/New Money")]

public class MoneyItem : ScriptableObject
{
    public int moneyNum, bankNum;
}
