using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D Rb;
    public Animator Animator;

    private bool MarioFlip = true;
    public float Speed = 10f;
    public float FastSpeed = 15f;
    private float RealSpeed;
    public int JumpForce = 10;
    public float Horizontal;

    public bool OnGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;

    private Vector3 RespawnPoint;

    void Start()
    {
        RealSpeed = Speed;
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        RespawnPoint = transform.position;
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        Rb.velocity = new Vector2(Horizontal * RealSpeed, Rb.velocity.y);

        Animator.SetFloat("moveX", Mathf.Abs(Horizontal));

        if ((Horizontal > 0 && !MarioFlip) || (Horizontal < 0 && MarioFlip))
        {
            MarioFlip = !MarioFlip;
            transform.Rotate(0, 180, 0);
        }

        Jump();
        CheckingGround();
        SpeedUp();
    }

    void SpeedUp()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RealSpeed = FastSpeed;
        }
        else
        {
            RealSpeed = Speed;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            transform.position = RespawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            RespawnPoint = transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }
}