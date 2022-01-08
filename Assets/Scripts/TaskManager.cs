using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public GameObject[] taskList;

    private void FixedUpdate()
    {
        //Harvest
        if (GameObject.FindGameObjectWithTag("Crop") == null)
        {
            foreach(GameObject task in taskList)
            {
                if (task.GetComponent<TaskID>().taskID == "harvest")
                {
                    task.SetActive(false);
                }
            }
        }

        //Water
        if (GameObject.Find("Water") != null)
        {
            foreach (GameObject task in taskList)
            {
                if (task.GetComponent<TaskID>().taskID == "water")
                {
                    task.SetActive(false);
                }
            }
        }
    }
}
