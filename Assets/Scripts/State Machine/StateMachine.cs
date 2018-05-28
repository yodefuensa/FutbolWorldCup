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

    public void ChangeState(State newState, bool team, bool sel, bool flyp, int reinicio, float mag)
    {
        Debug.Log(currentState.selector + gameObject.name);
        Debug.Log(sel+ gameObject.name);
        currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
        currentState.selector = sel;
        currentState.equipo = team;
        currentState.flipY = flyp;
        currentState.equipo = team;
        currentState.reinicio = reinicio;
        currentState.magnitud = mag;
    }

}
