using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactor : MonoBehaviour
{
    public Interactable interactable;
    public GameObject interactText;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 0.6f))
        {
            if (hit.collider.tag != "Interactable" && hit.collider.GetComponent<Interactable>() == null)
            {
                interactText.SetActive(false);
            }
            else
            {
                if (hit.collider.gameObject.layer == 9)
                {
                    interactText.GetComponent<TextMeshProUGUI>().text = "F";
                }
                else
                {
                    interactText.GetComponent<TextMeshProUGUI>().text = "E";
                }
                interactText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //hit.collider.gameObject.tag = "Untagged";
                    hit.collider.GetComponent<Interactable>().onInteract.Invoke();
                    interactText.SetActive(false);
                }

            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
