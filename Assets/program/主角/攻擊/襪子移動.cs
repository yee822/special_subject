using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 襪子移動 : MonoBehaviour
{
    public int damage;
    public float time, startTime;

    private PolygonCollider2D pol2D;
    public float destroyDistance;
    public float speed;
    public Rigidbody2D rb2D;
    private Vector3 startPos;

    void Start()
    {
        pol2D = GetComponent<PolygonCollider2D>();
        MoveTransform();
        startPos = transform.position;
    }
    private void LateUpdate()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance> destroyDistance)
        {
            Destroy(gameObject);
        }
        Attacking();
    }
    void MoveTransform()
    {

        float facedircetion = Input.GetAxisRaw("Horizontal");
        if (facedircetion != 0)
        {
            transform.localScale = new Vector3(facedircetion, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Attacking();
            if (facedircetion != 1)
            {
                rb2D.velocity = Vector2.left * speed;
                transform.Rotate(0f, 180f, 0f);
            }
            if(facedircetion != -1)
            {
                rb2D.velocity = Vector2.right * speed;
                transform.Rotate(0f, -180f, 0f);

            }
        }
    }
    void Attacking()
    {
         

             StartCoroutine(StarAttack());
        
    }
    IEnumerator StarAttack()
    {
         yield return new WaitForSeconds(startTime);
         pol2D.enabled = true;
         StartCoroutine(dissHitBox());
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
