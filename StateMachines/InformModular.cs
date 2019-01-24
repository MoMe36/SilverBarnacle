using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lateral;

namespace Lateral{

public class InformModular : StateMachineBehaviour {

    public string Information;
    public string Test= "This is the latest";  

     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Call(animator, true); 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Call(animator, false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    // override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    // }


    void Call(Animator animator, bool state)
    {
        animator.gameObject.GetComponent<Modular>().Inform(Information, state);
    }
}

}