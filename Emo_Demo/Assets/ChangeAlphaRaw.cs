using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeAlphaRaw : MonoBehaviour
{
    private void Start()
    {
        GetComponent<RawImage>().color = new Vector4(
GetComponent<RawImage>().color.r,
GetComponent<RawImage>().color.g,
GetComponent<RawImage>().color.b,
0);
    }
    private void Update()
    {
        GetComponent<RawImage>().color = new Vector4(
    GetComponent<RawImage>().color.r,
    GetComponent<RawImage>().color.g,
    GetComponent<RawImage>().color.b,
    GetComponent<RawImage>().color.a + Time.deltaTime);

    }
}
