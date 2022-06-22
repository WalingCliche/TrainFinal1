using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public enum GameState{indle,win,lose}
public class GameManager : MonoBehaviour
{
    public  Vector3 starsStandard;
    public GameObject BottomWiningUI;
    public int levelIndex;
    public int currentStar;
    public GameObject star1, star2, star3;
    public GameObject tranDownUI;
    public static GameManager _ins;
    public GameState gameState;
    public GameObject winUI, loseUI,winingtimerUI;
    public CountdowTimerManager time;
    public GoalManager goal;
    private GameObject[] areas;
    public float winTime;
    private float wintimer;
    private bool winning;
    public bool losing;
    public bool start;
    private void Awake()
    {
        _ins = this;
        start = true;
    }
    private void Start()
    {
        string x;
        x = SceneManager.GetActiveScene().name;
        levelIndex = int.Parse(x.Substring(x.Length - 1, 1));
        areas = GameObject.FindGameObjectsWithTag("CircleArea");
        winUI.SetActive(false);
        loseUI.SetActive(false);
        StartCoroutine(TranDown());
    }
    private void Update()
    {
        areas = GameObject.FindGameObjectsWithTag("CircleArea");
  //      CountColor(areas);
        Result();
        if (losing)
        {
            gameState = GameState.lose;
        }
        if (gameState == GameState.indle)
        {
            if (time.timer == 0f )
            {
                gameState = GameState.lose;
                return;
            }

           int  wincount = 0;
            foreach (var item in areas)
            {
                if (item.GetComponent<CircleState>().state != goal.goal)
                    wincount++;
            }
            if (wincount == 0)
                winning = true;
            else
            {
                winning = false;
                wintimer = 0;
            }

            if (winning)
            {
                wintimer += Time.deltaTime;
             //   BottomWiningUI.SetActive(true);
            }
            else
            { 
                wintimer = 0;
               // BottomWiningUI.SetActive(false);
            }
            if (wintimer > winTime)
            {
                gameState = GameState.win;
            }
        }

        if (winingtimerUI != null&&wintimer != 0)
        {
            winingtimerUI.SetActive(true);
            winingtimerUI.GetComponent<TMP_Text>().text = ((int)(winTime-wintimer)+1).ToString();
        }
        else if(winingtimerUI != null)
            winingtimerUI.SetActive(false);

    }

    void Result() {
        if (gameState == GameState.win)
        {
            Destroy(winingtimerUI);
            winUI.SetActive(true);
            time.counting = false;
            foreach (var item in areas)
            {
                item.GetComponent<CircleState>().enabled = false;
            }


            SetStar();




        }
        if (gameState == GameState.lose) 
        {
            winingtimerUI.SetActive(false);
            loseUI.SetActive(true);
         //   Time.timeScale = 0;
            foreach (var item in areas)
            {
                item.GetComponent<CircleState>().enabled = false;
            }
        }
    }
    private void OnDisable()
    {
        start = false;
    }
    IEnumerator TranDown() {
        tranDownUI.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        tranDownUI.SetActive(false);
        initialized();
    }

    void initialized()
    {
        CountdowTimerManager._ins.counting = true;
    }

    void SetStar() {
        float time = CountdowTimerManager._ins.timer;
        if (time > starsStandard.z)
        {
            currentStar = 3;
            star3.SetActive(true);
        }
        if (time <= starsStandard.z && time > starsStandard.y)
        {    
            currentStar = 2;
            star2.SetActive(true);
         }
        if (time <= starsStandard.y && time > starsStandard.x)
        { 
            currentStar = 1;
            star1.SetActive(true);
        }
        if (time <= starsStandard.x)
            currentStar = 0;

        if (currentStar > PlayerPrefs.GetInt("StarsLevel" + levelIndex)) 
        {
            PlayerPrefs.SetInt("StarsLevel" + levelIndex, currentStar);
        }
    }



}
