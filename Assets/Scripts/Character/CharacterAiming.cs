using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : StateMachineBehaviour
{
    private readonly int HashAimingX = Animator.StringToHash("Aiming X");
    private readonly int HashAimingZ = Animator.StringToHash("Aiming Z");

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Apply rotation based on aiming direction.
        Vector3 direction = new Vector3(animator.GetFloat(HashAimingX), 0.0f, animator.GetFloat(HashAimingZ));

        if(direction != Vector3.zero)
        {
            animator.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
