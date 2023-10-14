using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D Rb;
    private bool MarioFlip = true;
    public float Speed = 10f;
    public float JumpForce = 10f;
    public float Horizontal;
    public float MarioJump;
    public Animator Animator;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        MarioJump = Input.GetAxis("Jump");

        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
        Rb.velocity = new Vector2(Rb.velocity.x, MarioJump * JumpForce);

        Animator.SetFloat("moveX", Mathf.Abs(Horizontal));
        Animator.SetFloat("moveY", Mathf.Abs(MarioJump));

        if ((Horizontal > 0 && !MarioFlip) || (Horizontal < 0 && MarioFlip))
        {
            transform.localScale *= new Vector2(-1, 1);
            MarioFlip = !MarioFlip;
        }
    }
}