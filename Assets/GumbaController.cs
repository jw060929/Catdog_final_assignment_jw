using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbaController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private int direction = -1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var c in collision.contacts)
        {
            if (Mathf.Abs(c.normal.x) > 0.5f)
            {
                direction *= -1;
                break;
            }
        }
        if (collision.collider.CompareTag("Player"))
        {
            MarioController mario = collision.collider.GetComponent<MarioController>();
            if (mario != null)
            {
                mario.Damage();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}
