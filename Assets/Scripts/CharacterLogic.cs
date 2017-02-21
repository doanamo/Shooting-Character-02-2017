﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    public CharacterController controller;

    public StateMachine stateMachine;
    public StandingState standingState;
    public MovingState movingState;

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();

        this.stateMachine = new StateMachine();
        this.standingState = new StandingState(this);
        this.movingState = new MovingState(this);

        // Change to the standing state by default.
        this.stateMachine.ChangeState(this.standingState);
    }

    public void HandleMessage<Type>(Type message)
    {
        this.stateMachine.HandleMessage(message);
    }

    private void FixedUpdate()
    {
        this.stateMachine.Update();

        // Apply gravity to the character controller.
        this.controller.Move(Physics.gravity * Time.fixedDeltaTime);
    }
}
