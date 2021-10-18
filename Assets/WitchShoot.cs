using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchShoot : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float range;
    [SerializeField] float timeBetweenShot;
    float totalTime;

    [SerializeField] GameObject firePoint;
    [SerializeField] GameObject fireballInstantiator;

    float timeBeforeSpawnFireballAfterAnimation;
    bool StartCounting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x - transform.position.x >= 0)
        {
            if(transform.localScale.x >= 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        if (player.transform.position.x - transform.position.x < 0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        totalTime += Time.deltaTime;

        if(PlayerInRange() && totalTime >= timeBetweenShot && StartCounting == false)
        {
            GetComponent<Animator>().SetTrigger("witchFireball");
            StartCounting = true;
            totalTime = 0f;
            
        }
        if(StartCounting && totalTime >= 1f)
        {
            Instantiate(fireballInstantiator, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, firePoint.transform.position.z), transform.rotation);
            totalTime = 0f;
            StartCounting = false;
        }

        
        

    }



    private bool PlayerInRange()
    {
        if(Mathf.Abs(player.transform.position.x - transform.position.x) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
