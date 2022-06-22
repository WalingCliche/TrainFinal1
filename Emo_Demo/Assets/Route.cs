using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public float fadeStartTime;
    public float fadespeed;
    public GameObject Pos1;
    private bool fade;
    private void Start()
    {
        StartCoroutine(wait(fadeStartTime));
        transform.right = Pos1.transform.position - transform.position;
        GetComponent<SpriteRenderer>().color = new Vector4(GetComponent<SpriteRenderer>().color.r,
                                                                                                  GetComponent<SpriteRenderer>().color.g,
                                                                                                  GetComponent<SpriteRenderer>().color.b,
                                                                                                  0);
    }
    private void Update()
    {
        if (GetComponent<SpriteRenderer>().color.a >= 0f|| GetComponent<SpriteRenderer>().color.a <=1f)
        {
            if (fade)
                GetComponent<SpriteRenderer>().color = new Vector4(
                    GetComponent<SpriteRenderer>().color.r,
                    GetComponent<SpriteRenderer>().color.g,
                    GetComponent<SpriteRenderer>().color.b,
                    GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
            else
            {
                GetComponent<SpriteRenderer>().color = new Vector4(
            GetComponent<SpriteRenderer>().color.r,
            GetComponent<SpriteRenderer>().color.g,
            GetComponent<SpriteRenderer>().color.b,
            GetComponent<SpriteRenderer>().color.a + Time.deltaTime);

            }
        }
    }
    IEnumerator wait(float time) { 
    yield  return new WaitForSeconds(time);
        fade = true;
    }
}
