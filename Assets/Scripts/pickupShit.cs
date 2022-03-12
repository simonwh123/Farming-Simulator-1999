using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupShit : MonoBehaviour
{
    [SerializeField] private GameObject sound;

    public void pickupShitFunction()
    {
        if (shovelScript.hasShovel == true)
        {
            gameObject.SetActive(false);
            sound.GetComponent<AudioSource>().Play();
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
