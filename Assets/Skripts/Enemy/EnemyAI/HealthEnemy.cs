using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float curHealth = 0f;
    

    void Awake()
    {
        curHealth = maxHealth;
    }

    public void Hit(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

   

}
