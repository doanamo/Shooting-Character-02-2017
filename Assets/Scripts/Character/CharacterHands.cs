using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHands : StateMachineBehaviour
{
    private GameObject leftHandGrip;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterLogic character = animator.GetComponent<CharacterLogic>();
        this.leftHandGrip = character.weapon.transform.Find("LeftHandGrip").gameObject;
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if(layerIndex == animator.GetLayerIndex("Right Hand"))
        {
            float aimingWeight = animator.GetFloat(CharacterHashes.AimingWeight);

            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, aimingWeight);
            animator.SetIKRotation(AvatarIKGoal.RightHand, animator.transform.rotation * Quaternion.Euler(0.0f, 0.0f, -90.0f));
        }
        else
        if(layerIndex == animator.GetLayerIndex("Left Hand"))
        {
            float leftHandWeight = animator.GetFloat(CharacterHashes.LeftHandWeight);

            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, this.leftHandGrip.transform.position);

            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, this.leftHandGrip.transform.rotation * Quaternion.Euler(0.0f, -90.0f, 180.0f));
        }
    }
}
