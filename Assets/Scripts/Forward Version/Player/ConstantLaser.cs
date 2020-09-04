using UnityEngine;

public class ConstantLaser : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float destroyTime;

    private Rigidbody2D laserBody;
    private Vector2 currentVelocity;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
        //laserBody = GetComponent<Rigidbody2D>();
        //currentVelocity = laserBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);

        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
