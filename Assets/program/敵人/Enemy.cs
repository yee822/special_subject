using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage;
    public float flashTime;
    public GameObject Emeny;
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(Emeny, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerHealth>().PlayerDamage(damage);
        }
    }


}
