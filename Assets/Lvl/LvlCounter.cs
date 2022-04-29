using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlCounter : MonoBehaviour
{
    private TextMeshPro counterText;
    private int lvlNumber;

    private void Start()
    {
        counterText = GetComponent<TextMeshPro>();
    }

    public void increaseLvlNumber()
    {
        lvlNumber++;
        counterText.text = lvlNumber.ToString();
    }
}
