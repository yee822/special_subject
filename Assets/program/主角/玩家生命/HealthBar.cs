using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public static int healthMax, healthCurrent;
    public HealthItem healthItem;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        //healthCurrent = healthMax;
    }


    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)healthItem.healthItem/(float)healthItem.healthMaxItem;
        healthText.text = healthItem.healthItem.ToString() +'/'+healthItem.healthMaxItem.ToString();
    }
}
