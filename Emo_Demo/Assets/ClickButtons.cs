using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickButtons : MonoBehaviour
{
    public GameObject TransUp;

    public void Retry()
    {
        PlayClickSound();
        StartCoroutine(ReTranUp());
    }
    public void NextLevel()
    {
        PlayClickSound();
        StartCoroutine(TranUp());
    }

    public void ClickStart() {
        PlayClickSound();
        SceneManager.LoadScene("Menu");
    }
    void PlayClickSound() {
        SoundManager._ins.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("SFX/Click"));
    }
    IEnumerator TranUp() {
        TransUp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator ReTranUp()
    {
        TransUp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
