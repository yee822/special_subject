using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Health", menuName = "UI/New Health")]
public class HealthItem : ScriptableObject
{
    public int healthMaxItem,healthItem;
}
