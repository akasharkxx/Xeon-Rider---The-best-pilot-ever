using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantShoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float timeBetweenShoots, laserSpeed;
    [SerializeField] private int laserPerShoot;

    private bool isShooting;
    private float elapsedTime;

    private void Start()
    {
        isShooting = false;
        elapsedTime = 0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timeBetweenShoots)
        {
            isShooting = true;
            elapsedTime = 0;
        }
        else
        {
            isShooting = false;
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            GameObject laser = Instantiate(laserPrefab, attackPoint.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = laser.transform.up * laserSpeed;
            isShooting = false;
        }
    }

}
