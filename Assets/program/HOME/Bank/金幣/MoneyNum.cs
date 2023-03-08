using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyNum : MonoBehaviour
{
    public MoneyItem moneyItem;
    public Text MoneyText;
    public static int MoneyCurrent;


    // Start is called before the first frame update
    void Start()
    {
        MoneyCurrent = moneyItem.moneyNum;
        MoneyText.text = moneyItem.moneyNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = MoneyCurrent.ToString();
    }

}
