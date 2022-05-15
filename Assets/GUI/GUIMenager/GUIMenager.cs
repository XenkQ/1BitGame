using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMenager : MonoBehaviour
{
    [SerializeField] private GameObject[] gUIObjects;

    public void Update()
    {
        StopGameTimeIfGUIIsActive();
    }

    private void StopGameTimeIfGUIIsActive()
    {
        foreach (GameObject gUI in gUIObjects)
        {
            if(gUI.active == true)
            {
                GameTimeMenager.PauseGameTime();
                break;
            }
        }
    }

    public void DisableAllGUI()
    {
        foreach(GameObject gUI in gUIObjects)
        {
            gUI.SetActive(false);
        }
    }
}
