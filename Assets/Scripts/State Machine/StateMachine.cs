using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

	public State initialState;
    public State currentState;

    void Awake()
    {
        currentState = initialState;
        currentState.enabled = true;
    }

    protected void BackInitialState()
    {
        ChangeState(initialState);
    }

    public void ChangeState(State newState)
    {
        currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
    }

}
