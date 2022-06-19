using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool dragging;
    private Vector2 mousePos;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // dragging = false;
    }
    private void OnMouseDrag()
    {
        transform.position = mousePos;

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        { 
            dragging = true;
        }
        else
        {
            dragging = false;
        }
    }



}
