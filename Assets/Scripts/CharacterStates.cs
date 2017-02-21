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
        this.controller = character.controller;
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
            // Move the character in a direction.
            Vector3 motion = Vector3.zero;

            if(this.controller.isGrounded)
            {
                motion = this.command.direction;
                motion *= 6.0f;
            }

            this.controller.Move(motion * Time.fixedDeltaTime);
            this.receivedCommand = false;
        }
        else
        {
            // Change to the standing state once velocity reaches zero.
            if(this.controller.isGrounded && this.controller.velocity.magnitude <= Mathf.Epsilon)
            {
                if(this.character.stateMachine.ChangeState(this.character.standingState))
                    return;
            }
        }
    }
}
