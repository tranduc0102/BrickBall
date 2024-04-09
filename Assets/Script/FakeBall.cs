using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBall : Ball
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        float Width = (other.collider.bounds.size.x)/2;
        float hitPosition = (transform.position.x - other.transform.position.x) / Width;
        Vector2 hitDirection = new Vector2(hitPosition, -1).normalized;
        if (other.gameObject.CompareTag("Paddle"))
        {
            rb.velocity = new Vector2(hitDirection.x*5f, 5f);
        }
        else
        {
            var transformPosition = rb.transform.position;
            transformPosition.x = hitDirection.x + transformPosition.x;
        }
        
        if (other.gameObject.CompareTag("Dead"))
        {
            gameObject.SetActive(false);
        }
    }
}
