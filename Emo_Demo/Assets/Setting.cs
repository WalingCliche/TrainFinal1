using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Setting : MonoBehaviour
{
    public GameObject SettingUI;
    public bool Overing;
    private void Update()
    {
        if (Overing) 
        {
            Over();
        }
    }
    public void OpenSettingAndPause() 
    {
        PlayClickSound();
        PauseGame();
        SettingUI.SetActive(true);
    }
    public void MouseEnter()
    {
        Overing = true;
    }
    public void MouseExit()
    {
        Overing = false;
    }
    public void Over()
    {
        transform.localEulerAngles -= new Vector3(0, 0, Time.deltaTime*50f);
    }
    void PauseGame() {
        Time.timeScale = 0;
    }
    void PlayClickSound()
    {
        SoundManager._ins.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("SFX/Click"));
    }
}
