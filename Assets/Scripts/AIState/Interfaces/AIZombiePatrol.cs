using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZombiePatrol : IAIZombieState
{
    private static readonly int patrolId = Animator.StringToHash("Speed");

    public AIZombiePatrol(AIZombieState inAIState)
    {
        _aiState = inAIState;
    }

    public override void OnEnter()
    {
        _nextState = EZombieState.Patrol;
        _aiState.agent.speed = _aiState.zombie.walkSpeed;
        _aiState.animator.SetFloat(patrolId, _aiState.agent.speed);
        _aiState.agent.SetDestination(_aiState.zombie.GetRandomWaypoint());
        
    }

    public override void OnExit()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 forward = _aiState.zombie.transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.gameObject.transform.position - _aiState.zombie.transform.position;

            if (Vector3.Dot(forward, toOther) < 0.2f)
            {
                _nextState = EZombieState.Chaise;
            }
        }
    }

    public override EZombieState Update()
    {
        if (Vector3.Distance(_aiState.agent.destination, 
            _aiState.zombie.transform.position) > 0.5f)
            return EZombieState.Idle;

        return _nextState;
    }

    internal override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
