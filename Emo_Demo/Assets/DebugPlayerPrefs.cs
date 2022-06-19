using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerPrefs : MonoBehaviour
{

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("StarsLevel" + 1));
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < transform.parent.childCount - 1; i++)
            {
                
                PlayerPrefs.SetInt(("StarsLevel" + (i + 1)), 0);
            }
        }

    }
}
