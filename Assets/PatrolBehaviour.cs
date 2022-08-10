using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> points = new();
    NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;     
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
    }

    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(points[UnityEngine.Random.Range(0, points.Count)].position);
        }
       
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrol", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);

    }

    
}