using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAnimation : MonoBehaviour
{
    [SerializeField] float speedCharacter;
    private Animator anim;
    [SerializeField] float jumpForce;
    public bool isGrounded = false;
    Vector2 characterScale;

    bool portalOneCollided;


    void Start()
    {
        anim = GetComponent<Animator>();
        characterScale = transform.localScale;
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded == true)
            {
                anim.SetTrigger("jump");
                Jump();
            }
        }

        if (Input.GetButtonDown("Fire1") == true && Input.mousePosition.y > Screen.height / 2 && GetComponent<WeaponWarpShooter>().canShoot)
        {
            anim.SetTrigger("shootUp");
        }
        else if(Input.mousePosition.y < Screen.height / 2 && (Input.mousePosition.x > Screen.height*0.75))
        {
            PlayerMovementShoot();
        }
        else
        {
            PlayerMovement();
        }

    }





    void Jump()
    {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {

            anim.SetBool("isRunning", true);
            anim.SetBool("isRunningShoot", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.rotation.y > 0)
            {
                transform.Rotate(0f,180f,0f);
            }

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.rotation.y == 0)
            {
                transform.Rotate(0f,-180f,0f);
            }
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(Input.GetAxis("Horizontal") * speedCharacter * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(-Input.GetAxis("Horizontal") * speedCharacter * Time.deltaTime, 0f, 0f);
        }
        transform.localScale = characterScale;

    }

    void PlayerMovementShoot()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {

            anim.SetBool("isRunningShoot", true);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunningShoot", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.rotation.y > 0)
            {
                transform.Rotate(0f, 180f, 0f);
            }

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.rotation.y == 0)
            {
                transform.Rotate(0f, -180f, 0f);
            }
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(Input.GetAxis("Horizontal") * speedCharacter * Time.deltaTime*0.5f, 0f, 0f);
        }
        else
        {
            transform.Translate(-Input.GetAxis("Horizontal") * speedCharacter * Time.deltaTime*0.5f, 0f, 0f);
        }
        transform.localScale = characterScale;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Portal 1")
        {
            portalOneCollided = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Portal 1")
        {
            portalOneCollided = true;
        }
    }

    public bool PortalCollided()
    {
        return portalOneCollided;
    }


}
