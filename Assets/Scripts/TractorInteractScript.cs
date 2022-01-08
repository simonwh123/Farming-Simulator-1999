using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorInteractScript : MonoBehaviour
{
    public GameObject interactText;
    public GameObject player;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            interactText.SetActive(false);
        }
    }
}
