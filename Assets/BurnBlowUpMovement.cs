using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnBlowUpMovement : MonoBehaviour
{


    [SerializeField] float maxMovementLeft;
    float startingPosition;
    [SerializeField] float speed;

    [SerializeField] GameObject player;

    bool turnedRight;
    bool turnedLeft;

    bool speedDecrease;
    float speedAtStart;

    [SerializeField] GameObject blowUp;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position.x;
        speedAtStart = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        }
        if (transform.localScale.x > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);
        }


        if (startingPosition - transform.position.x > maxMovementLeft && turnedRight == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            turnedRight = true;
            turnedLeft = false;
        }
        if (startingPosition - transform.position.x < 0 && turnedLeft == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            turnedLeft = true;
            turnedRight = false;
        }

        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Warp Shooter")
        {
            Instantiate(blowUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
