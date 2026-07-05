using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public Sprite Usedsprite;
    public GameObject Item;
    public Transform Itemspawn;

    private bool used = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (used) 
            return;
        if (!collision.collider.CompareTag("Player"))
            return;

        ContactPoint2D contact = collision.contacts[0];
        if (contact.normal.y > -0f)
        {
            HitFromBelow();
        }
    }

    void HitFromBelow()
    {
        used = true;
        GetComponent<SpriteRenderer>().sprite = Usedsprite;

        Vector3 pos = (Itemspawn != null) ? Itemspawn.position : transform.position + Vector3.up;
        if (Item != null)
        {
            Instantiate(Item, pos, Quaternion.identity);
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