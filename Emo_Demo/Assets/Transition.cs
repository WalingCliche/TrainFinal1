using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Transition : MonoBehaviour
{
    public bool up;
    public bool down;
    [Range(0,0.8f)]
    public float speed;
    [Header("Range1")]
    public Vector2 range1;
    [Header("Range2")]
    public Vector2 range2;
    private Material mat;
    private float value;
    private bool onetime;
    private void Start()
    {
        mat=GetComponent<Image>().material;
        mat.SetFloat("_GrowUp", 0f);
    }
    private void Update()
    {
        if (up == true&&!onetime) {
            mat.SetFloat("_GrowUp", 0f);
            onetime = true;
            value = 0f;
        }
        if (down == true && !onetime)
        {
            mat.SetFloat("_GrowUp", 0.8f);
            onetime = true;
            value = 0f;
        }
        if (up == true&&Mathf.Sin(Remap(value, range1.x, range1.y, range2.x, range2.y)) < 0.6f)
        {
            value += Time.deltaTime * speed;
            mat.SetFloat("_GrowUp", Mathf.Sin(Remap(value, range1.x, range1.y, range2.x, range2.y)));
        }

        if (down == true&&Mathf.Sin(Remap(value, range1.x, range1.y, range2.x, range2.y)) < 0.6f)
        {
            value += Time.deltaTime * speed;
            mat.SetFloat("_GrowUp", Mathf.Sin(0.6f-Remap(value, range1.x, range1.y, range2.x, range2.y)));
        }

    }
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
