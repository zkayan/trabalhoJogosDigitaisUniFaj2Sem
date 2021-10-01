using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZombieChaise : IAIZombieState
{
    private static readonly int ChaicelId = Animator.StringToHash("Speed");
    private Transform target;
    public AIZombieChaise(AIZombieState inAIState)
    {
        _aiState = inAIState;
    }

    public override void OnEnter()
    {
        _nextState = EZombieState.Chaise;

        target = GameObject.Find("RPGHeroHP").transform;
        _aiState.agent.speed = _aiState.zombie.runSpeed;
        _aiState.animator.SetFloat(ChaicelId, _aiState.agent.speed);
        _aiState.agent.SetDestination(target.position);
    }

    public override void OnExit()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public override EZombieState Update()
    {
        if (Vector3.Distance(_aiState.agent.destination,
            _aiState.zombie.transform.position) > 1.0f)
        {
            _aiState.agent.SetDestination(target.position);
        }
            //Debug.Log(_aiState.agent.destination);
        

        return _nextState;
    }

    internal override void OnTriggerExit(Collider other)
    {
        Debug.Log("Cheguei aqui");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Escapou da perseguição");
            _nextState = EZombieState.Patrol;
        }
    }
}
