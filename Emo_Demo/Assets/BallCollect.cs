using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollect : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;
    public float scaleSpeed;
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.one * Mathf.Lerp(1f, 0f, timer* scaleSpeed);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime* moveSpeed);

    }
}
