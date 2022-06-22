using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject[] trains;
    public float showtime;
    public static TrainManager _ins;
    // Start is called before the first frame update
    private void Awake()
    {
        _ins = this;
    }
    void Start()
    {
        foreach (var item in trains)
        {
            item.SetActive(false);
        }
        //trains = new GameObject[transform.childCount];
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    trains[i] = transform.GetChild(i).GetChild(0).gameObject;
        //}   
        StartCoroutine(StartTrain(trains[0], showtime));
    }
    IEnumerator StartTrain(GameObject X, float time) { 
    yield  return new WaitForSeconds(time);
        X.SetActive(true);


    }
}

