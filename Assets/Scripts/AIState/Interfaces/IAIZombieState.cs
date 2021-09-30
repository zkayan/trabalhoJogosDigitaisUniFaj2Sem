using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAIZombieState 
{
    protected EZombieState _nextState = EZombieState.Idle;
    protected AIZombieState _aiState = null;
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract EZombieState Update();
    public abstract void OnTriggerEnter(Collider other);
    internal abstract void OnTriggerExit(Collider other);
}
