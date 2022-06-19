using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject collectTargetPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            GameObject x = collision.gameObject;
            x.GetComponent<RandomMove>().enabled = false;
            x.GetComponent<BallCollect>().targetpos = collectTargetPos.transform.position;
            x.GetComponent<BallCollect>().enabled = true;
        }

    }       
}
