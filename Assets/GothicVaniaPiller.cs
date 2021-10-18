using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GothicVaniaPiller : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float lengthBetweenNextPillar;
    [SerializeField] Transform cameraTransform;
    private Vector3 lastCameraPosition;
    [SerializeField] Vector2 parallaxEffectMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0f);
        lastCameraPosition = cameraTransform.position;


        if (player.transform.position.x - transform.position.x > lengthBetweenNextPillar/2)
        {
            transform.position = new Vector3(player.transform.position.x + lengthBetweenNextPillar / 2, transform.position.y, transform.position.z);
        }
        if (player.transform.position.x - transform.position.x < -lengthBetweenNextPillar / 2)
        {
            transform.position = new Vector3(player.transform.position.x - lengthBetweenNextPillar / 2, transform.position.y, transform.position.z);
        }
    }
}
