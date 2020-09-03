using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBuilder : MonoBehaviour
{
    [SerializeField] GameObject effect;
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        Destroy(gameObject);   
    }
}
 