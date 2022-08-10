using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField] private float speed = 25f;
    [SerializeField] private float damage = 20f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Hit (collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other.gameObject);
    }

    private void Hit(GameObject collisionGameObject)
    {
        if(collisionGameObject.TryGetComponent(out HealthManager health))
        {
            health.Hit(damage);
        }
        Destroy(gameObject);
    }
}
