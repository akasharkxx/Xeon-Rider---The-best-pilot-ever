using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootController : MonoBehaviour
{
    [Header("Weapon Specification")]
    [SerializeField] GameObject laser;
    [SerializeField] float laserForce = 5f;
    [SerializeField] float destroyTime = 2f;
    [SerializeField] float coolDown = 1f;

    AudioSource laserAudio;

    private void Start()
    {
        laserAudio = GetComponent<AudioSource>();
    }

    public void Fire()
    {     
        laserAudio.Play();

        GameObject laserInstatiated = Instantiate(laser, transform.position, transform.rotation);
        Rigidbody2D rb = laserInstatiated.GetComponent<Rigidbody2D>();
        rb.AddForce(laserForce * transform.up, ForceMode2D.Impulse);
        Destroy(laserInstatiated, destroyTime);
    }
}
