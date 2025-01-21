using UnityEngine;

public class GrenaScr : MonoBehaviour
{
    public float explosionRadius = 5f; 
    public float explosionForce = 700f; 
    public float damage = 50f; 
    public float explosionDelay = 3f; 
    public LayerMask enemyLayer; 

    private bool hasExploded = false;

    public ParticleSystem explosionEffect;

    void Start()
    {
        Invoke("Explode", explosionDelay);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (Collider hitCollider in hitColliders)
        {
            Health enemy = hitCollider.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.hpDecrease(damage);
            }

            Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        if (explosionEffect != null)
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }

        Destroy(gameObject);
    }
}
