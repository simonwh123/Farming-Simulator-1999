using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayCountScript : MonoBehaviour
{
    public int day;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
