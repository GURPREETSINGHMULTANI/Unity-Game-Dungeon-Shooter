using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatformRight : MonoBehaviour
{
    public float velocityX;
    public float currentPositionRelativeToStart;
    public float maxMovementRight;
    public float startingPosition;
    bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
        startingPosition = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        currentPositionRelativeToStart = transform.position.x - startingPosition;
        
        if (maxMovementRight - currentPositionRelativeToStart >= 0 && movingRight == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX * Time.deltaTime, 0f);
        }
        else if(movingRight == true)
        {
            movingRight = false;
        }



        if (maxMovementRight - currentPositionRelativeToStart <= maxMovementRight && movingRight == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX * Time.deltaTime, 0f);
        }
        else if(movingRight == false)
        {
            movingRight = true;
        }
        

    }
}
