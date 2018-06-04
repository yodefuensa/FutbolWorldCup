using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StMachine : MonoBehaviour {

    public MonoBehaviour initialState;
    public MonoBehaviour currentState;
	
    void Awake()
    {
        currentState = initialState;
        currentState.enabled = true;
    }

    private void BackInitialState()
    {
        ChangeState(initialState);
    }

    public void ChangeState(MonoBehaviour newState)
    {
        currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
    }
}
