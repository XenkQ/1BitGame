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
        Debug.Log(character.IsDead);
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
        try
        {
            if (deathGUI.active == true && Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
        }
        catch(Exception e)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void DisableDeathGUI()
    {
        //TODO: null object reference
        if(deathGUI.active == true)
        {
            deathGUI.SetActive(false);
        }
    }
}
