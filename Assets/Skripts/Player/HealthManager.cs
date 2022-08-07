using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float curHealth = 0f;
    [SerializeField] private float fak = 20f;
    [SerializeField] private float damage = 20f;
    void Awake()
    {
        curHealth = maxHealth;
    }

   
    public void Hit (float damage)
    {
        curHealth -= damage;
        if(curHealth <=0)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "first aid kit")
        {
            curHealth += fak;
        }

        if (other.tag == "Enemy")
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }

    }

}
