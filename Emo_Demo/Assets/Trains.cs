using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trains : MonoBehaviour
{
    [Header("泥头车Setting")]
     GameObject redball, blueball, whiteball;
    public float shootTime;
    public BallColor shootColor;
    public int shootNum;
    public Transform shootPos;
    public Transform[] pos;
    public float trainSpeed;
    public float accerlateSpeed;
    private float startSpeed;
    private Transform targetPos;
    private Vector3 startPos;
    private int index;
    private bool oneTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        startPos = transform.position;
        startSpeed = trainSpeed;
        redball = (GameObject)Resources.Load("Prefabs/Balls/Red");
       blueball = (GameObject)Resources.Load("Prefabs/Balls/Blue");
        whiteball = (GameObject)Resources.Load("Prefabs/Balls/White");
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = pos[index];
        Vector3 v = (targetPos.position - transform.position).normalized;
        transform.right = v;
        trainSpeed += Time.deltaTime* accerlateSpeed;
        transform.position = Vector2.MoveTowards(transform.position, targetPos.position, Time.deltaTime * trainSpeed);
        if (Vector2.Distance(transform.position, pos[index].position) < 0.02f)
        {
            if (index < pos.Length - 1)
                index++;
        }

        if (Vector2.Distance(transform.position, pos[index].position) < 0.02f && index == pos.Length - 1)
        {
             Destroy(transform.parent.gameObject);
            TrainReset();
            int x = Random.Range(0, TrainManager._ins.trains.Length);
            while (gameObject == TrainManager._ins.trains[x])
                x = Random.Range(0, TrainManager._ins.trains.Length);
            TrainManager._ins.trains[x].SetActive(true);
        }


        timer += Time.deltaTime;
        if (timer > shootTime&&!oneTime)
        {
            for (int i = 0; i < shootNum; i++)
            {
                ShootBall(shootColor);
            }

            timer = 0;
            oneTime = true;
        }



    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ball"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
    void TrainReset()
    {
        index = 0;
        gameObject.transform.position = startPos;
        trainSpeed = startSpeed;
        gameObject.SetActive(false);
    }
    void ShootBall(BallColor color) {
        switch (color)
        {
            case BallColor.Red:
                GameObject ball;
               ball =  GameObject.Instantiate(redball);
                ball.transform.position = shootPos.transform.position;
                ball.transform.rotation = transform.parent.rotation;
                ball.AddComponent<ShootBullet>();
                break;
            case BallColor.Blue:
                ball = GameObject.Instantiate(blueball);
                ball.transform.position = shootPos.transform.position;
                ball.transform.rotation = transform.parent.rotation;
                ball.AddComponent<ShootBullet>();
                break;
            case BallColor.White:
                ball = GameObject.Instantiate(whiteball);
                ball.transform.position = shootPos.transform.position;
                ball.transform.rotation = transform.parent.rotation;
                ball.AddComponent<ShootBullet>();
                break;
        }



    }


}