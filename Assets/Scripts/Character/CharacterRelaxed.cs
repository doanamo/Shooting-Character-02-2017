using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRelaxed : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Apply smooth weight transition.
        animator.SetFloat(CharacterHashes.AimingWeight, 0.0f, 0.1f, Time.deltaTime);
        animator.SetFloat(CharacterHashes.LeftHandWeight, 0.4f, 0.1f, Time.deltaTime);
    }
}
