using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float timeBetweenDamageTick;
    float totalTime;

    [SerializeField] float verticalForceOnTick;

    bool playerTouchOnSurface;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;


        if(playerTouchOnSurface)
        {
            if(totalTime > timeBetweenDamageTick)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(25);
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,verticalForceOnTick),ForceMode2D.Impulse);
                totalTime = 0f;
            }
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == player.name)
        {
            playerTouchOnSurface = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == player.name)
        {
            playerTouchOnSurface = false;
        }
    }




}
