using System;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}

