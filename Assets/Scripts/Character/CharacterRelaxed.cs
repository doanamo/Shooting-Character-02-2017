using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRelaxed : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Apply smooth weight transition.
        animator.SetFloat(CharacterHashes.AimingWeight, 0.0f, 0.01f, Time.deltaTime);
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Set inverse kinematic weight.
        float aimingWeight = animator.GetFloat(CharacterHashes.AimingWeight);

        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, aimingWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, aimingWeight);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, aimingWeight);
    }
}
