using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase<T> : IState where T : MonoBehaviour
{
    protected readonly T _owner;

    public StateBase(T owner)
    {
        _owner = owner;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}