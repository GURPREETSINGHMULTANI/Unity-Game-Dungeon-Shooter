using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchFall : MonoBehaviour
{
    bool timerOn;
    [SerializeField]float timeCounter;
    [SerializeField] float maxFloatTime;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0f;
        timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            timeCounter = timeCounter + Time.deltaTime;
        }
        if(timeCounter >= maxFloatTime)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Warp Shooter")
        {
            timerOn = true;
        }
    }
    
}
