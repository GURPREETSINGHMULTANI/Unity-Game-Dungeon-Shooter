using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexBackground : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    [SerializeField] Vector2 parallaxEffectMultiplier;
    [SerializeField] float offset;
    [SerializeField] float SpriteSize;

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



        if(cameraTransform.position.x + 16f >= transform.position.x + SpriteSize/2)
        {
            transform.position = new Vector3(cameraTransform.position.x + offset, transform.position.y, transform.position.z);
        }
        else if(cameraTransform.position.x - 16f <= transform.position.x - SpriteSize/2)
        {
            transform.position = new Vector3(cameraTransform.position.x - offset, transform.position.y, transform.position.z);
        }


        
    }
}
