using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingUI : MonoBehaviour
{
    public void Resume()
    {
        PlayClickSound();
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void ExitToMenu() 
    {
        PlayClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Restart() {
        PlayClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void PlayClickSound()
    {
        SoundManager._ins.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("SFX/Click"));
    }
}
