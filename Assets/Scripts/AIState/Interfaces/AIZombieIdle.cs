using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZombieIdle : IAIZombieState
{

    private static readonly int idleId = Animator.StringToHash("Speed");
    private float _deltaTime = 0.0f;
    private float _targetTime = 0.0f;


    public AIZombieIdle(AIZombieState inAIState)
    {
        _aiState = inAIState;
    }

    public override void OnEnter()
    {
        _nextState = EZombieState.Idle;
        _aiState.animator.SetFloat(idleId, 0.0f);
        _deltaTime = 0.0f;
        _targetTime = 1000f;//Random.Range(5.0f, 10.0f);
        _aiState.agent.speed = 0.0f;
    }

    public override void OnExit()
    {
       
    }

    public override void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entrou na area do sensor");

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Foi o jogador");
            Vector3 forward = _aiState.zombie.transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.gameObject.transform.position - _aiState.zombie.transform.position;

            if (Vector3.Dot(forward, toOther) > 0.2f)
            {
                //Debug.Log("Pela frente");
                _nextState = EZombieState.Chaise;
            }    
        }
    }



    public override EZombieState Update()
    {

        if (_deltaTime >= _targetTime)
        {
            _nextState = EZombieState.Patrol;
        }

        _deltaTime += Time.deltaTime;
        
          
        return _nextState;
    }

    internal override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
