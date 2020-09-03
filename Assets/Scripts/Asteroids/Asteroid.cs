using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour
{
    [SerializeField] int hitPoint = 1;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float hitEffectTime = 1f;
    [SerializeField] GameObject target;
    [SerializeField] float moveSpeed = 3f;

    int scorePoint;
    Rigidbody2D rb;
    AudioSource audioDie;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        scorePoint = hitPoint;
        audioDie = GetComponent<AudioSource>();
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.mass = 3f;
        Vector2 dir = target.transform.position - transform.position;
        dir = Vector3.Normalize(dir);
        rb.velocity = dir * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "laser")
        {
            GameObject hitPoint = Instantiate(hitEffect, this.transform);
            Destroy(hitPoint, hitEffectTime);
            laserBuilder laser = collision.gameObject.GetComponent<laserBuilder>();
            TakeDamage(laser.damage);
        }
    }

    void TakeDamage(int dam)
    {
        hitPoint -= dam;
        
        if(hitPoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreBucket.Instance.ChangeScore(scorePoint);
        audioDie.Play();
        Destroy(gameObject, 0.2f);
    }
}
