using System.Collections;

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
        if(currentState != null)
        {
            if(!currentState.OnExit(state))
                return false;
        }

        if(state != null)
        {
            if(!state.OnEnter(currentState))
                return false;
        }

        currentState = state;
        return true;
    }

    public void HandleMessage<Type>(Type message)
    {
        if(currentState != null)
        {
            currentState.HandleMessage(message);
        }
    }

    public void Update()
    {
        if(currentState != null)
        {
            currentState.OnUpdate();
        }
    }
}
