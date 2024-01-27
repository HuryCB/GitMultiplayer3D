using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : OwnerObject
{
    public Rigidbody rb;

    AudioSource stepSound;
    float horizontal;
    float vertical;
    public float speed = 0;

    public float walkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
    }
    void Update()
    {

        move();

    }

    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (rb.velocity.z != 0 || rb.velocity.y != 0)
        {
            // idle = false;
        }
        else
        {
            // idle = true;
        }

        // if (idle)
        // {
        //     stepSound.Stop();
        // }
        // else
        // {
        //     if (!stepSound.isPlaying)
        //     {
        //         stepSound.Play();
        //     }
        // }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * speed, 0, vertical * speed);
    }
}
