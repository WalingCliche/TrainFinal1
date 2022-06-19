using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelArrow : MonoBehaviour
{
    public Button right, left;
    public float moveDis;
    public float moveSpeed;
    public RectTransform Level; 
    public Vector2 TargetPos;
    public bool limit;
    public bool leftLimit;
    private void Start()
    {
        TargetPos = Level.anchoredPosition;
    }
    public void ArrowMove(bool Right)
    {
        if (TargetPos.x < 600f - (Level.gameObject.transform.childCount - 5) * moveDis)
            limit = true;
        else
            limit = false;
        if (TargetPos.x > 360f)
            leftLimit = true;
        else
            leftLimit = false;
        if (Right)
        {
            right.enabled = false;
            StartCoroutine(ResetButton(right));
            if (!limit)
            {
                TargetPos = Level.anchoredPosition + new Vector2(-moveDis, 0);
            }
        }
        else
        {
            left.enabled = false;
            StartCoroutine(ResetButton(left));
            if (!leftLimit)
            TargetPos = Level.anchoredPosition - new Vector2(-moveDis, 0);
        }
        
        
    }
    private void Update()
    {
        Level.anchoredPosition = Vector2.MoveTowards(Level.anchoredPosition, TargetPos, Time.deltaTime * moveSpeed);
        //    Debug.Log(TargetPos.x);
        //    if (TargetPos.x <600f-(Level.gameObject.transform.childCount-5)* moveDis) 
        //        limit = true;
        //    else
        //        limit = false;
        //    if (TargetPos.x> 360f)
        //        leftLimit = true;     
        //    else
        //        leftLimit = false;
        //}
    }
    IEnumerator ResetButton(Button x) {

        yield return new WaitForSeconds(0.6f);
        x.enabled = true;
    }
        

    
}
