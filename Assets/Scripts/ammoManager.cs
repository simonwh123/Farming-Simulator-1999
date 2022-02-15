using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoManager : MonoBehaviour
{
    public static int ammo;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
