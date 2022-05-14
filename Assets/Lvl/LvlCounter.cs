using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlCounter : MonoBehaviour
{
    [SerializeField] private int maxLvl = 30;
    private TextMeshPro counterText;
    [SerializeField] private int lvlNumber = 1;
    [HideInInspector] public int LvlNumber { get { return lvlNumber; } }

    private void Awake()
    {
        counterText = GetComponent<TextMeshPro>();
    }

    public void increaseLvlNumber()
    {
        if(!IsEndOfLvls())
        {
            lvlNumber++;
            counterText.text = lvlNumber.ToString();
        }
    }

    public bool IsEndOfLvls()
    {
        return lvlNumber > maxLvl;
    }

    public void RestartLvlNumber()
    {
        lvlNumber = 1;
        counterText.text = lvlNumber.ToString();
    }

}
