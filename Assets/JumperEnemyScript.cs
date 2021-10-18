using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class JumperEnemyScript : MonoBehaviour
{

    [SerializeField] GameObject playerToBeAttacked;
    Animator animator;
    [SerializeField] float timeBetweenAttack;
    [SerializeField] float playerDistanceHypo;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float totalTimeShot;
    bool isGrounded;


    [SerializeField] float maxAttackEnemyRange;
    Vector3 startingPosition;
    bool returning = false;
    [SerializeField] float maxRangeAwayFromStartNeutral;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isJumping", false);
        startingPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        totalTimeShot += Time.deltaTime;

        if (InRange() && returning == false)
        {
            if (playerNearby() && totalTimeShot >= timeBetweenAttack && isGrounded)
            {
                Attack();
                totalTimeShot = 0f;
            }
        }
        else if(totalTimeShot >= timeBetweenAttack)
        {
            if (Mathf.Abs(transform.position.x - startingPosition.x) > maxRangeAwayFromStartNeutral && isGrounded)
            {
                ReturnToStart();
                returning = true;
                totalTimeShot = 0f;
            }
            else if(Mathf.Abs(transform.position.x - startingPosition.x) <= maxRangeAwayFromStartNeutral)
            {
                returning = false;
            }
        }


    }



    public void Attack()
    {

        float distanceHorizontalToPlayer = Mathf.Abs((playerToBeAttacked.transform.position.x - transform.position.x));
        float distanceVerticalToPlayer = Mathf.Abs(playerToBeAttacked.transform.position.y - transform.position.y);
        float timeWithParticularSpeed = distanceHorizontalToPlayer / horizontalSpeed;
        float acceleration = -9.8f;
        float velocityVertical = ( distanceVerticalToPlayer - 0.5f * acceleration * timeWithParticularSpeed * timeWithParticularSpeed) / timeWithParticularSpeed;



        if ((playerToBeAttacked.transform.position.x - transform.position.x) < 0 && (playerToBeAttacked.transform.position.y - transform.position.y) > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalSpeed, velocityVertical);
        }
        if ((playerToBeAttacked.transform.position.x - transform.position.x) > 0 && (playerToBeAttacked.transform.position.y - transform.position.y) > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed, velocityVertical);
        }
        if ((playerToBeAttacked.transform.position.x - transform.position.x) < 0 && (playerToBeAttacked.transform.position.y - transform.position.y) < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalSpeed, velocityVertical);
        }
        if ((playerToBeAttacked.transform.position.x - transform.position.x) > 0 && (playerToBeAttacked.transform.position.y - transform.position.y) < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed, velocityVertical);
        }



    }

    public bool playerNearby()
    {
        playerDistanceHypo = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(playerToBeAttacked.transform.position.x - transform.position.x), 2f) + Mathf.Pow(Mathf.Abs(playerToBeAttacked.transform.position.y - transform.position.y), 2f));

        if (playerDistanceHypo < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }



    public bool InRange()
    {
        if(Mathf.Abs(startingPosition.x - transform.position.x) > maxAttackEnemyRange)
        {
            return false;
        }
        else
        {
            return true;
        }


    }



    public void ReturnToStart()
    {
        
        Vector3 temporaryPositionHolder = new Vector3(0f,0f,0f);

        if(Mathf.Abs(transform.position.x - startingPosition.x) > 10)
        {
            temporaryPositionHolder = new Vector3(transform.position.x - (10*((transform.position.x - startingPosition.x)/Mathf.Abs(transform.position.x - startingPosition.x))),startingPosition.y,startingPosition.z);
        }
        if (Mathf.Abs(transform.position.x - startingPosition.x) < 10)
        {
            temporaryPositionHolder = new Vector3(transform.position.x - (transform.position.x - startingPosition.x), startingPosition.y, startingPosition.z);
        }


        float distanceHorizontalToPlayer = Mathf.Abs(temporaryPositionHolder.x - transform.position.x);
        float distanceVerticalToPlayer = Mathf.Abs(temporaryPositionHolder.y - transform.position.y);
        float timeWithParticularSpeed = distanceHorizontalToPlayer / horizontalSpeed;
        float acceleration = -9.8f;
        float velocityVertical = (distanceVerticalToPlayer - 0.5f * acceleration * timeWithParticularSpeed * timeWithParticularSpeed) / timeWithParticularSpeed;


        if ((temporaryPositionHolder.x - transform.position.x) < 0 && (temporaryPositionHolder.y - transform.position.y) > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalSpeed, velocityVertical);
        }
        if ((temporaryPositionHolder.x - transform.position.x) > 0 && (temporaryPositionHolder.y - transform.position.y) > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed, velocityVertical);
        }
        if ((temporaryPositionHolder.x - transform.position.x) < 0 && (temporaryPositionHolder.y - transform.position.y) < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalSpeed, velocityVertical);
        }
        if ((temporaryPositionHolder.x - transform.position.x) > 0 && (temporaryPositionHolder.y - transform.position.y) < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalSpeed, velocityVertical);
        }
    }

}


