using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float timeBetweenTick;
    float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == player.name)
        {
            if (totalTime >= timeBetweenTick)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(10);
                timeBetweenTick = 0f;
            }
        }
    }
}
