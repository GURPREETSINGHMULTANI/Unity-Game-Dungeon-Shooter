using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GothicVaniaFight : MonoBehaviour
{
    [SerializeField] int randomState;
    [SerializeField] GameObject player;
    Animator anim;


    [SerializeField] float timeBetweenShot;
    float totalTime;



    [SerializeField] float jumpForce;
    [SerializeField] float movementSpeed;


    [SerializeField] bool isGrounded;
    [SerializeField] float maxCloseUpDistance;

    [SerializeField] bool active;





    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetTrigger("hurt");


        if (active)
        {
            Vector3 deltaMovement = player.transform.position - transform.position;
            if (deltaMovement.x >= 0)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0f);
                }
            }
            if (deltaMovement.x < 0)
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0f);
                }
            }



            totalTime += Time.deltaTime;
            if (totalTime >= timeBetweenShot)
            {

                randomState = (int)Random.Range(1, 7);
                //1 = Punch
                //2 = Jump
                //3 = Kick
                //4 = CrouchKick
                //5 = FlyingKick
                //6 = Walk

               
                if (randomState != 6)
                {
                    anim.SetBool("walk", false);
                }




                if (randomState == 1)
                {
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 4)
                    {

                        anim.SetTrigger("punch");
                        totalTime = 0f;
                    }
                }
                if (randomState == 2)
                {
                    if (isGrounded)
                    {
                        anim.SetTrigger("jump");
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                        totalTime = 0f;
                    }
                }
                if (randomState == 3)
                {
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 4)
                    {

                        anim.SetTrigger("kick");
                        totalTime = 0f;
                    }
                }
                if (randomState == 4)
                {
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 4)
                    {

                        anim.SetTrigger("crouchKick");
                        totalTime = 0f;
                    }
                }
                if (randomState == 5)
                {
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) <= 15 && Mathf.Abs(player.transform.position.x - transform.position.x) > 1.5f)
                    {
                        anim.SetTrigger("flyingKick");
                        totalTime = 0f;
                    }
                }
                if (randomState == 6)
                {
                    if (Mathf.Abs(transform.position.x - player.transform.position.x) > maxCloseUpDistance)
                    {
                        anim.SetBool("walk", true);
                        totalTime = 0f;
                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                if (Mathf.Abs(transform.position.x - player.transform.position.x) > maxCloseUpDistance)
                {
                    Vector2 movement = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                    transform.position = new Vector3(movement.x, movement.y, transform.position.z);
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyingKick"))
            {
                if (Mathf.Abs(transform.position.x - player.transform.position.x) > maxCloseUpDistance)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.position.x - transform.position.x, (player.transform.position.y - transform.position.y)).normalized * 0.5f, ForceMode2D.Impulse);
                }
            }

        }

        if(GameObject.Find("Detector").GetComponent<Detector>().PlayerNearby())
        {
            active = true;
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }







}
