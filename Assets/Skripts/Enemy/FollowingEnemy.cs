using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


[RequireComponent(typeof(NavMeshAgent))]

public class FollowingEnemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Playermove>().transform;
    }


    void Update()
    {
        agent.SetDestination(player.position);
    }
}
