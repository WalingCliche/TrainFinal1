using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public GameObject[] stars;
    public int index;
    public int starsNum;
    private void Start()
    {

    }
    private void Update()
    {
        index = transform.GetSiblingIndex() + 1;
        starsNum = PlayerPrefs.GetInt("StarsLevel" + index);
        GetComponentInChildren<TMP_Text>().text = "Level" + index;

        for (int i = 0; i < 4; i++)
        {
            if (starsNum == i)
            {
                stars[i].SetActive(true);
                break;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetStars();
        }
    }
    void ResetStars()
    {
            for (int i = 0; i < 4; i++)
            {
                    stars[i].SetActive(false);     
            }
            for (int i = 0; i<transform.parent.childCount; i++)
            {
                int x = i + 1;
                PlayerPrefs.SetInt(("StarsLevel" + x).ToString(), 0);
            }
     }



   public  void ChooseLevel() 
    {
        SceneManager.LoadScene("Level"+ index);
    }
}
