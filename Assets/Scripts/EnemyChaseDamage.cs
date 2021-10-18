using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseDamage : MonoBehaviour
{

    [SerializeField] GameObject player;
    public float velocityX;
    public float currentPositionRelativeToStart;
    public float maxMovementLeft;
    public float startingPosition;
    bool movingLeft;
    public float playerDistanceHypo;

    public float range;



    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        startingPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        currentPositionRelativeToStart = transform.position.x - startingPosition;
        if (maxMovementLeft - currentPositionRelativeToStart <= 2 * maxMovementLeft && movingLeft == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX * Time.deltaTime, 0f);
        }
        else if (movingLeft == true)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y,transform.localScale.y);
            movingLeft = false;
        }


        if (maxMovementLeft - currentPositionRelativeToStart >= maxMovementLeft && movingLeft == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX * Time.deltaTime, 0f);
        }
        else if (movingLeft == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
            movingLeft = true;
        }

        playerNearby();
    }


    void playerNearby()
    {
        playerDistanceHypo = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(player.transform.position.x - transform.position.x),2f)  + Mathf.Pow(Mathf.Abs(player.transform.position.y - transform.position.y), 2f));

        if(playerDistanceHypo < range)
        {
            GetComponent<WeaponCrabShot>().Shoot(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        }
    }
}
