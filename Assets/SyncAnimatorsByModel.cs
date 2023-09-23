using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAnimatorsByModel : MonoBehaviour
{
    [SerializeField] private Animator modelAnimator;
    private Animator animator;

    private string animationPropName = "animation";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetInteger(animationPropName,modelAnimator.GetInteger(animationPropName));
    }
}
