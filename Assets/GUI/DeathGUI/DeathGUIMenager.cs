using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGUIMenager : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private GameObject deathGUI;
    [SerializeField] private float timeToDeathGuiActivation = 2f;

    public void Update()
    {
        ActiveDeathGUIIFCharacterIsDead();
        StopGameTimeAfterDeathGUIActivation();
    }

    private void ActiveDeathGUIIFCharacterIsDead()
    {
        if (character.IsDead && deathGUI.active == false)
        {
            StartCoroutine(GUIActivationAfterTimeProcess(timeToDeathGuiActivation));
        }
    }

    private IEnumerator GUIActivationAfterTimeProcess(float time)
    {
        yield return new WaitForSeconds(time);
        deathGUI.SetActive(true);
    }

    private void StopGameTimeAfterDeathGUIActivation()
    {
        if (deathGUI.active == true && Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public void DisableDeathGUIProcess()
    {
        DisableDeathGUI();
        UnpauseTime();
    }

    private void DisableDeathGUI()
    {
        if (deathGUI.active == true)
        {
            deathGUI.SetActive(false);
        }
    }

    private void UnpauseTime()
    {
        Time.timeScale = 1;
    }
}
