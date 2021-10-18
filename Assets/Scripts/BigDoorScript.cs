using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorScript : MonoBehaviour
{

    [SerializeField] GameObject requirementOne;
    [SerializeField] GameObject requirementTwo;
    [SerializeField] GameObject requirementThree;
    [SerializeField] GameObject requirementFour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(requirementOne.activeSelf && requirementTwo.activeSelf && requirementThree.activeSelf && requirementFour.activeSelf)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
