using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlCounter : MonoBehaviour
{
    private TextMeshPro counterText;
    public int lvlNumber = 1;

    private void Start()
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
