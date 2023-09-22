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
    public event System.Action Grounded;
    
    
    private void OnTriggerEnter(Collider other)
    {
        Grounded?.Invoke();
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

   
}
