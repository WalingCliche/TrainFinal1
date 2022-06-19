using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalPic : MonoBehaviour
{
    public CircleColorState goal;
    public GameObject CircleArea;
    private void Update()
    {
        if (CircleArea.GetComponent<CircleState>().state == goal)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            
        }
        else
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
