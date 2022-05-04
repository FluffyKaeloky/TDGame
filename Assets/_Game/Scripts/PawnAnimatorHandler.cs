using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PawnAnimatorHandler : MonoBehaviour
{
    RichAI richAI;
    public Animator animator;

    private void Start()
    {
        richAI = GetComponent<RichAI>();
    }


    private void Update()
    {
        animator.SetBool("move", richAI.velocity.magnitude > 0.1f);
    }
}
