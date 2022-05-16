using UnityEngine;

public class InLvlTextMenager : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private LvlCounter lvlCounter;
    [SerializeField] private PressAnyKeyToStart pressAnyKeyToStart;

    private void Update()
    {
        DisableTimerIfPressAnyKeyTextIsActive();
    }

    private void DisableTimerIfPressAnyKeyTextIsActive()
    {
        if (IsPressAnyKeyToStartActive())
        {
            timer.gameObject.SetActive(false);
        }
        else
        {
            timer.gameObject.SetActive(true);
        }
    }

    public bool IsPressAnyKeyToStartActive()
    {
        return pressAnyKeyToStart.gameObject.active == true;
    }
}
