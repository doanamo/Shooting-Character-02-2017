using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeftHand : StateMachineBehaviour
{
    private GameObject leftHandGrip;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterLogic character = animator.GetComponent<CharacterLogic>();
        this.leftHandGrip = character.weapon.transform.Find("LeftHandGrip").gameObject;
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        float leftHandWeight = animator.GetFloat(CharacterHashes.LeftHandWeight);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, this.leftHandGrip.transform.position);

        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, this.leftHandGrip.transform.rotation * Quaternion.Euler(0.0f, -90.0f, 180.0f));
    }
}
