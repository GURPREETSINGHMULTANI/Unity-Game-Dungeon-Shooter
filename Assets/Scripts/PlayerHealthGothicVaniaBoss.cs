using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthGothicVaniaBoss : MonoBehaviour
{
    [SerializeField][Range(0,400)] int health;
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
            Destroy(gameObject);
            if (gameObject.name == "GothicVaniaPlayer")
            {
                SceneManager.LoadScene("Level Completion");
            }
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



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Jumper"))
        {
            TakeDamage(30);
        }
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Clamp(health -= damage, 0,400);
    }


}
