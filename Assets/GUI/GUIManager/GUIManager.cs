using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] GUIObjects;

    public void Update()
    {
        StopGameTimeIfGUIIsActive();
    }

    private void StopGameTimeIfGUIIsActive()
    {
        foreach (GameObject GUI in GUIObjects)
        {
            if(GUI.active == true)
            {
                GameTimeManager.PauseGameTime();
                break;
            }
        }
    }

    public void DisableAllGUI()
    {
        foreach(GameObject GUI in GUIObjects)
        {
            GUI.SetActive(false);
        }
    }
}
