using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarBarFilled : MonoBehaviour
{
    
    private void Update()
    {
        GetComponent<Image>().fillAmount = CountdowTimerManager._ins.timer / GameManager._ins.starsStandard.z;
    }
}
