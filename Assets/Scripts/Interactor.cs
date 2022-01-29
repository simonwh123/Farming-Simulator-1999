using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactor : MonoBehaviour
{
    public Interactable interactable;
    public GameObject interactionText;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2))
        {
            if (hit.collider.tag == "Interactable" && hit.collider.GetComponent<Interactable>() != null)
            {
                if (hit.collider.GetComponent<Interactable>().colliding == true)
                {
                    if (hit.collider.tag != "Interactable" && hit.collider.GetComponent<Interactable>() == null)
                    {
                        interactionText.SetActive(false);
                    }

                    if (hit.collider.gameObject.layer == 9)
                    {
                        interactionText.GetComponent<TextMeshProUGUI>().text = "F";
                    }
                    else
                    {
                        interactionText.GetComponent<TextMeshProUGUI>().text = "E";
                    }
                    interactionText.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //hit.collider.gameObject.tag = "Untagged";
                        hit.collider.GetComponent<Interactable>().onInteract.Invoke();
                        interactionText.SetActive(false);
                    }
                }
            }

            //if (hit.collider.GetComponent<Interactable>() != null)
            //{
            //    if (hit.collider.GetComponent<Interactable>().colliding == false)
            //    {
            //        interactionText.SetActive(false);
            //    }
            //}
        }
    }
}
