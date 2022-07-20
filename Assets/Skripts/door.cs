using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private door capsule;

  
    void Update()
    {
        void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);

        }
    }

    
}
