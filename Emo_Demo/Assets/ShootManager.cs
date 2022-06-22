using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static ShootManager _ins;
    public float shootTime;
    public float changeTime;
    public float force;
    private GameObject redBall, blueBall, whiteBall;
    private void Awake()
    {
        _ins = this;
    }
    private void Start()
    {
    }
    private void Update()
    {
        redBall = (GameObject)Resources.Load("Prefabs/Balls/Red");
        blueBall = (GameObject)Resources.Load("Prefabs/Balls/Blue");
        whiteBall = (GameObject)Resources.Load("Prefabs/Balls/White");

    }
    IEnumerator Shoot(float time) {
        yield return new WaitForSeconds(time);
    /*    for (int i = 0; i < ShootBall.transform.childCount; i++)
        {
            ShootBall.transform.GetChild(i).gameObject.AddComponent<ShootBullet>();
           // ShootBall.transform.GetChild(i).gameObject.GetComponent<RandomMove>().enabled = false;
        }*/
    }
}
