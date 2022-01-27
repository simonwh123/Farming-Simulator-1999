using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperManager : MonoBehaviour
{
    public static bool touchingPaper;
    public TextMeshProUGUI textObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchingPaper)
        {
            GetComponent<paperScript>().enabled = true;
        }
        else
        {
            paperScript.examiningPaper = false;
            GameObject.Find("PaperUI").SetActive(false);
            GetComponent<paperScript>().enabled = false;
        }
    }

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
            touchingPaper = false;
        }
    }
}
