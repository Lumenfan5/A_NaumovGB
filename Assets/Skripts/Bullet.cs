using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject Bulletprefab;
    [SerializeField] private Transform spawnbullet;
    [SerializeField] private float spawnStep = 1f;
    [SerializeField] private float angularSpeed = 5f;
    private float nextSpawnTime;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<Playermove>().transform;
    }

    private void Update()
    {
        LookAtPlayer();
        LifeTime();
    }
   
    private void LookAtPlayer()
    {
        var direction = player.transform.position - transform.position;
        var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(rotation);
    }


    void LifeTime()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(Bulletprefab, spawnbullet.position, spawnbullet.rotation);
            nextSpawnTime = Time.time + spawnStep;
        }
    } 
}