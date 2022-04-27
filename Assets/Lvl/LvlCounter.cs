using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlCounter : MonoBehaviour
{
    private TextMeshPro _counterText;
    private int _lvlNumber;

    private void Start()
    {
        _counterText = GetComponent<TextMeshPro>();
    }

    public void increaseLvlNumber()
    {
        _lvlNumber++;
        _counterText.text = _lvlNumber.ToString();
    }
}
