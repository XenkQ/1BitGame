using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] private int _time;
    public int Time { get { return _time; } }
    private TMP_Text _timerText;
    private bool _timeIsOn = false;
    public int StartTime;

    private void Awake()
    {
        StartTime = _time;
    }

    private void Start()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!_timeIsOn && _time >= 0)
        {
            StartCoroutine(TimerProcess());
        }
    }

    private IEnumerator TimerProcess()
    {
        _timeIsOn = true;
        _timerText.text = _time.ToString();
        yield return new WaitForSeconds(1f);
        _time--;
        _timeIsOn = false;
    }
}
