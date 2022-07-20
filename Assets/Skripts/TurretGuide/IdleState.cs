using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : TurretState
{
    public override void Update()
    {
        if(parent.DefaultRotation != parent.Rotator.rotation)
        {
            parent.Rotator.rotation = Quaternion.RotateTowards(parent.Rotator.rotation, parent.DefaultRotation, Time.deltaTime * parent.RotationSpeed);
        }

        if(parent.Target != null)
        {
            if(parent.CanSeeTarget(((parent.Target.position + parent.AimOffset) - parent.GunBarrels.position), parent.GunBarrels.position, "Player"))
            {
                parent.ChangeState(new FindTargetState());
            }
        }
    }

    public override void Enter(Turret parent)
    {
        base.Enter(parent);
        parent.Animator.SetBool("Shoot", false);
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player in zone");
            parent.Target = other.transform;
            parent.ChangeState(new FindTargetState());
        }
    }
}
