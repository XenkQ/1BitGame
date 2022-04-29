using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] private int time;
    public int Time { get { return time; } }
    private TMP_Text timerText;
    private bool timeIsOn = false;
    [HideInInspector] public int StartTime;

    private void Awake()
    {
        StartTime = time;
    }

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
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
        timeIsOn = false;
    }

    public bool IsEndOfTime()
    {
        if(time<=0)
        {
            return true;
        }
        else { return false; }
    }
}
