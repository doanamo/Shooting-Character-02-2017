using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRelaxed : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set smooth weight transition.
        animator.SetFloat(CharacterHash.LookWeight, 0.0f, 0.2f, Time.deltaTime);
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        /*
        // Set inverse kinematic weight and position.
        float lookWeight = animator.GetFloat(CharacterHash.LookWeight);
        animator.SetLookAtWeight(lookWeight, 1.0f, 0.25f, 1.0f, 1.0f);
        */
    }
}
