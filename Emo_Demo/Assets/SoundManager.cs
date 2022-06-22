using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _ins;
    public bool PlayingDragging;
    private void Awake()
    {
        _ins = this;
    }

}
