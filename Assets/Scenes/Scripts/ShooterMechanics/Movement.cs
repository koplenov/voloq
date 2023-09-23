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

    private bool isRunning = false;
    [SerializeField] private GroundCheck groundCheck;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        move = Vector3.zero;
        walking = canRun && (Input.GetKey(forwardRunKey) || Input.GetKey(backRunKey) || Input.GetKey(leftRunKey) ||
                             Input.GetKey(rightRunKey));


        
        if (walking)
        {
            isRunning = Input.GetKey(speedKey);
            if (isRunning)
            {
                targetMovingSpeed = runSpeed;
            }
            else
            {
                targetMovingSpeed = speed;
            }
            if (Input.GetKey(forwardRunKey))
            {
                move += Vector3.forward * targetMovingSpeed;
                
                if (groundCheck.isGrounded)
                {
                    sakuraAnimator.SetInteger("animation", isRunning? 43 : 10);
                }
                else
                {
                    sakuraAnimator.SetInteger("animation", 13);
                }
                
                
            }
            if (Input.GetKey(backRunKey))
            {
                move += Vector3.back * targetMovingSpeed;
                sakuraAnimator.SetInteger("animation", isRunning? 45 : 41);
                if (groundCheck.isGrounded)
                {
                    sakuraAnimator.SetInteger("animation", isRunning? 43 : 10);
                }
                else
                {
                    sakuraAnimator.SetInteger("animation", 13);
                }
            }

            if (Input.GetKey(leftRunKey))
            {
                move += Vector3.left * targetMovingSpeed;
                sakuraAnimator.SetInteger("animation", isRunning? 42 :11);
                if (groundCheck.isGrounded)
                {
                    sakuraAnimator.SetInteger("animation", isRunning? 43 : 10);
                }
                else
                {
                    sakuraAnimator.SetInteger("animation", 13);
                }
            }

            if (Input.GetKey(rightRunKey))
            {
                move += Vector3.right * targetMovingSpeed;
                sakuraAnimator.SetInteger("animation", isRunning?44:12);
                if (groundCheck.isGrounded)
                {
                    sakuraAnimator.SetInteger("animation", isRunning? 43 : 10);
                }
                else
                {
                    sakuraAnimator.SetInteger("animation", 13);
                }
            }
            
            rigidbody.velocity = transform.rotation * new Vector3(move.x, rigidbody.velocity.y, move.z);
        }
        else
        {
            
            sakuraAnimator.SetInteger("animation",  groundCheck.isGrounded ? 1 : 13);
            if (groundCheck.isGrounded == true) {rigidbody.velocity *= 0.9f;}
         
        }
        GameUtils.SendAnimation(Client.nick,"animation",sakuraAnimator.GetInteger("animation"));
        GameUtils.SendAnimation(Client.nick,"jump",sakuraAnimator.GetInteger("jump"));
    }
}