using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWarpShooter : MonoBehaviour
{

    public Transform firePoint;
    public Transform fireUpPoint;
    public GameObject bulletPrefab;
    public GameObject bulletUpPrefab;
    public float timeBetweenShot;
    public bool canShoot;
    public float totalTime;
    public Vector3 currentMouseClickPosition;


    private void Start()
    {
        timeBetweenShot = 0.5f;
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {

       
       if(Input.GetButtonDown("Fire1") && canShoot && Input.mousePosition.y < Screen.height/2 && Input.mousePosition.x > Screen.width * 0.75)
        {
            Shoot();
            canShoot = false;
        }
        if (Input.GetButtonDown("Fire1") && canShoot && Input.mousePosition.y > Screen.height/2)
        {
            ShootUp();
        }
        if (canShoot == false)
        {
            totalTime += Time.deltaTime;
        }
       if(totalTime >= timeBetweenShot)
        {
            totalTime = 0f;
            canShoot = true;
        }




    }


    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootUp()
    {
        Instantiate(bulletUpPrefab, fireUpPoint.position, fireUpPoint.rotation);
    }


}
