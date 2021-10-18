using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpHitEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == GameObject.Find("Warp Shooter").name)
        {
            GameObject.Find("Warp Shooter").GetComponent<PlayerHealth>().TakeDamage(50);
        }
    }
}
