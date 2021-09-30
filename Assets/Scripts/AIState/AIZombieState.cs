using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EZombieState { Idle, Patrol, Chaise }

[System.Serializable]
public class AIZombieState 
{
    [SerializeField]
    private EZombieState _currentState = EZombieState.Idle;
    [SerializeField]
    private int _currentIndex = 0;

    private IAIZombieState[] _states = null;
    public Animator animator = null;
    public NavMeshAgent agent = null;
    public Zombie zombie = null;


    public AIZombieState(Zombie zombie)
    {
        animator = zombie.animator;
        agent = zombie.agent;
        this.zombie = zombie;
        _states = new IAIZombieState[]
        { new AIZombieIdle(this), new AIZombiePatrol(this), new AIZombieChaise(this) };
    }

    public void Initialize()
    {
        _states[_currentIndex].OnEnter();
    }


    public void Update()
    {
        EZombieState nextState = _states[_currentIndex].Update();
        if (nextState != _currentState)
            ChangeState(nextState);
    }

    public void ChangeState(EZombieState newState)
    {
        int nextStateIndex = (int)newState;
        _states[_currentIndex].OnExit();
        _states[nextStateIndex].OnEnter();
        _currentIndex = nextStateIndex;
        _currentState = (EZombieState)_currentIndex;
    }

    public void OnTriggerEnter(Collider other)
    {
        _states[_currentIndex].OnTriggerEnter(other);
    }

    public void OnTriggerExit(Collider other)
    {
        _states[_currentIndex].OnTriggerExit(other);
    }
}
