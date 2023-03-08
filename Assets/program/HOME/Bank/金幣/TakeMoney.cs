using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TakeMoney : MonoBehaviour
{
    public HealthItem healthItem;
    public int moneySc;
    public MoneyItem moneyItem;


    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            MoneyNum.MoneyCurrent = MoneyNum.MoneyCurrent + moneySc;
            moneyItem.moneyNum += moneySc;

            Destroy(gameObject);
        }
    }


}
