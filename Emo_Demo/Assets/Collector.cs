using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public float moveSpeed;
    public float scaleSpeed;
    public GameObject collectTargetPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")&&collision.GetComponent<Drag>().dragging==true) 
        {
            GameObject x = collision.gameObject;
            x.GetComponent<CircleCollider2D>().enabled = false;
            x.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            x.GetComponent<RandomMove>().enabled = false;
            x.GetComponent<BallCollect>().target = collectTargetPos;
            x.GetComponent<BallCollect>().moveSpeed = moveSpeed;
            x.GetComponent<BallCollect>().scaleSpeed = scaleSpeed;
            x.transform.SetParent(transform.parent);
            x.GetComponent<Drag>().enabled = false;
            x.GetComponent<BallCollect>().enabled = true;
        }

    }       
}
