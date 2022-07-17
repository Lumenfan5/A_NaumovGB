using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject Mina;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
           Destroy(gameObject);            
        }
    }
}
