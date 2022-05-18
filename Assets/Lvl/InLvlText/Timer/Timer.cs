using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private int time;
    [HideInInspector] public int Time { get { return time; } }

    private int startTime;
    [HideInInspector] public int StartTime { get { return startTime; } }
    private bool timeIsSet = false;
    [HideInInspector] public bool TimeIsSet { get { return timeIsSet; } }
    private TMP_Text timerText;
    private bool timeIsOn = false;

    [Header("Sound")]
    [SerializeField] private SoundMenager soundMenager;
    [SerializeField] private AudioClip[] clockAudioClips;
    private int currentClockSoundIndex = 0;

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
        PlayClockSound();
        timeIsSet = false;
        timeIsOn = false;
    }

    private void PlayClockSound()
    {
        if (!IsEndOfTime())
        {
            soundMenager.PlaySound(clockAudioClips[currentClockSoundIndex]);
            currentClockSoundIndex = currentClockSoundIndex + 1 <= 1 ? 1 : 0;
        }
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
