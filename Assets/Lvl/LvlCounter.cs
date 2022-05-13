using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlCounter : MonoBehaviour
{
    private TextMeshPro counterText;
    private int lvlNumber = 1;
    [HideInInspector] public int LvlNumber { get { return lvlNumber; } }

    private void Awake()
    {
        counterText = GetComponent<TextMeshPro>();
    }

    public void increaseLvlNumber()
    {
        lvlNumber++;
        counterText.text = lvlNumber.ToString();
    }

    public void RestartLvlNumber()
    {
        lvlNumber = 1;
        counterText.text = lvlNumber.ToString();
    }
}
