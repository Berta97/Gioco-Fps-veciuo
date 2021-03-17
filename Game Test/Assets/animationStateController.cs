using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking")
    }

    // Update is called once per frame
    void Update()
    {
        bool IsRunning = animator.GetBool("IsRunning")
        bool IsWalking = animator.GetBool(isWalkingHash)


        if (Input.GetKey("w"))
        {
            animator.SetBool("IsWalking", true);
        }
        if(!Input.GetKey("w"))
            {
            animator.SetBool("IsWalking", false);
        }
    }
}
