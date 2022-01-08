using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public GameObject[] taskList;
    public AudioSource taskCompleteSound;

    private void FixedUpdate()
    {
        //Harvest
        if (GameObject.FindGameObjectWithTag("Crop") == null)
        {
            completeTask("harvest");
        }

        //Water
        if (GameObject.Find("Water") != null)
        {
            completeTask("water");
        }
    }

    public void completeTask(string taskID)
    {
        foreach (GameObject task in taskList)
        {
            if (task.GetComponent<TaskID>().taskID == taskID)
            {
                if (task.activeInHierarchy == true)
                {
                    taskCompleteSound.Play();
                    task.SetActive(false);
                }
            }
        }
    }
}
