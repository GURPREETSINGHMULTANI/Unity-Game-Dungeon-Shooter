using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] GameObject movedLever;

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
        if (collision.gameObject.name == ("Warp Shooter"))
        {
            Instantiate(movedLever, new Vector3(48.1f, 13f), transform.rotation);
            Destroy(gameObject);
        }
    }
}
