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
        _targetTime = 2.0f;//Random.Range(5.0f, 10.0f);
        _aiState.agent.speed = 0.0f;
    }

    public override void OnExit()
    {
       
    }

    public override void OnTriggerEnter(Collider other)
    {
        //Entered sensor area

        if (other.gameObject.tag == "Player")
        {
            Vector3 forward = _aiState.zombie.transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.gameObject.transform.position - _aiState.zombie.transform.position;

            if (Vector3.Dot(forward, toOther) > 0.2f)
            {
                _nextState = EZombieState.Chase;
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

    }
}
