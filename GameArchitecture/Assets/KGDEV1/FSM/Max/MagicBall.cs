using UnityEngine;
using ObjectPool;

public class MagicBall : MonoBehaviour, IPoolObject
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int damage = 5;
    [SerializeField] private Rigidbody rb;

    public void OnObjectSpawned()
    {
        gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        
    }
}
