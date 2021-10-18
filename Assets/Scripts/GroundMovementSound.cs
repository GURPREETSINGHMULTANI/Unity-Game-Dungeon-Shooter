using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovementSound : MonoBehaviour
{

    AudioSource footSteps;


    // Start is called before the first frame update
    void Start()
    {
        footSteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
        {
            if (Input.GetKey(KeyCode.RightArrow) && GetComponent<CharacterAnimation>().isGrounded)
            {
                if (!footSteps.isPlaying)
                {
                    footSteps.PlayOneShot(footSteps.clip);
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && GetComponent<CharacterAnimation>().isGrounded)
            {
                if (!footSteps.isPlaying)
                {
                    footSteps.PlayOneShot(footSteps.clip);
                }
            }
            else
            {
                footSteps.Stop();
            }
        }

    }


}
