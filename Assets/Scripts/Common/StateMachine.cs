using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual bool OnEnter(State previousState)
    {
        return true;
    }

    public virtual void HandleMessage<Type>(Type message)
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual bool OnExit(State nextState)
    {
        return true;
    }
}

public class StateMachine
{
    public State currentState
    {
        get; private set;
    }

    public bool ChangeState(State state)
    {
        if(this.currentState != null)
        {
            if(!this.currentState.OnExit(state))
                return false;
        }

        if(state != null)
        {
            if(!state.OnEnter(this.currentState))
                return false;
        }

        this.currentState = state;
        return true;
    }

    public void HandleMessage<Type>(Type message)
    {
        if(this.currentState != null)
        {
            this.currentState.HandleMessage(message);
        }
    }

    public void Update()
    {
        if(this.currentState != null)
        {
            this.currentState.OnUpdate();
        }
    }
}
