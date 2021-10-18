using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGothicVaniaBoss : MonoBehaviour
{

    GameObject player;
    float currentHealth;
    float maxHealth;
    float scaleNormal;

    // Start is called before the first frame update
    void Start()
    {
        scaleNormal = transform.localScale.x;
        player = transform.root.gameObject;
        currentHealth = player.GetComponent<PlayerHealthGothicVaniaBoss>().GetHealth();
        maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.GetComponent<PlayerHealthGothicVaniaBoss>().GetHealth();
        transform.localScale = new Vector3((float)((currentHealth / maxHealth) * scaleNormal), transform.localScale.y, transform.localScale.z);
       
    }
}
