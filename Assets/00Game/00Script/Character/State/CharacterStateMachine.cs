using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    protected CharacterController charCtrl;
    protected CharacterMovement movement;
    protected CharacterState state;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!charCtrl)
        {
            charCtrl = animator.transform.parent.GetComponent<CharacterController>();
            movement = charCtrl.Movement;
        }
        state = (CharacterState)charCtrl.Animator.GetInteger("State");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    virtual public void Run()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            state = CharacterState.Run;
        }
    }

    virtual public void Jump()
    {
        if (Input.GetButtonDown("Jump") && movement.CanJump && movement.OnGround)
        {
            movement.Jump(movement.JumpForce);
            state = CharacterState.Jump;
        }
    }
    virtual public void Fall()
    {
        if (movement.Rigidbody.velocity.y < -0.01f)
        {
            state = CharacterState.Fall;
        }
    }
    virtual public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            state = CharacterState.Roll;
        }
    }
    virtual public void Defend()
    {
        if (Input.GetKey(KeyCode.S))
        {
            state = CharacterState.Defend;
        }
    }
    virtual public void Idle()
    {
        charCtrl.Animator.SetInteger("State", (int)CharacterState.Idle);
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
