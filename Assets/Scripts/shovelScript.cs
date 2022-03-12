using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovelScript : MonoBehaviour
{
    public GameObject[] shits;
    public static bool hasShovel;

    public void pickupShovel()
    {
        foreach (GameObject shit in shits)
        {
            hasShovel = true;
            shit.gameObject.tag = ("Interactable");
            shit.GetComponent<Interactable>().enabled = true;
            shit.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
