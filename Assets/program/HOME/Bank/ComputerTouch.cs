using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComputerTouch : MonoBehaviour
{
    public bool chickTouch;
    public GameObject computer,chackKeyAImage;
    private BankDeposit bankDeposit;

    private void Update()
    {
        OpenUI();

    }
    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            if (computer.activeInHierarchy)
            {
                chickTouch = false;
            }
            else if (!computer.activeInHierarchy)
            {
                chickTouch = true;
            }
            chackKeyAImage.SetActive (true);
        }
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            computer.SetActive(false);
            chackKeyAImage.SetActive(false);
            chickTouch = false;
        }
    }

    void OpenUI()
    {
        if (chickTouch == true && Input.GetKeyDown(KeyCode.A) )
        {
            computer.SetActive(true);
            Debug.Log("open");
            GameObject.Find("еDид").GetComponent<Compilation>().enabled = false;


        }
    }
    public void CloseUI()
    {
        if (chickTouch == false)
        {
            computer.SetActive(false);
            GameObject.Find("еDид").GetComponent<Compilation>().enabled = true;
        }
    }
}
