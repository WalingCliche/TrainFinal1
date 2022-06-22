using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ClickButtons : MonoBehaviour
{
    public GameObject TransUp;
    public GameObject Slider;
    public GameObject mute;
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
    public void ClickVolume()
    {
        PlayClickSound();
        Slider.GetComponent<Slider>().value = 0;
        mute.SetActive(true);


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
    private void Update()
    {
        if (Slider.GetComponent<Slider>().value > 0) {
            mute.SetActive(false);
        }
        if (Slider.GetComponent<Slider>().value == 0)
        {
            mute.SetActive(true);
        }
    }
}
