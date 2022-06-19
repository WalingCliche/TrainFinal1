using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingUI : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void ExitToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
