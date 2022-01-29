using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperManager : MonoBehaviour
{
    public static bool touchingPaper;
    public TextMeshProUGUI textObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            textObject.text = other.GetComponent<paperScript>().textToDisplay;
            touchingPaper = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            paperScript.examiningPaper = false;
            GameObject.Find("PaperUI").SetActive(false);
            touchingPaper = false;
        }
    }
}
