using System;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T, TStateType> where T : MonoBehaviour where TStateType : Enum
{
    protected Dictionary<TStateType, StateBase<T>> _stateDictionary = new();
    protected StateBase<T> _currentState;

    public void AddState(TStateType stateType, StateBase<T> state)
    {
        _stateDictionary[stateType] = state;
    }

    public void ChangeState(TStateType newStateType)
    {
        _currentState?.Exit();

        if (_stateDictionary.TryGetValue(newStateType, out var newState))
        {
            _currentState = newState;
            _currentState.Enter();
        }
        else
        {
            Debug.LogWarning($"State {newStateType} not found in FSM.");
        }
    }

    public void Update()
    {
        _currentState?.Execute();
    }
}
