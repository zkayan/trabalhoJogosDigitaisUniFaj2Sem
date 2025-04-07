using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionSphereScriptFootman : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("ai!");
            Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!");
            Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!"); Debug.Log("ai!");
            Debug.Log("ai!");
            Debug.Log("ai!");

            if ( collision.gameObject.GetComponent<Controller>()._hp - 2 <= 0 )
            {
                Debug.Log("Morreu");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                collision.gameObject.GetComponent<Controller>()._hp -= 2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
