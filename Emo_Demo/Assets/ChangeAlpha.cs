using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeAlpha : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Image>().color = new Vector4(
GetComponent<Image>().color.r,
GetComponent<Image>().color.g,
GetComponent<Image>().color.b,
0);
    }
    private void Update()
    {
        GetComponent<Image>().color = new Vector4(
    GetComponent<Image>().color.r,
    GetComponent<Image>().color.g,
    GetComponent<Image>().color.b,
    GetComponent<Image>().color.a + Time.deltaTime);

    }
}
