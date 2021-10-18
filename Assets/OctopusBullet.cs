using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float totalFloatTime;
    public float maxFloatTime;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Warp Shooter");
        float fireballRotationAngleZ;
        float distY_Divide_distX = Mathf.Abs((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x));
        fireballRotationAngleZ = Mathf.Atan(Mathf.Abs(distY_Divide_distX));
        if (player.transform.position.x - transform.position.x < 0 && player.transform.position.y - transform.position.y < 0)
        {
            rb.velocity = new Vector3(-Mathf.Cos(fireballRotationAngleZ) * speed, -Mathf.Sin(fireballRotationAngleZ) * speed, -2f);
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
        if (collision.gameObject.name != "Power Up(Clone)" && collision.gameObject.name != "Octopus" && collision.gameObject.name != "Bullet(Clone)" && collision.gameObject.name != "Bullet Up(Clone)")
        {
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        Destroy(gameObject);
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
