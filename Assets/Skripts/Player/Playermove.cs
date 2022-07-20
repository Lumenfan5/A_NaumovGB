using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermove : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private float speed = 1f;
    float x;
    float z;
    

   

    private void Update()
    {
        Move();
    }

    
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += 2*(transform.forward * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
    }
}
 