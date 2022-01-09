using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovelScript : MonoBehaviour
{
    public GameObject[] shits;

    public void pickupShovel()
    {
        foreach (GameObject shit in shits)
        {
            shit.gameObject.tag = ("Interactable");
            shit.GetComponent<Interactable>().enabled = true;
            shit.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
