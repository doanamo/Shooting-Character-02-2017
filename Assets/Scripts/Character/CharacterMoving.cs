using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Apply rotation based on movement direction.
        Vector3 direction = new Vector3(animator.GetFloat(CharacterHash.MovementX), 0.0f, animator.GetFloat(CharacterHash.MovementZ));

        if(direction != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
