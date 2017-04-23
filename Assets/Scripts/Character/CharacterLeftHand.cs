using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeftHand : StateMachineBehaviour
{
    private CharacterLogic character;
    private GameObject leftHandGrip;

    public float desiredWeight = 0.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(this.character == null)
        {
            this.character = animator.GetComponent<CharacterLogic>();
        }

        if(this.leftHandGrip == null)
        {
            this.leftHandGrip = this.character.weapon.transform.Find("LeftHandGrip").gameObject;
        }

        this.character.desiredLeftHandWeight = this.desiredWeight;
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float leftHandWeight = animator.GetFloat(CharacterHashes.LeftHandWeight);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, this.leftHandGrip.transform.position);

        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, this.leftHandGrip.transform.rotation * Quaternion.Euler(0.0f, -90.0f, 180.0f));
    }
}
