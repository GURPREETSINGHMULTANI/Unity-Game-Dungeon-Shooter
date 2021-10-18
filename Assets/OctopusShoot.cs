using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusShoot : MonoBehaviour
{
    [SerializeField] GameObject playerToBeAttacked;
    [SerializeField] float playerDistanceHypo;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float maxTimeBetweenShot;
    [SerializeField] Transform shootingPoint;
    float totalTimeBetweenShot;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTimeBetweenShot += Time.deltaTime;
        if(playerNearby() && totalTimeBetweenShot >= maxTimeBetweenShot)
        {
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            totalTimeBetweenShot = 0f;
        }
    }


    public bool playerNearby()
    {
        playerDistanceHypo = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(playerToBeAttacked.transform.position.x - transform.position.x), 2f) + Mathf.Pow(Mathf.Abs(playerToBeAttacked.transform.position.y - transform.position.y), 2f));

        if (playerDistanceHypo < 14)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
