using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float totalFloatTime;
    public float maxFloatTime;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Warp Shooter");
        float fireballRotationAngleZ;
        float distY_Divide_distX = Math.Abs((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x));
        fireballRotationAngleZ = Mathf.Atan(Mathf.Abs(distY_Divide_distX));
        if (player.transform.position.x - transform.position.x  < 0 && player.transform.position.y - transform.position.y < 0)
        {
            rb.velocity = new Vector3(-Mathf.Cos(fireballRotationAngleZ)*speed, -Mathf.Sin(fireballRotationAngleZ) * speed, -2f);
        }
        if (player.transform.position.x - transform.position.x > 0 && player.transform.position.y - transform.position.y > 0)
        {
            rb.velocity = new Vector3(Mathf.Cos(fireballRotationAngleZ) * speed, Mathf.Sin(fireballRotationAngleZ) * speed, -2f);
        }
        if (player.transform.position.x - transform.position.x < 0 && player.transform.position.y - transform.position.y > 0)
        {
            rb.velocity = new Vector3(-Mathf.Cos(fireballRotationAngleZ) * speed, Mathf.Sin(fireballRotationAngleZ) * speed, -2f);
        }
        if (player.transform.position.x - transform.position.x > 0 && player.transform.position.y - transform.position.y < 0)
        {
            rb.velocity = new Vector3(Mathf.Cos(fireballRotationAngleZ) * speed, -Mathf.Sin(fireballRotationAngleZ) * speed, -2f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Crab" && collision.gameObject.name != "Crab Shot(Clone)"  && collision.gameObject.name != "Bullet(Clone)" && collision.gameObject.name != "Angel")
        {
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        rb.velocity = transform.right * 0;
        GetComponent<Animator>().SetTrigger("Impact");
        Destroy(gameObject,1f);
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
