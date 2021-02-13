using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingGun1 : StateMachineBehaviour
{
    public float rotationSpeed = 30f;

    private Transform _gun;
    private Transform _player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Gun1 started aiming...");
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _gun = animator.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float rotAngle = _gun.eulerAngles.z;
        if (rotAngle > 180f)
            rotAngle = -(360f - rotAngle);

        float angle = Vector2.SignedAngle(Vector2.down, new Vector2(_player.position.x - _gun.position.x, _player.position.y - _gun.position.y));
        angle -= rotAngle;

        _gun.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime * Mathf.Sign(angle)));
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
