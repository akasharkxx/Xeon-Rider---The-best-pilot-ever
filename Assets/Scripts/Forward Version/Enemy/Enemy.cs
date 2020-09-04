using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    private BoxCollider2D boxCollide;
    private bool isDead;
    private float currentHealth;

    private void Start()
    {
        boxCollide = GetComponent<BoxCollider2D>();
        DisableBoxCollider();
        isDead = false;
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    public bool EnemyStatus()
    {
        return isDead;
    }

    public void EnableBoxCollider()
    {
        boxCollide.enabled = true;
    }
    public void DisableBoxCollider()
    {
        boxCollide.enabled = false;
    }
}
