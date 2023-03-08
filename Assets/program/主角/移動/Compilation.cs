using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compilation : MonoBehaviour
{
    //����
    public Rigidbody2D rb;
    public float speed;
    private float moveInput;//jump�]���ϥ�
    public bool moveChack;

    //���D
    public float junpspeed, checkRadius, jumpForce, jumpTime;
    private float jumpTimeCounter;
    private bool isGrounded, isJumping;
    public Transform feetPos;
    public LayerMask whatIsGround;

    //�Ĩ�
    public float dashTime, dashTimeLeft, dashCD, dashSpeed;
    private float lastDash = -10;
    private int dashDirection;
    private bool isDashing;

    //���ˤϼu
    public float reboundSpeed, reboundTime;
    private PlayerHealth playerHealth;

    //�ʵe
    private Animator myAni;

    //����
    public ���� attack;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Dash();
    }
    void Update()
    {
         Move();
         Jump();
        Dashing();
        MusicTotul();
        //ReadyRebound();
    }
    void PlayerFace()
    {   float facedircetion = Input.GetAxisRaw("Horizontal");
        if (facedircetion != 0)
        {
            transform.localScale = new Vector3(facedircetion, 1, 1);
        }
    }

    public void Move()//����
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            /*moveChack = true;

            if (moveChack == true && isJumping == false)
            {
                //myAni.SetFloat("MoveChack", Mathf.Abs(horizontalmove));
                //SoundManger.soundIndtance.MoveAudio();
            }*/
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                myAni.SetTrigger("Move");
                SoundManger.soundIndtance.MoveAudio();
            }
            else
            {
                myAni.SetTrigger("Idle");
            }
        }




    }
    
    public void Return()//½��(�ثe���ϥ�)
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Z))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            moveChack = false;
            SoundManger.soundIndtance.JumpAudio();
            //StopCoroutine("SoundManger.soundIndtance.MoveAudio()");
        }
        if (Input.GetKey(KeyCode.Z) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                //myAni.SetBool("Jump", true);


            }
            else
            {
                isJumping = false;
                //myAni.SetBool("Jump", false);
                            }

        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
            //myAni.SetBool("Jump", true);


        }
        else
        {
            //myAni.SetBool("Jump", false);
        }
    }//���D
    void ReadyDash()//�ǳƽĨ�1
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        dashDirection = 0;
    }
    void Dash()//�Ĩ����
    {
        StopCoroutine("Move");
        StopCoroutine("Jump");

        PlayerFace();

        if (dashDirection == 0)
        {
            if (transform.localScale.x == -1)
            {
                dashDirection = 1;
            }
            if (transform.localScale.x == 1)
            {
                dashDirection = 2;
            }
        }
        else
        {
            if (dashTimeLeft > 0)
            {
                if (isDashing)
                {
                    StopCoroutine("Move");
                    StopCoroutine("Jump");

                    dashTimeLeft -= Time.deltaTime;
                    //ShadowPool.instance.GetFormPool();
                    if (dashDirection == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (dashDirection == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }
                }

            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                dashDirection = 0;
                dashTimeLeft = dashTime;
                rb.velocity = Vector2.zero;
            }
        }
    }
    void Dashing()//�ǳƽĨ�2
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Time.time >= (lastDash + dashCD))
            {
                SoundManger.soundIndtance.DashAudio();
                //StopCoroutine("SoundManger.soundIndtance.MoveAudio()");
                ReadyDash();
            }
        }
    }
    void OnTriggerStay2D(Collider2D Enemy)//�IĲ�Ǫ���h
    {
        if (playerHealth.isHurt == true)
        {
            if (Enemy.gameObject.tag == "Enemy")
            {
                GameObject.Find("�D��").GetComponent<Compilation>().enabled = false;

                if (isGrounded == false)
                {
                    if (transform.position.x < Enemy.transform.position.x)
                    {
                        rb.velocity = new Vector2(-reboundSpeed, jumpForce);
                        Debug.Log("111");
                    }
                    else if (transform.position.x > Enemy.transform.position.x)
                    {
                        rb.velocity = new Vector2(reboundSpeed, jumpForce);
                        Debug.Log("222");

                    }

                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
                else if (transform.position.x < Enemy.transform.position.x)
                {
                    rb.velocity = new Vector2(-reboundSpeed, rb.velocity.y);
                    Debug.Log("11");
                }
                else if (transform.position.x > Enemy.transform.position.x)
                {
                    rb.velocity = new Vector2(reboundSpeed, rb.velocity.y);
                    Debug.Log("22");
                }
                Invoke("OpenCompilation", reboundTime);
            }
        }


    }
    void OpenCompilation()//�IĲ�Ǫ���h2
    {
        if (playerHealth.isHurt == false)
        {
            GameObject.Find("�D��").GetComponent<Compilation>().enabled = true;
        }
    }
    void MusicTotul()
    {
        //MoveMusic();
        AttackMusic();
       //StartCoroutine("MoveSound()");
    }

    IEnumerator MoveSound()
    {
        if(moveChack == true && (isJumping==false||isDashing==false||attack.AttackCheck==false))
        SoundManger.soundIndtance.MoveAudio();
        yield break;
        //Debug.Log("�ڼ�����");
    }
    void MoveMusic()
    {
        if(moveChack==true&&(isJumping == false || isDashing == false || attack.AttackCheck == false))
        {
            SoundManger.soundIndtance.MoveAudio();
            //yield WaitForSeconds(MoveAudio.length);
            Debug.Log("�ڼ�����");
        }

    }

    void AttackMusic()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SoundManger.soundIndtance.AttackAudio();
            Debug.Log("�ڼ�����");
        }
    }
}
