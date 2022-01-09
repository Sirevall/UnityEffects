using UnityEngine;
using System.Collections.Generic;

public class Bomb : MonoBehaviour
{
    public GameObject ExplosionParticlesPrefab;
    public float Force;
    public float Radius;

    private List<Rigidbody> _objects = new List<Rigidbody>();

    void Start()
    {
        float randomX = UnityEngine.Random.Range(10f, 100f);
        float randomY = UnityEngine.Random.Range(10f, 100f);
        float randomZ = UnityEngine.Random.Range(10f, 100f);

        Rigidbody bomb = GetComponent<Rigidbody>();
        bomb.AddTorque(randomX, randomY, randomZ);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (ExplosionParticlesPrefab)
        {
            GameObject explosion = (GameObject)Instantiate(ExplosionParticlesPrefab, transform.position, ExplosionParticlesPrefab.transform.rotation);
            FindObjectsWithRigidbody();
            Explode();
            Destroy(explosion, explosion.GetComponentInChildren<ParticleSystem>().main.startLifetimeMultiplier);
            _objects.Clear();
            
        }

        Destroy(gameObject);
    }
    private void Explode()
    {
        foreach (var obj in _objects)
        {
            obj.AddExplosionForce(Force, transform.position, Radius, 0.6f, ForceMode.Impulse);
        }
    }
    private void FindObjectsWithRigidbody()
    {
        Collider[] objectsWithCollider = Physics.OverlapSphere(transform.position, Radius);
        foreach (var colliderObject in objectsWithCollider)
        {
            if (colliderObject.attachedRigidbody)
            {
                _objects.Add(colliderObject.gameObject.GetComponent<Rigidbody>());
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
