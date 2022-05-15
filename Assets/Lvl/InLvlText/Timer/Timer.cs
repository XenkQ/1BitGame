using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] private int time;
    [HideInInspector] public int Time { get { return time; } }

    private int startTime;
    [HideInInspector] public int StartTime { get { return startTime; } }
    private bool timeIsSet = false;
    [HideInInspector] public bool TimeIsSet { get { return timeIsSet; } }
    private TMP_Text timerText;
    private bool timeIsOn = false;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
        SetStartTime();
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

    private void SetStartTime()
    {
        startTime = time;
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
        time = startTime;
        timeIsSet = true;
    }
}
