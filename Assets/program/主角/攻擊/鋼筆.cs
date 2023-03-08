using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ¿ûµ§ : MonoBehaviour
{
    public int danage;
    public float time,startTime;
    public PolygonCollider2D pol2D;
    public bool AttackCheck;



    // Start is called before the first frame update
    void Start()
    {
        //notAttack = true;
        pol2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame

    void Update()
    {
        Attacking();
    }

     void Attacking()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            //SoundManger.soundIndtance.AttackAudio();
            StartCoroutine(StarAttack());
        }
    }
    public IEnumerator StarAttack()
    {
        yield return new WaitForSeconds(startTime);
        
        pol2D.enabled = true;
        AttackCheck = true;
        StartCoroutine(dissHitBox());
    }
    IEnumerator dissHitBox()
    {
        yield return new WaitForSeconds(time);

        AttackCheck = false;
        pol2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.gameObject.tag == "Enemy")
        {
            Enemy.GetComponent<Enemy>().TakeDamage(danage);
        }
    }
}
