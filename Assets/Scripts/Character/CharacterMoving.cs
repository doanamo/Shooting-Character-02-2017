using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : StateMachineBehaviour
{
    private readonly int HashMovementX = Animator.StringToHash("Movement X");
    private readonly int HashMovementZ = Animator.StringToHash("Movement Z");

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Apply rotation based on movement direction.
        Vector3 direction = new Vector3(animator.GetFloat(HashMovementX), 0.0f, animator.GetFloat(HashMovementZ));

        if(direction != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.LookRotation(direction);
        }

        // Apply built in root motion.
        animator.ApplyBuiltinRootMotion();
    }
}
