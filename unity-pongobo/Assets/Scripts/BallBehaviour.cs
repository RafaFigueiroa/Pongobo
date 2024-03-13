using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public bool GetRandomBoolean()
    {
        return Random.Range(0, 2) == 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        //movimento inicial
        if (GetRandomBoolean())
        {
            rb.velocity = new Vector2 (speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position, collision.transform.position, collision.GetComponent<BoxCollider2D>().bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            speed *= 1.05f;
            Debug.Log("Velocidade da bola:" + speed);

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;
        }
        if (collision.tag == "Player2")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position, collision.transform.position, collision.GetComponent<BoxCollider2D>().bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            speed *= 1.05f;
            Debug.Log("Velocidade da bola:" + speed);

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 playerPos, float playerHeight)
    {
        return (ballPos.y - playerPos.y) / playerHeight;
    }
}
