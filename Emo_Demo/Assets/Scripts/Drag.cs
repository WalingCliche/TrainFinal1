using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool dragging;
    private Vector2 mousePos;
    public AudioSource ads;
    public void Start()
    {
        ads = GetComponent<AudioSource>();
        ads.volume = 0.4f;
        ads.enabled = false;
    }
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
            if(SoundManager._ins.PlayingDragging==false)
                        ads.enabled = true;
            SoundManager._ins.PlayingDragging = true;
        }
        else
        {
            SoundManager._ins.PlayingDragging = false ;
            dragging = false;
            ads.enabled = false ;
        }
    }



}
