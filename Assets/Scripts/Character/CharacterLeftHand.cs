using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeftHand : StateMachineBehaviour
{
    private GameObject leftHandGrip;
    private Vector3 leftHandPosition;
    private Quaternion leftHandRotation;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterLogic character = animator.GetComponent<CharacterLogic>();
        this.leftHandGrip = character.weapon.transform.Find("LeftHandGrip").gameObject;
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Setup inverse kinematic for hands.
        float aimingWeight = animator.GetFloat(CharacterHashes.AimingWeight);

        this.leftHandPosition = this.leftHandGrip.transform.position;
        this.leftHandRotation = this.leftHandGrip.transform.rotation * Quaternion.Euler(0.0f, -90.0f, 180.0f);

        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, aimingWeight);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, this.leftHandRotation);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, aimingWeight);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, this.leftHandPosition);
    }
}
