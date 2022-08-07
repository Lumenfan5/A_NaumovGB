using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float delay = 3f;
        [SerializeField] private float radius = 5f;
        [SerializeField] private float force = 250f;
        [SerializeField] private float damage = 60f;

        float countdown;
        bool hasExploted = false;

        private void Start()
        {
            countdown = delay;
        }


        void Update()
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0f && !hasExploted)
            {
                Explode();
                hasExploted = true;
            }


        }       

        void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);  
                }
            }         
            
            HitExplosion();

            Destroy(gameObject);
        }

        private void HitExplosion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in colliders)
            {
                HealthEnemy enemy = nearbyObject.GetComponent<HealthEnemy>();
               
                if (enemy != null)
                {
                    enemy.Hit(damage);
                }
            }

        }
    } 
}
