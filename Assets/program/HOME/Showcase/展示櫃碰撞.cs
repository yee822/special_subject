using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class 展示櫃碰撞 : MonoBehaviour
{
    public GameObject showcase;
    public BoxCollider2D box2D;
    private bool isShowcase = false;
    //public GameObject puseFirstButton, potionsClosedButton;


    private void Start()
    {
        showcase.SetActive(false);
        box2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.A) && isShowcase == true)
            {
                showcase.SetActive(false);
                isShowcase = false;
                Debug.Log("關閉");
                //GameObject.Find("主角").GetComponent<PlayerWalk>().enabled = true;
                //EventSystem.current.SetSelectedGameObject(null);
                //EventSystem.current.SetSelectedGameObject(puseFirstButton);

            }
            else if (Input.GetKeyDown(KeyCode.A) && isShowcase == false)
            {
                showcase.SetActive(true);
                isShowcase = true;
                Debug.Log("開啟");
                //GameObject.Find("主角").GetComponent<PlayerWalk>().enabled = false;
                //EventSystem.current.SetSelectedGameObject(null);
                //EventSystem.current.SetSelectedGameObject(potionsClosedButton);

            }
        }
    }
}


