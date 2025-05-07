using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public bool isInteracting = false;

    [SerializeField] float _speed = 5f;
    [SerializeField] PlayerAnimation playerAnimation;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    private void OnMove(InputValue input)
    {
       Vector2 vector2 = input.Get<Vector2>();
       Movement(vector2);
    }

    private void Movement(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x, direction.y) * _speed;
        
        playerAnimation.Ani_Run(_rigidbody.velocity);

    }

    private void OnInteract(InputValue input)
    {
        if (input.isPressed)
        {
            isInteracting = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
