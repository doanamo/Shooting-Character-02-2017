using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRightHand : StateMachineBehaviour
{
    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        float aimingWeight = animator.GetFloat(CharacterHashes.AimingWeight);

        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, aimingWeight);
        animator.SetIKRotation(AvatarIKGoal.RightHand, animator.transform.rotation * Quaternion.Euler(0.0f, 0.0f, -90.0f));
    }
}
