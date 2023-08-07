using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : CharacterStateMachine
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            state = CharacterState.Idle;
        }
        if (Input.GetButtonDown("Jump") && movement.CanJump)
        {
            movement.Jump(movement.JumpForce);
            state = CharacterState.Jump;
        }

        if (movement.Rigidbody.velocity.y < -0.1f)
        {
            state = CharacterState.Fall;
        }
        charCtrl.Animator.SetInteger("State", (int)state);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}