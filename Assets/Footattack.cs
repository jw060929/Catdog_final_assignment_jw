using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footattack : MonoBehaviour
{

    public float bounceForce = 7f;
    public Rigidbody2D marioRb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            marioRb.velocity = new Vector2(marioRb.velocity.x, bounceForce);
            Destroy(other.gameObject);
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
