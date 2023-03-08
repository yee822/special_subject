
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BankDeposit : MonoBehaviour
{
    public MoneyItem moneyItem;
    public GameObject computer,Buttom;

    public Text BankText;
    public Image one, five, ten;
    public int Zero, One, Five, Ten;
    public static int BankTotal, healthMax;
    public bool ChackClose=false, addOneChack=false;

    public int upOne, upTwo, upThree, upFour, upFive, upSix, upSeven, upEighe, upNine, upTen;
    public Image upOneImage, upTwoImage, upThreeImage, upFourImage, upFiveImage, upSixImage, upSevenImage, upEigheImage, upNineImage, upTenImage;
    public UpItem upOneItem, upTwoItem, upThreeItem, upFourItem, upFiveItem, upSixItem, upSevenItem, upEigheItem, upNineItem, upTenItem;
    private void Start()
    {
        //this.GetComponent<Image>().color=Color.white;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(Buttom);

        BankText.text = moneyItem.bankNum.ToString();
        BankTotal = moneyItem.bankNum;

        upOneImage.color = Color.black;
        upTwoImage.color = Color.black;
        upThreeImage.color = Color.black;
        upFourImage.color = Color.black;
        upFiveImage.color = Color.black;
        upSixImage.color = Color.black;
        upSevenImage.color = Color.black;
        upEigheImage.color = Color.black;
        upNineImage.color = Color.black;
        upTenImage.color = Color.black;
    }
    private void Update()
    {
        ButtomColor();
    }

    public void AddOne()
    {
        if (MoneyNum.MoneyCurrent>0)
        {
            BankTotal = BankTotal+ One;
            BankText.text = BankTotal.ToString();
            MoneyNum.MoneyCurrent = MoneyNum.MoneyCurrent - One;
            moneyItem.moneyNum -= One;
            moneyItem.bankNum += One;
            GameObject.Find("еDид").GetComponent<Compilation>().enabled = true;

        }
        else if(MoneyNum.MoneyCurrent==0)
        {
            BankTotal += 0;
            moneyItem.moneyNum += 0;
            moneyItem.bankNum += 0;

            BankText.text = BankTotal.ToString();
        }
    }
    public void AddFive()
    {
        if (MoneyNum.MoneyCurrent >= Five)
        {
            BankTotal = BankTotal + Five;
            BankText.text = BankTotal.ToString();
            MoneyNum.MoneyCurrent = MoneyNum.MoneyCurrent - Five;
            moneyItem.moneyNum -= Five;
            moneyItem.bankNum += Five;
        }
        else if (MoneyNum.MoneyCurrent < Five)
        {
            BankTotal += 0;
            moneyItem.moneyNum += 0;
            moneyItem.bankNum += 0;

            BankText.text = BankTotal.ToString();
        }
    }
    public void AddTen()
    {
        if (MoneyNum.MoneyCurrent >= Ten )
        {
            BankTotal = BankTotal + Ten;
            BankText.text = BankTotal.ToString();
            MoneyNum.MoneyCurrent = MoneyNum.MoneyCurrent - Ten;
            moneyItem.moneyNum -= Ten;
            moneyItem.bankNum += Ten;
        }
        else if (MoneyNum.MoneyCurrent < Ten)
        {
            BankTotal += 0;
            moneyItem.moneyNum += 0;
            moneyItem.bankNum += 0;

            BankText.text = BankTotal.ToString();
        }
    }
    void ButtomColor()
    {
        if(moneyItem.moneyNum == 0)
        {
            one.color = Color.black;
            five.color = Color.black;
            ten.color = Color.black;
        }
        else if(moneyItem.moneyNum>0&& moneyItem.moneyNum<Five)
        {
            one.color = Color.white;
            five.color = Color.black;
            ten.color = Color.black;

        }
        else if (moneyItem.moneyNum > 0 && moneyItem.moneyNum < Ten)
        {
            one.color = Color.white;
            five.color = Color.white;
            ten.color = Color.black;

        }

        else if (moneyItem.moneyNum >=Ten)
        {
            one.color = Color.white;
            five.color = Color.white;
            ten.color = Color.white;
        }

    }
    public void UpOne()
    {
        if (BankTotal >= upOne)
        {
            BankTotal -= upOne;
            moneyItem.bankNum -= upOne;
            BankText.text = BankTotal.ToString();
            upOneImage.color = Color.white;
            upOneItem.UpCheck = true;
        }
    }
    public void UpTwo()
    {
        if (BankTotal >= upTwo &&  upOneItem.UpCheck == true)
        {
            BankTotal -= upTwo;
            moneyItem.bankNum -= upTwo;
            BankText.text = BankTotal.ToString();
            upTwoImage.color = Color.white;
            upTwoItem.UpCheck = true;
        }
    }
    public void UpThree()
    {
        if (BankTotal >= upThree && upOneItem.UpCheck == true)
        {
            BankTotal -= upThree;
            moneyItem.bankNum -= upThree;
            BankText.text = BankTotal.ToString();
            upThreeImage.color = Color.white;
            upThreeItem.UpCheck = true;
        }
    }
    public void UpFour()
    {
        if (BankTotal >= upFour && upTwoItem.UpCheck == true && upThreeItem.UpCheck == true)
        {
            BankTotal -= upFour;
            moneyItem.bankNum -= upFour;
            BankText.text = BankTotal.ToString();
            upFourImage.color = Color.white;
            upFourItem.UpCheck = true;
        }
    }
    public void UpFive()
    {
        if (BankTotal >= upFive && upTwoItem.UpCheck == true && upThreeItem.UpCheck == true)
        {
            BankTotal -= upFive;
            moneyItem.bankNum -= upFive;
            BankText.text = BankTotal.ToString();
            upFiveImage.color = Color.white;
            upFiveItem.UpCheck = true;
        }
    }
    public void UpSix()
    {
        if (BankTotal >= upSix && upTwoItem.UpCheck == true && upThreeItem.UpCheck == true)
        {
            BankTotal -= upSix;
            moneyItem.bankNum -= upSix;
            BankText.text = BankTotal.ToString();
            upSixImage.color = Color.white;
            upSixItem.UpCheck = true;
        }
    }
    public void UpSeven()
    {
        if (BankTotal >= upSeven && upFourItem.UpCheck == true && upFiveItem.UpCheck == true&& upSixItem.UpCheck == true)
        {
            BankTotal -= upSeven;
            moneyItem.bankNum -= upSeven;
            BankText.text = BankTotal.ToString();
            upSevenImage.color = Color.white;
            upSevenItem.UpCheck = true;
        }
    }
    public void UpEighe()
    {
        if (BankTotal >= upEighe && upFourItem.UpCheck == true && upFiveItem.UpCheck == true && upSixItem.UpCheck == true)
        {
            BankTotal -= upEighe;
            moneyItem.bankNum -= upEighe;
            BankText.text = BankTotal.ToString();
            upEigheImage.color = Color.white;
            upEigheItem.UpCheck = true;
        }
    }
    public void UpNine()
    {
        if (BankTotal >= upNine && upFourItem.UpCheck == true && upFiveItem.UpCheck == true && upSixItem.UpCheck == true)
        {
            BankTotal -= upNine;
            moneyItem.bankNum -= upNine;
            BankText.text = BankTotal.ToString();
            upNineImage.color = Color.white;
            upNineItem.UpCheck = true;
        }
    }
    public void UpTen()
    {
        if (BankTotal >= upTen && upFourItem.UpCheck == true && upFiveItem.UpCheck == true && upSixItem.UpCheck == true)
        {
            BankTotal -= upTen;
            moneyItem.bankNum -= upTen;
            BankText.text = BankTotal.ToString();
            upTenImage.color = Color.white;
            upTenItem.UpCheck = true;
        }
    }
    public void CloseUI()
    {
        computer.SetActive(false);
        GameObject.Find("еDид").GetComponent<Compilation>().enabled = true;
        Debug.Log("close");
    }

}
