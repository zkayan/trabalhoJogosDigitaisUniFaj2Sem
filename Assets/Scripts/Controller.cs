using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private static readonly int _speedID = Animator.StringToHash("Speed");
    private CharacterController _characterController = null;
    private Animator _animator = null;
    private int _maxHp = 500;
    public int _hp;
    public Lifebar lifebar;

    private Vector2 _direction = Vector2.zero;

    public float speed = 0.01f;

    [Range(0.0f, 1.0f)]
    public float normalizedSpeed = 0.0f;

    public float maxSpeed = 5;

    public AudioClip jump1;
    public AudioClip swordAttack1;
    public AudioSource audioSource;

    public CharacterController characterController = null;

    public GameObject end;


    private bool _isPlayerDefending = false;

    private void Awake()
    {
        _hp = _maxHp;
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MakePlayerTakeDamage(int damage)
    {
        if (_hp - damage <= 0 && !(Input.GetMouseButton(1)))
        {
            lifebar.UpdateLifebar(0);
            Debug.Log("Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            _hp -= damage;
            lifebar.UpdateLifebar(_hp);
        }
    }

    public int CurrentHp()
    {
        return _hp;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)) _isPlayerDefending = true;
        if (Input.GetMouseButtonUp(1)) _isPlayerDefending = false;

        if (Vector3.Distance(gameObject.transform.position,
            end.transform.position) < 2.0f)
        {
            SceneManager.LoadScene(2);
        }

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

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!_isPlayerDefending)
            {
                if (_hp - 20 <= 0)
                {
                    lifebar.UpdateLifebar(0);
                    Debug.Log("Died");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else
                {
                    _hp -= 20;
                    lifebar.UpdateLifebar(_hp);
                }
            }
            
        }
    }

    private void FixedUpdate()
    {
        characterController.SimpleMove(Vector3.forward * 0);
    }

    
}


