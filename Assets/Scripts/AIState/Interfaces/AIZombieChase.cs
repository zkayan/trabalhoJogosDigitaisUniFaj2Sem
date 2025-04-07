using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZombieChase : IAIZombieState
{
    private static readonly int ChaselId = Animator.StringToHash("Speed");
    private Transform target;
    public AIZombieChase(AIZombieState inAIState)
    {
        _aiState = inAIState;
    }

    public override void OnEnter()
    {
        _nextState = EZombieState.Chase;

        target = GameObject.Find("RPGHeroHP").transform;
        _aiState.agent.speed = _aiState.zombie.runSpeed;
        _aiState.animator.SetFloat(ChaselId, _aiState.agent.speed);
        //_aiState.animator.Play("Attack");
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
        
        
            _aiState.animator.Play("Attack1");
            //_aiState.animator.Play("Attack2");
        


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
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player escaped the chase");
            _nextState = EZombieState.Patrol;
        }
    }
}
