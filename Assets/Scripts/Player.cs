using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D Rb;
    public Animator Animator;
    private bool MarioFlip = true;
    public float Speed = 10f;
    public int JumpForce = 10;
    public float Horizontal;
    public bool OnGround = false;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);

        Animator.SetFloat("moveX", Mathf.Abs(Horizontal));

        if ((Horizontal > 0 && !MarioFlip) || (Horizontal < 0 && MarioFlip))
        {
            transform.localScale *= new Vector2(-1, 1);
            MarioFlip = !MarioFlip;
        }

        Jump();
        CheckingGround();
    }

    void Jump()
    {
        if (OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);
        }
    }

    void CheckingGround()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
    }
}