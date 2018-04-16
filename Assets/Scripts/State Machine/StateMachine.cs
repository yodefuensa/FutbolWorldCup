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
       //ChangeState(initialState);
    }

    public void ChangeState(State newState, bool team, bool sel, bool flyp, int reinicio)
    {
        //currentState.enabled = false;
        //currentState = newState;
        //currentState.enabled = true;
        currentState.selector = sel;
        currentState.equipo = team;
        currentState.flipY = flyp;
        newState.selector =sel;
        newState.equipo = team;
        newState.flipY = flyp;
        currentState.selector=false;
        currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
        currentState.reinicio = reinicio;

    }

}
