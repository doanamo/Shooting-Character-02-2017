using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set smooth weight transition.
        animator.SetFloat(CharacterHash.LookWeight, 1.0f, 0.15f, Time.deltaTime);

        // Apply rotation based on aiming direction.
        Vector3 direction = new Vector3(animator.GetFloat(CharacterHash.AimingX), 0.0f, animator.GetFloat(CharacterHash.AimingZ));

        if(direction != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void OnStateIK(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Create a look at extension in front of the character.
        // Initial vector needs tweaking in order to make a particular animation aim in a correct direction.
        Vector3 lookAtExtension = new Vector3(0.2f, 1.15f, 1.0f);
        lookAtExtension = animator.transform.rotation * lookAtExtension;
        lookAtExtension = lookAtExtension + animator.transform.position;

        // Set inverse kinematic weight and position.
        float lookWeight = animator.GetFloat(CharacterHash.LookWeight);
        animator.SetLookAtWeight(lookWeight, 1.0f, 0.25f, 1.0f, 1.0f);
        animator.SetLookAtPosition(lookAtExtension);
    }
}
