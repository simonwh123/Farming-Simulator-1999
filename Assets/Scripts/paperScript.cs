using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class paperScript : MonoBehaviour
{
    public GameObject paperUI;
    //public TextMeshProUGUI textObject;
    public static bool examiningPaper;
    public string textToDisplay;

    private void FixedUpdate()
    {
        //textObject.text = textToDisplay;
    }

    public void onPaperExamine()
    {
        examiningPaper = !examiningPaper;

        if (examiningPaper && GetComponent<Interactable>().colliding == true)
        {
            paperUI.SetActive(true);
        }
        else
        {
            paperUI.SetActive(false);
        }

    }
}
