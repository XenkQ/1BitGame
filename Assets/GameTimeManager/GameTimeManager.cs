using UnityEngine;

public static class GameTimeManager
{
    public static void PauseGameTime()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public static void UnpauseGameTime()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
