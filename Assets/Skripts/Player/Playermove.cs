using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Playermove : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 5f;
    float x;
    float z;
    private const string Ground = "Ground";
    private bool isGround = true;
    private Rigidbody rb;
    private bool Idle;
    private Animator anim;
    private void Update()
    {
        Move();


    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Idle", true);
            transform.localPosition += transform.forward * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += 2 * (transform.forward * speed * Time.deltaTime);
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            { anim.SetBool("Run", false); }
        }
        else anim.SetBool("Idle", false);
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

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(jumpForce * transform.up, ForceMode.Impulse);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        isGround = collision.gameObject.CompareTag(Ground);
    }

    private void OnCollisionExit(Collision other)
    {
        isGround = !other.gameObject.CompareTag(Ground);
    }
}
 