using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSphereScript : MonoBehaviour
{
    GameObject objectPosition = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        objectPosition = GameObject.Find("CollisionSpherePos");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectPosition.transform.position.x, objectPosition.transform.position.y, objectPosition.transform.position.z);
    }
    
}
