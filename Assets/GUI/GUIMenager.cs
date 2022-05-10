using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMenager : MonoBehaviour
{
    [SerializeField] private DeathGUIMenager deathGUIMenager;

    public void DisableAllGUI()
    {
        deathGUIMenager.DisableDeathGUI();
    }
}
