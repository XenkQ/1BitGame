using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedVFXController : MonoBehaviour
{
    public void ClearAllVFXFromCurrentLvl()
    {
        foreach(Transform childVFX in transform)
        {
            Destroy(childVFX.transform.gameObject);
        }
    }
}
