using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject wheel;
    [SerializeField]
    private AudioSource wheelSound;

    public void placeWheel()
    {
        if (wheelManager.canPlaceWheel == true)
        {
            wheel.SetActive(true);
            wheelManager.wheelInventory -= 1;
            wheelManager.wheelsOnCar += 1;
            gameObject.tag = "Untagged";
            GetComponent<Interactable>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            wheelSound.Play();
        }
    }
}
