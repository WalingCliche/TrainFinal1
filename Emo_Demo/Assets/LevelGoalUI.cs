using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelGoalUI : MonoBehaviour
{
    public GameObject targetPos;
    public GameObject targetScale;
    public float movingSpeed;
    public float accSpeed;
    public float scaleSpeed;
    public bool Moving;
    private GameObject[] balls;
    private bool oneTime;
    private void Start()
    {
        CountdowTimerManager._ins.counting = false;
        balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var item in balls)
        {
            item.GetComponent<RandomMove>().enabled = false;
        }
    }
    private void Update()
    {
        if (GetComponent<RawImage>().color.a >=1f)
        {
            Moving = true;
        }
        if (Moving)
        {
            movingSpeed += Time.deltaTime * accSpeed;
            gameObject.GetComponent<RectTransform>().position = Vector2.MoveTowards(gameObject.GetComponent<RectTransform>().position,
                                                                                                                                             targetPos.GetComponent<RectTransform>().position, Time.deltaTime * movingSpeed);
            gameObject.GetComponent<RectTransform>().localScale = Vector2.MoveTowards(gameObject.GetComponent<RectTransform>().localScale,
                                                                                                                                             targetScale.GetComponent<RectTransform>().localScale, Time.deltaTime * scaleSpeed);
        }

        if (Vector2.Distance(gameObject.GetComponent<RectTransform>().position, targetPos.GetComponent<RectTransform>().position) < 0.02f)
        {
            targetPos.SetActive(true);
            if (!oneTime)
            {
                oneTime = true;
                StartCoroutine(StartGame());
            }
            Destroy(gameObject.transform.parent.gameObject,1.5f);

            
        }

    }
    IEnumerator StartGame() {
        yield return new WaitForSeconds(1.4f);
        CountdowTimerManager._ins.counting = true;
        foreach (var item in balls)
        {
            item.GetComponent<RandomMove>().enabled = true;
        }
    }
}
