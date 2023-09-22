using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Movement : MonoBehaviour
{
    // animator
    public Animator sakuraAnimator;
    //
    
    public Vector3 move = Vector3.zero;
    new Rigidbody rigidbody;
    public float speed = 8;
    public float targetMovingSpeed;

    public bool canRun = true;
    public bool walking { get; private set; }
    public float runSpeed = 16;
    public KeyCode forwardRunKey = KeyCode.W;
    public KeyCode backRunKey = KeyCode.S;
    public KeyCode leftRunKey = KeyCode.A;
    public KeyCode rightRunKey = KeyCode.D;
    public KeyCode speedKey = KeyCode.LeftShift;

    GroundCheck groundCheck;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }
    
    void FixedUpdate()
    {
        move = Vector3.zero;
        walking = canRun && (Input.GetKey(forwardRunKey) || Input.GetKey(backRunKey) || Input.GetKey(leftRunKey) ||
                             Input.GetKey(rightRunKey));
        
        sakuraAnimator.SetInteger("animation", walking ? 10 :1);
        
        if (walking)
        {
            targetMovingSpeed = Input.GetKey(speedKey) ? runSpeed : speed;
            if (Input.GetKey(forwardRunKey))
            {
                move += Vector3.forward * targetMovingSpeed;
            }
            if (Input.GetKey(backRunKey))
            {
                move += Vector3.back * targetMovingSpeed;
            }

            if (Input.GetKey(leftRunKey))
            {
                move += Vector3.left * targetMovingSpeed;
            }

            if (Input.GetKey(rightRunKey))
            {
                move += Vector3.right * targetMovingSpeed;
            }
            
            rigidbody.velocity = transform.rotation * new Vector3(move.x, rigidbody.velocity.y, move.z);
        }
        else
        {
            if (groundCheck.isGrounded == true) {rigidbody.velocity *= 0.9f;}
         
        }
        GameUtils.SendAnimation(Client.nick,"animation",sakuraAnimator.GetInteger("animation"));
    }
}