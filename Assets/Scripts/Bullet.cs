using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float totalFloatTime;
    public float maxFloatTime;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Crab Shot(Clone)" && collision.gameObject.name != "Warp Shooter")
        {
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        totalFloatTime += Time.deltaTime;

        if (totalFloatTime > maxFloatTime)
        {
            PlayAnimation();
        }
    }


}
