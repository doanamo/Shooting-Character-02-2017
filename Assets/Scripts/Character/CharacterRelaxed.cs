using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRelaxed : StateMachineBehaviour
{
    private CharacterLogic character;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(this.character == null)
        {
            this.character = animator.GetComponent<CharacterLogic>();
        }

        this.character.desiredAimingWeight = 0.0f;
    }
}
