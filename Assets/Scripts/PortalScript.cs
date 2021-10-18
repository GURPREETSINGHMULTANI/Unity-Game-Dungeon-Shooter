using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject teleportingPlaceObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name != "Portal 2")
        {
            player.transform.position = new Vector3(teleportingPlaceObject.transform.position.x, teleportingPlaceObject.transform.position.y, teleportingPlaceObject.transform.position.z);
        }
    }

}
