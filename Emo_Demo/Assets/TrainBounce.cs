using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBounce : MonoBehaviour
{
    public float bounceForce;
    private void aaa(Collider2D collision)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector2 dir;
            dir = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * bounceForce);
        }
    }
}
