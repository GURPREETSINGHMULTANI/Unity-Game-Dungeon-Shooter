using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] float speedCharacter;
    private Animator anim;
    [SerializeField] float jumpForce;
    public bool isGrounded = false;
    Vector2 characterScale;

    void Start()
    {
        anim = GetComponent<Animator>();
        characterScale = transform.localScale;
    }

    void Update()
    {


        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded == true)
            {
                anim.SetTrigger("jump");
                Jump();
            }
        }

        PlayerMovement();

        transform.Translate(Input.GetAxis("Horizontal") * speedCharacter * Time.deltaTime, 0f, 0f);
        transform.localScale = characterScale;

    }

    void Jump()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("HeavyBandit_Attack"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
      
    }

    void PlayerMovement()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("HeavyBandit_Attack"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {

                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                if (characterScale.x > 0)
                {
                    characterScale.x = -characterScale.x;
                }

            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (characterScale.x < 0)
                {
                    characterScale.x = -characterScale.x;
                }
            }
        }
    }

}
