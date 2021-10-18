using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrabShot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireballRotationAngleZ;
    public float totalInBetweenTime;
    public float fireballFireSpeed;




    // Update is called once per frame
    void Update()
    {
    }


    public void Shoot(float distanceX, float distanceY)
    {
        totalInBetweenTime += Time.deltaTime;
        CreatingFireballs(distanceX, distanceY);
    }

    private void CreatingFireballs(float distanceX, float distanceY)
    {
        if (totalInBetweenTime > fireballFireSpeed)
        {
            if (distanceX < 0 && distanceY > 0)
            {
                fireballRotationAngleZ = Mathf.PI - Mathf.Atan(Math.Abs(distanceY / distanceX));
            }
            if (distanceX > 0 && distanceY > 0)
            {
                fireballRotationAngleZ = Mathf.Atan(Math.Abs(distanceY / distanceX));
            }
            if (distanceX < 0 && distanceY < 0)
            {
                fireballRotationAngleZ = Mathf.PI + Mathf.Atan(Math.Abs(distanceY / distanceX));
            }
            if (distanceX > 0 &&  distanceY < 0)
            {
                fireballRotationAngleZ = Mathf.PI*2 - Mathf.Atan(Math.Abs(distanceY / distanceX));
            }
            fireballRotationAngleZ = Mathf.Rad2Deg * fireballRotationAngleZ;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, fireballRotationAngleZ));
            totalInBetweenTime = 0f;
        }
    }
}
