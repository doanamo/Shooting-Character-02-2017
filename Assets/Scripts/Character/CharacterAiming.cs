using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set smooth weight transition.
        if(!animator.IsInTransition(layerIndex) || (animator.IsInTransition(layerIndex)
            && animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash != stateInfo.fullPathHash))
        {
            animator.SetFloat(CharacterHashes.AimingWeight, 1.0f, 0.4f, Time.deltaTime);
            animator.SetFloat(CharacterHashes.LeftHandWeight, 0.8f, 0.04f, Time.deltaTime);
        }

        // Calculate desired direction and rotation factor.
        Vector3 desiredDirection = new Vector3(animator.GetFloat(CharacterHashes.AimingX), 0.0f, animator.GetFloat(CharacterHashes.AimingZ));

        float degreesDifference = Vector3.Angle(animator.transform.forward, desiredDirection);
        float rotationFactor = 6.0f * Mathf.Clamp(degreesDifference / 40.0f, 0.1f, 1.0f);

        // Apply rotation based on calculated direction.
        Vector3 calculatedDirection = Vector3.RotateTowards(animator.transform.forward, desiredDirection, rotationFactor * Time.deltaTime, 0.0f);

        if(calculatedDirection != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.LookRotation(calculatedDirection);
        }

        // Calculate rotation for strafing direction in the character's local space.
        Vector3 cameraForward = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z).normalized;
        Vector3 characterForward = new Vector3(animator.transform.forward.x, 0.0f, animator.transform.forward.z).normalized;

        Quaternion rotationToLocal = Quaternion.FromToRotation(characterForward, cameraForward);

        // Set strafing paremeter for movement direction relative to camera.
        Vector3 movementDirection = new Vector3(animator.GetFloat(CharacterHashes.MovementX), 0.0f, animator.GetFloat(CharacterHashes.MovementZ));
        Vector3 strafingDirection = rotationToLocal * movementDirection;

        animator.SetFloat(CharacterHashes.StrafingX, strafingDirection.x, 0.15f, Time.deltaTime);
        animator.SetFloat(CharacterHashes.StrafingZ, strafingDirection.z, 0.15f, Time.deltaTime);
    }
}
