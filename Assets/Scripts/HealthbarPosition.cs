using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarPosition : MonoBehaviour
{
    [SerializeField] float distanceVerticalPlayer;
    [SerializeField] float distanceHorizontalPlayer;
    Vector3 playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.parent.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = transform.parent.transform.position;
        playerTransform.y = playerTransform.y + distanceVerticalPlayer;
        playerTransform.x = playerTransform.x + distanceHorizontalPlayer;
        gameObject.transform.position = playerTransform;
    }
}
