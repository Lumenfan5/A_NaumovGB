using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    protected TurretState currentState;

    public Transform Target { get; set; }

    
    [SerializeField] private Transform rotator;
    public Transform Rotator { get => rotator; set => rotator = value; }

    [SerializeField] private Vector3 aimOffset;
    public Vector3 AimOffset { get => aimOffset; set => aimOffset = value; }
    
    [SerializeField] private Transform ghostRotator;
    public Transform GhostRotator { get => ghostRotator; set => ghostRotator = value; }
   
    [SerializeField] private float rotationSpeed;
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }

    [SerializeField] private LayerMask layerMask;

    public Quaternion DefaultRotation { get; set; }
    
    [SerializeField] private Transform gunBarrels;
    public Transform GunBarrels { get => gunBarrels; set => gunBarrels = value; }
    
    [SerializeField] GameObject projectile;

    [SerializeField] private Animator animator;
    public Animator Animator { get => animator; set => animator = value; }

    private void Start()
    {
        DefaultRotation = rotator.rotation;
        ChangeState(new IdleState());
    }

    private void Update()
    {
        currentState.Update();
    }

    public void Shoot()
    {
        Quaternion headingDirection = Quaternion.FromToRotation(projectile.transform.forward, GunBarrels.forward);
        Instantiate(projectile, GunBarrels.position, headingDirection).GetComponent<Projectile>().Direction = GunBarrels.forward;
    }

    public bool CanSeeTarget(Vector3 direction, Vector3 origin, string tag)
    {
        RaycastHit hit;

        if(Physics.Raycast(origin, direction, out hit, Mathf.Infinity, layerMask))
        {
            if(hit.collider.tag == tag)
            {
                return true;
            }
        }

        return false;
    }

    public void ChangeState(TurretState newstate)
    {
        if (newstate != null)
        {
            newstate.Exit();
        }
        this.currentState = newstate;
        newstate.Enter(this);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

}
