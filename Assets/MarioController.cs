using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float Movespeed;
    public float Jumpforce;
    public float Groundcheck;
    public LayerMask Groundlayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    public bool isBig = false;


    public void Grow()
    {
        if (isBig)
            return;
        isBig = true;
        transform.localScale = new Vector3(1.5f, 1.5f, 1f);
    }

    public void Shrink()
    {
        isBig = false;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void Damage()
    {
        if (isBig)
        {
            Shrink();
        }
        else
        {
            ClearOver over = FindObjectOfType<ClearOver>();
            over.Gameover();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Groundcheck, Groundlayer);
        isGrounded = hit.collider != null;

        float xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDir * Movespeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumpforce);
        }
    }
}