using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalHint : MonoBehaviour
{
    public GameObject[] balls;
    public GameObject Goal1, Goal2;
    private void Update()
    {
        if (Goal1.activeSelf == true || Goal2.activeSelf == true) {
            GetComponent<Animator>().enabled = true;
            CountdowTimerManager._ins.counting = false;
            foreach (var item in balls)
            {
                item.GetComponent<RandomMove>().enabled = false;
            }
            Destroy(gameObject, 2f);      
        }
    }

    private void OnDestroy()
    {
        CountdowTimerManager._ins.counting = true;
        foreach (var item in balls)
        {
            item.GetComponent<RandomMove>().enabled = true;
        }
    }
}
