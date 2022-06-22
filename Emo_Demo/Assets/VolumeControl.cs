using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeControl : MonoBehaviour
{
    public AudioSource ads;
    public Slider slider;
    private void Start()
    {
      slider.value = PlayerPrefs.GetFloat("Volume");
        ads = GetComponent<AudioSource>();
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        ads.volume = PlayerPrefs.GetFloat("Volume"); 

    }
}
