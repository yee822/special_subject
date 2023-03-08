using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBlood : MonoBehaviour
{
    public HealthItem healthItem;
    public int normalAddBlood, IessthanAdd;
    public GameObject HealthUI;
    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            if (healthItem.healthItem >= normalAddBlood)
            {
                healthItem.healthItem -=normalAddBlood;
                Destroy(gameObject);
            }
            else if (healthItem.healthItem <= normalAddBlood && healthItem.healthItem != 0)
            {
                IessthanAdd = healthItem.healthItem;
                healthItem.healthItem -= IessthanAdd;
                Destroy(gameObject);
            }

            else if(healthItem.healthItem == 0)
            {
                Debug.Log("現在還不需要");
            }

        }
    }

}
