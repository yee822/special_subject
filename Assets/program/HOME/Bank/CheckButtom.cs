using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButtom : MonoBehaviour
{
    public Text buttomText,BankText;
    public int addBank,totalBank,ToBank;
    public void RightBank()
    {
        
        if (addBank<MoneyNum.MoneyCurrent)
        {
            totalBank = totalBank + addBank;
            buttomText.text = totalBank.ToString();
        }
        if(addBank>MoneyNum.MoneyCurrent)
        {
            ToBank = MoneyNum.MoneyCurrent;
            totalBank = totalBank + ToBank;
            buttomText.text = MoneyNum.MoneyCurrent.ToString();
        }
    }
    public void LiftBank()
    {
        if (totalBank > 0)
        {
            buttomText.text = totalBank.ToString();
        }
        else if (totalBank < 0)
        {
            buttomText.text = 0.ToString();
        }
    }
    public void ConfirmStorage()
    {
        BankText.text = buttomText.text;
        buttomText.text = 0.ToString();
        MoneyNum.MoneyCurrent = MoneyNum.MoneyCurrent - totalBank;
        totalBank = 0;
    }
}
