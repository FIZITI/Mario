using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMenu : MonoBehaviour
{
    private Rigidbody2D Rb;
    public Animator Animator;
    public float Speed = 10f;
    public int JumpForce = 10;
    public float Horizontal;

    public bool OnGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;

    private Vector3 RespawnPoint;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        RespawnPoint = transform.position;
    }

    void Update()
    {
        Rb.velocity = new Vector2(Speed, Rb.velocity.y);

        
        CheckingGround();
        Animator.SetFloat("moveX", Mathf.Abs(Rb.velocity.x));
    }

    void Jump()
    {
        if (OnGround)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);
        }
    }

    void CheckingGround()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            transform.position = RespawnPoint;
        }
        else if (collision.tag == "JumpOnMenu")
        {
            Jump();
        }
    }
}