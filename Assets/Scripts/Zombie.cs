using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float hitPoint = 100;
    public Transform deathParticlesPrefab;
    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;

    private static Transform waypoints = null;
    [SerializeField]
    private AIZombieState stateMachine = null;

    public NavMeshAgent agent = null;
    public Animator animator = null;

    public string waypointTarget = "Waypoints";



    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.Find(waypointTarget).transform;
        //agent.SetDestination(GetRandomWaypoint());
        stateMachine = new AIZombieState(this);
        stateMachine.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public Vector3 GetRandomWaypoint()
    {
        int index = Random.Range(0, waypoints.childCount);
        return waypoints.GetChild(index).position;            
    }

    private void OnTriggerStay(Collider other)
    {
        stateMachine.OnTriggerEnter(other);

        if (other.tag == "CollisionSphere" && Input.GetMouseButtonDown(0))
        {
            takeDamage(25.0f);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Cheguei aqui");
        stateMachine.OnTriggerExit(other);
    }

    public void takeDamage(float damage)
    {
        Debug.Log("cheguei aqui...");

        hitPoint -= damage;
        if (hitPoint <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathParticlesPrefab, this.transform.position, this.transform.rotation);
        }
  
    }

}
