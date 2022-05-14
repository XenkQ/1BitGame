using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGUIMenager : MonoBehaviour
{
    [SerializeField] private LvlCounter lvlCounter;
    [SerializeField] private GameObject winGUI;

    private void Update()
    {
        EnableWinGUIWhenEndOfLvls();
    }

    private void EnableWinGUIWhenEndOfLvls()
    {
        if (lvlCounter.IsEndOfLvls())
        {
            EnableWinGUI();
        }
    }

    private void EnableWinGUI()
    {
        winGUI.SetActive(true);
    }
}
