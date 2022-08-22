using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    [SerializeField] private Animator animator;
    
    [Header("AXIS")]
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    
    [Header("ATRIBUTES")]
    [SerializeField] private float walkSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0) _sp.flipX = true;
        else if (horizontal < 0) _sp.flipX = false;

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(horizontal * walkSpeed, vertical * walkSpeed);
    }
}
