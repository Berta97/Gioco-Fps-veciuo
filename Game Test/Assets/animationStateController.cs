using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash;
    int IsRunningHash;
    int IsJumpingHash;
    int IsRunjumpingHash;
    int IsPickingHash;
    int IsRetringHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
        IsJumpingHash = Animator.StringToHash("IsJumping");
        IsRunjumpingHash = Animator.StringToHash("IsRunjumping");
        IsPickingHash = Animator.StringToHash("IsPicking");
        IsRetringHash = Animator.StringToHash("IsRetring");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool IsJumping = animator.GetBool(IsJumpingHash);
        bool IsRunjumping = animator.GetBool(IsRunjumpingHash);
        bool IsPicking = animator.GetBool(IsPickingHash);
        bool IsRetring = animator.GetBool(IsRetringHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool runjumpPressed = Input.GetKey("space");
        bool pickingPressed = Input.GetKey("e");
        bool retroPressed = Input.GetKey("s");


        if (!IsWalking && forwardPressed )
        {
            animator.SetBool(IsWalkingHash, true);
        }
        if(IsWalking && !forwardPressed)
            {
            animator.SetBool(IsWalkingHash, false);
        }

        //running
        if (!IsRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(IsRunningHash, true);
        }
        if (IsRunning && (!forwardPressed || !runPressed ))
        {
            animator.SetBool(IsRunningHash, false);
        }

        //jumping
        if (!IsJumping && jumpPressed)
        {
            animator.SetBool(IsJumpingHash, true);
        }
        if (IsJumping && !jumpPressed)
        {
            animator.SetBool(IsJumpingHash, false);
        }
       
        //runjumping
        if (!IsRunjumping && (jumpPressed && runPressed))
        {
            animator.SetBool(IsRunjumpingHash, true);
        }
        if (IsRunjumping && (!jumpPressed || !runPressed))
        {
            animator.SetBool(IsRunjumpingHash, false);
        }
       
        //picking
        if (!IsPicking && pickingPressed)
        {
            animator.SetBool(IsPickingHash, true);
        }
        if (IsPicking && !pickingPressed)
        {
            animator.SetBool(IsPickingHash, false);
        }
       
        //retro
        if (!IsRetring && retroPressed)
        {
            animator.SetBool(IsRetringHash, true);
        }
        if (IsRetring && !retroPressed)
        {
            animator.SetBool(IsRetringHash, false);
        }
    }
}
