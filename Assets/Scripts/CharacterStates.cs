using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : State
{
    private CharacterLogic character;

    public StandingState(CharacterLogic character)
    {
        this.character = character;
    }

    public override void HandleMessage<Type>(Type message)
    {
        if(typeof(Type) == typeof(MoveCommand))
        {
            // Change to the movement state and pass it received move command.
            if(this.character.stateMachine.ChangeState(this.character.movingState))
            {
                this.character.movingState.HandleMessage(message);
                return;
            }
        }
    }

    public override void OnUpdate()
    {
    }
}

public class MovingState : State
{
    private CharacterLogic character;
    private CharacterController controller;

    private MoveCommand command;
    private bool receivedCommand;

    public MovingState(CharacterLogic character)
    {
        this.character = character;
        this.controller = character.GetComponent<CharacterController>();
    }

    public override void HandleMessage<Type>(Type message)
    {
        if(typeof(Type) == typeof(MoveCommand))
        {
            this.command = message as MoveCommand;
            this.receivedCommand = true;
        }
    }

    public override void OnUpdate() 
    {
        if(receivedCommand)
        {
            // Accelerate the character's rigidbody.
            this.controller.SimpleMove(this.command.direction * 6.0f);
            this.receivedCommand = false;
        }
        else
        {
            // Deaccelerate the character's rigidbody.
            //float velocityMagnitude = Mathf.Min(this.rigidbody.velocity.magnitude, 10.0f * Time.fixedDeltaTime);
            //this.rigidbody.AddForce(-this.rigidbody.velocity.normalized * velocityMagnitude, ForceMode.VelocityChange);

            // Change to the standing state once velocity reaches zero.
            if(this.controller.velocity.magnitude <= Mathf.Epsilon)
            {
                if(this.character.stateMachine.ChangeState(this.character.standingState))
                    return;
            }
        }
    }
}
