using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStanding : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set smooth movement fade outtransition.
        animator.SetFloat(CharacterHashes.MovementX, 0.0f, 0.15f, Time.deltaTime);
        animator.SetFloat(CharacterHashes.MovementZ, 0.0f, 0.15f, Time.deltaTime);
    }
}
