using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int health, healthMax, blink, bankTotal, scene,wait;
    public float time, dieTime,hurtClease;

    public HealthItem healthItem;
    public MoneyItem moneyItem;

    private Renderer myRenderer;
    private Animator anim;
    private Rigidbody2D rb2D;
    public bool isHurt = false, isEnough=false;
    public GameObject healthOne, healthTwo, healthThree,healthFour;





    void Start()
    {
        HealthBar.healthCurrent = healthItem.healthItem;
        HealthBar.healthMax = healthItem.healthMaxItem;
        //HealthBar.healthCurrent = health;
        //HealthBar.healthMax = healthMax;
        myRenderer = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void Update()
    {
        AddBloodMax();
    }
    private void LateUpdate()
    {
        isEnough = false;
    }


    public void PlayerDamage(int damage)
    {
        healthItem.healthItem += damage;
        //health += damage;
        isHurt = true;
        Debug.Log("開啟");

        FlashScreen();
        /*if(health <= 0)
        {
            health = 0;
        }*/
        HealthBar.healthCurrent = healthItem.healthItem;
        //HealthBar.healthCurrent = health;
        //healthItem.healthItem = HealthBar.healthCurrent;

        if (healthItem.healthItem >= HealthBar.healthMax)
        {
            rb2D.velocity = new Vector2(0, 0);
            rb2D.gravityScale = 0.0f;
            Invoke("KillPlayer", dieTime);
            HealthBar.healthCurrent = healthItem.healthItem;
            //HealthBar.healthCurrent = healthMax;
            //healthItem.healthMaxItem = HealthBar.healthCurrent;
        }

        Invoke("CleaseHurt", hurtClease);
        
        BlinkPlayer(blink, time);

    }
    void KillPlayer()
    {
        Invoke("Wiat", wait);
        //Destroy(gameObject);
        //health = 0;
        //MoneyNum.MoneyCurrent = 0;
        //HealthBar.healthCurrent = healthItem.healthItem;
        //HealthBar.healthCurrent = 0;
        //healthItem.healthItem = HealthBar.healthCurrent;
    }
    void Wiat()
    {
        //yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(scene);
        healthItem.healthItem = 0;
        moneyItem.moneyNum = 0;

        Debug.Log("嗨");
    }

    void CleaseHurt()
    {
        isHurt = false;
        Debug.Log("關閉");

    }
    void BlinkPlayer(int numBlinks,float seconds)//閃爍
    {
        StartCoroutine(DoBlinks( numBlinks, seconds));
    }
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0 ; i<numBlinks * 2;i++)
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }


    void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
       // anim.SetTrigger("PlayerFlash");
        yield return new WaitForSeconds(time);

    }

    void AddBloodMax()
    {
        if (BankDeposit.BankTotal < 200 && healthItem.healthMaxItem != 10)
        {
            healthOne.SetActive (true);
            healthTwo.SetActive(false);
            healthThree.SetActive(false);
            healthFour.SetActive(false);
            //healthMax = 10;
            healthItem.healthMaxItem = 10;

            HealthBar.healthMax = healthItem.healthMaxItem;
            Debug.Log("執行+10");
            //HealthBar.healthMax = healthMax;
            //healthItem.healthMaxItem = HealthBar.healthMax;


        }
        else if (BankDeposit.BankTotal >= 200 && BankDeposit.BankTotal < 500 && healthItem.healthMaxItem != 30)
        {
            healthOne.SetActive(false);
            healthTwo.SetActive(true);
            healthThree.SetActive(false);
            healthFour.SetActive(false);
            healthItem.healthMaxItem += 20;
            //healthMax += 20;
            HealthBar.healthMax = healthItem.healthMaxItem;
            Debug.Log("執行+30");
            //HealthBar.healthMax = healthMax; 
            //healthItem.healthMaxItem = HealthBar.healthMax;

        }
        else if (BankDeposit.BankTotal >= 500 && BankDeposit.BankTotal < 1000 && healthItem.healthMaxItem != 80)//此段還有問題
        {
            healthOne.SetActive(false);
            healthTwo.SetActive(false);
            healthThree.SetActive(true);
            healthFour.SetActive(false);
            healthItem.healthMaxItem += 50;

            //healthMax += 50;
            HealthBar.healthMax = healthItem.healthMaxItem;
            Debug.Log("執行+50");
            //HealthBar.healthMax = healthMax;
            //healthItem.healthMaxItem = HealthBar.healthMax;
        }
        else if (BankDeposit.BankTotal >= 1000 && healthItem.healthMaxItem != 150)
        {
            healthOne.SetActive(false);
            healthTwo.SetActive(false);
            healthThree.SetActive(false);
            healthFour.SetActive(true);
            healthItem.healthMaxItem += 70;
            Debug.Log("執行+70");
            //healthMax += 70;
            HealthBar.healthMax = healthItem.healthMaxItem;
            //HealthBar.healthMax = healthMax;
            //healthItem.healthMaxItem = HealthBar.healthMax;
        }
        else if(healthItem.healthMaxItem == 150)
        {
            healthOne.SetActive(false);
            healthTwo.SetActive(false);
            healthThree.SetActive(false);
            healthFour.SetActive(true);
            healthItem.healthMaxItem = 150;
            Debug.Log("max");
            HealthBar.healthMax = healthItem.healthMaxItem;
        }
    }
}

