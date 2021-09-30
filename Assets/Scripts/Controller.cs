using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private static readonly int _speedID = Animator.StringToHash("Speed");
    private CharacterController _characterController = null;
    private Animator _animator = null;

    private Vector2 _direction = Vector2.zero;

    public float speed = 0.01f;

    [Range(0.0f, 1.0f)]
    public float normalizedSpeed = 0.0f;

    public float maxSpeed = 5;

    public AudioClip jump1;
    public AudioClip swordAttack1;
    public AudioSource audioSource;

    public CharacterController characterController = null;
   
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().PlayOneShot(jump1, 0.25f);
        }
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            GetComponent<AudioSource>().PlayOneShot(swordAttack1, 0.3f);
            characterController.Move(new Vector3(0, 0, 0));
            if (Random.Range(0.0f, 1.0f) <= 0.5f) {
                _animator.Play("SwordAttack1Anim");
            } else
            {
                _animator.Play("SwordAttack2Anim");
            }
        }
        if (Input.GetMouseButton(1))
        {
            _animator.Play("ShieldAnim");
        }

        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _direction.Normalize();

        Vector3 movement = new Vector3(_direction.x, 0,  _direction.y) * speed * Time.deltaTime;
        //movement = Camera.main.transform.TransformDirection(movement);
        movement = transform.TransformDirection(movement);
        if (!Input.GetMouseButton(1)) _characterController.Move(movement);

        normalizedSpeed = _direction.magnitude;
        _animator.SetFloat(_speedID, normalizedSpeed);

        
    }

    private void FixedUpdate()
    {
        characterController.SimpleMove(Vector3.forward * 0);
    }

    
}


