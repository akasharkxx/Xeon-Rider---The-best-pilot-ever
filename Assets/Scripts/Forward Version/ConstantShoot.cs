using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantShoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float timeBetweenShoots;
    [SerializeField] private int laserPerShoot;

    private bool isShooting;

    private void Start()
    {

    }

}
