using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField][Range(0,100)] int health;
    [SerializeField] GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(deathAnimation, transform.position, transform.rotation);
            if (gameObject.name == "Warp Shooter")
            {
                SceneManager.LoadScene("Game Over");
            }
            Destroy(gameObject);
            
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)" && gameObject.name != "Warp Shooter")
        {
            TakeDamage(20);
        }
        if (collision.gameObject.name == "Bullet Up(Clone)" && gameObject.name != "Warp Shooter")
        {
            TakeDamage(20);
        }
        if (collision.gameObject.name == "Crab Shot(Clone)" && gameObject.name != "Crab")
        {
            TakeDamage(10);
        }
        if (collision.gameObject.name == "Power Up(Clone)" && gameObject.name != "Octopus")
        {
            TakeDamage(25);
        }
        if(collision.gameObject.name == "Fire(Clone)" && gameObject.name != "Angel")
        {
            TakeDamage(20);
        }
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Jumper"))
        {
            TakeDamage(30);
        }
        if (collision.gameObject.name == "GothicVaniaPlayer")
        {

            GothicVaniaBossDamage();
        }
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health -= damage, 0,100);
    }

    private void GothicVaniaBossDamage()
    {
        Animator anim = GameObject.Find("GothicVaniaPlayer").GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            TakeDamage(20);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            TakeDamage(20);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("CrouchKick"))
        {
            TakeDamage(30);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyingKick"))
        {
            TakeDamage(5);
        }

    }
}
