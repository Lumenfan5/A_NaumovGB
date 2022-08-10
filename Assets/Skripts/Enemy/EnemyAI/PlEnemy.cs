using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


[RequireComponent(typeof(NavMeshAgent))]
public class PlEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    private int index;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
    }

    
    void Update()
    {
        Patrol(); 
    }

    void Patrol()
    {
        Vector3 direction = waypoints[index].transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);

        if (agent.remainingDistance <= 1)
        {

            index = (index + 1) % waypoints.Length;
            agent.SetDestination(waypoints[index].position);
        }
    }
    
}
