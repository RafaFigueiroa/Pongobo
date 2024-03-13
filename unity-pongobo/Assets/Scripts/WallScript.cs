using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();

            otherRigidbody.velocity = new Vector2(otherRigidbody.velocity.x, -otherRigidbody.velocity.y);
        }
    }
}
