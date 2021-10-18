using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WitchFireball : MonoBehaviour
{

    GameObject personSpawningFireball;
    float directionOfFire;
    [SerializeField] float speed;

    [SerializeField] float timeBeforeDeath;
    float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        personSpawningFireball = GameObject.Find("Witch");
        directionOfFire = personSpawningFireball.GetComponent<Transform>().localScale.x / Mathf.Abs(personSpawningFireball.GetComponent<Transform>().localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(directionOfFire > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed,0f);
        }
        if (directionOfFire < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        }


        totalTime += Time.deltaTime;

        if(totalTime > timeBeforeDeath)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.name == "Warp Shooter")
        {
            GameObject.Find("Warp Shooter").GetComponent<PlayerHealth>().TakeDamage(20);
        }

        Destroy(gameObject);
    }
}
