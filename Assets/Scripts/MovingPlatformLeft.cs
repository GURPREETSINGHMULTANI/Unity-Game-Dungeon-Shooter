using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeft : MonoBehaviour
{
    public float velocityX;
    public float currentPositionRelativeToStart;
    public float maxMovementLeft;
    public float startingPosition;
    bool movingLeft;

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
        if (maxMovementLeft - currentPositionRelativeToStart <= 2*maxMovementLeft  && movingLeft == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX * Time.deltaTime, 0f);
        }
        else if (movingLeft == true)
        {
            movingLeft = false;
        }


        if (maxMovementLeft - currentPositionRelativeToStart >= maxMovementLeft && movingLeft == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX * Time.deltaTime, 0f);
        }
        else if (movingLeft == false)
        {
            movingLeft = true;
        }
        

    }
}

