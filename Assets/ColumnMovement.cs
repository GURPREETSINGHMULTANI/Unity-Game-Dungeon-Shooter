using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMovement : MonoBehaviour
{
    [SerializeField] Vector2 targetPosition;
    [SerializeField] float speedY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Detector").GetComponent<Detector>().PlayerNearby())
        {
            Vector2 deltaPosition = new Vector2(transform.position.x, transform.position.y - speedY);
            if (transform.position.y - targetPosition.y > 0)
            {
                transform.position = new Vector3(transform.position.x, deltaPosition.y, transform.position.z);

            }
        }
    }
}
