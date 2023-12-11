using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _Damage;
    [SerializeField] private float _MoveDistance;
    [SerializeField] private float _Speed;
    [SerializeField] private int _health;

    private bool movingLeft;
    private float LeftEdge;
    private float RightEdge;

    private void Awake()
    {
        LeftEdge = transform.position.x - _MoveDistance;
        RightEdge = transform.position.x + _MoveDistance;
    }

    private void Update()
    {

        if (movingLeft)
        {
            if (transform.position.x > LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - _Speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < RightEdge)
            {
                transform.position = new Vector3(transform.position.x + _Speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                movingLeft = true;
            }
        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(_Damage);
        }
        else if (collision.CompareTag("Bullet"))
        {
            _health -= 1;
        }
    }
}