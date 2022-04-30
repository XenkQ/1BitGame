using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] public int time;
    [HideInInspector] public int StartTime;
    [HideInInspector] public bool timeIsSet = false;
    private TMP_Text timerText;
    private bool timeIsOn = false;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        StartTime = time;
        timeIsSet = true;
    }

    private void Update()
    {
        if (!timeIsOn && time >= 0)
        {
            StartCoroutine(TimerProcess());
        }
    }

    private IEnumerator TimerProcess()
    {
        timeIsOn = true;
        timerText.text = time.ToString();
        yield return new WaitForSeconds(1f);
        time--;
        timeIsSet = false;
        timeIsOn = false;
    }

    public bool IsEndOfTime()
    {
        if (time <= 0)
        {
            return true;
        }
        else { return false; }
    }

    public void RestartTime()
    {
        time = StartTime;
    }
}
