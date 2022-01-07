using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public bool colliding;
    public GameObject interactText;

    private void Start()
    {
        interactText = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactor>().interactionText;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colliding = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colliding = false;
            interactText.SetActive(false);
        }
    }
}
