using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGrounded : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GetComponent<ShooterAnimation>().isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GetComponent<ShooterAnimation>().isGrounded = false;
        }
    }
}
