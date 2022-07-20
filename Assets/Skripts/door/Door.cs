using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public GameObject door;
    float angularSpeed = 20f;
    public Transform doorOpen;

    //private void Update()
    //{
    //    transform.LookAt(doorOpen);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        transform.LookAt(doorOpen);
    //        //transform.RotateAround(door.transform.position, Vector3.up, 90 * angularSpeed);
    //    }
    //}
}
