using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSphereScript : MonoBehaviour
{
    public GameObject objectPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        objectPosition = GameObject.Find("PlayerCollisionSphere");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectPosition.transform.position.x, objectPosition.transform.position.y, objectPosition.transform.position.z);
    }
    
}
