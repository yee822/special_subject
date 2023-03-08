using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 皮帶 : MonoBehaviour
{
    public int damage;
    public float time, startTime;

    private Animator anim;
    private PolygonCollider2D pol2D;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();

        pol2D = GetComponent<PolygonCollider2D>();

    }
    private void LateUpdate()
    {
        Attacking();

    }
    void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            StartCoroutine(StarAttack());
        }
    }
    IEnumerator StarAttack()
    {
        yield return new WaitForSeconds(startTime);
        pol2D.enabled = true;
        StartCoroutine(dissHitBox());
        //anim.GetBool("C");
    }
    IEnumerator dissHitBox()
    {
        yield return new WaitForSeconds(time);
        pol2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
