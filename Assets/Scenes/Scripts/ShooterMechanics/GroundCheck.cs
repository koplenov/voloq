using System;
using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    [Tooltip("Whether this transform is grounded now.")]
    public bool isGrounded { private set; get; } = true;

    /// <summary>
    /// Called when the ground is touched again.
    /// </summary>
    ///
    [SerializeField] private Animator animator;
    public event System.Action Grounded;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Grounded?.Invoke();
        isGrounded = true;
        animator.SetInteger("jump",0);
        animator.SetInteger("animation", 1);
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
        animator.SetInteger("jump",1);
        animator.SetInteger("animation", 13);
    }

   
}
