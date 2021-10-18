using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurnOffFirstBackground : MonoBehaviour
{

    [SerializeField] GameObject[] backgroundsTurnOff;
    [SerializeField] GameObject[] backgroundsTurnOn;
    float timeTotal;
    [SerializeField] float timeDelayBeforeBackTurnOn;
    [SerializeField] bool turnTimerOn;

    [SerializeField] GameObject pointLight2D;

    // Start is called before the first frame update
    void Start()
    {
        turnTimerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(turnTimerOn)
        {
            timeTotal += Time.deltaTime;
        }

        if (timeTotal >= timeDelayBeforeBackTurnOn)
        {
            for (int i = 0; i < backgroundsTurnOn.Length; i++)
            {
                backgroundsTurnOn[i].SetActive(true);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Portal 1")
        {
            for (int i = 0; i < backgroundsTurnOff.Length; i++)
            {
                backgroundsTurnOff[i].SetActive(false);
            }

            turnTimerOn = true;

            pointLight2D.SetActive(true);
            
        }
    }

}
