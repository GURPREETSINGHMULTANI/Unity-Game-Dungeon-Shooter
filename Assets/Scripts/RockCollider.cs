﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollider : MonoBehaviour
{

    [SerializeField] string name;
    [SerializeField] GameObject toBeTriggered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == name)
        {
            toBeTriggered.GetComponent<RockFallScript>().rockFall();
        }
    }
}
