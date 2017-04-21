using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Hold the right hand on the weapon if running.
        if(animator.GetBool(CharacterHashes.Running))
        {
            animator.SetFloat(CharacterHashes.LeftHandWeight, 0.8f, 0.1f, Time.deltaTime);
        }

        // Calculate desired direction and rotation factor.
        Vector3 desiredDirection = new Vector3(animator.GetFloat(CharacterHashes.MovementX), 0.0f, animator.GetFloat(CharacterHashes.MovementZ));

        float degreesDifference = Vector3.Angle(animator.transform.forward, desiredDirection);
        float rotationFactor = 6.0f * Mathf.Clamp(degreesDifference / 40.0f, 0.1f, 1.0f);

        // Apply rotation based on calculated direction.
        Vector3 calculatedDirection = Vector3.RotateTowards(animator.transform.forward, desiredDirection, rotationFactor * Time.deltaTime, 0.0f);

        if(calculatedDirection != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.LookRotation(calculatedDirection);
        }
    }
}
