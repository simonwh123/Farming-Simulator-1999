using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public GameObject[] taskList;
    public AudioSource taskCompleteSound;
    public bool allTasksCompleted;

    private void FixedUpdate()
    {
        // Harvest
        if (GameObject.FindGameObjectWithTag("Crop") == null)
        {
            completeTask("harvest");
        }

        // Shovel shit
        if (GameObject.FindGameObjectWithTag("Shit") == null)
        {
            completeTask("shovel");
        }

        // Water
        if (GameObject.Find("Water") != null)
        {
            completeTask("water");
        }

        // Food
        if (GameObject.Find("CatFood") != null)
        {
            completeTask("food");
        }

        if (GameObject.FindGameObjectWithTag("Task") == null)
        {
            allTasksCompleted = true;
        }
        else
        {
            allTasksCompleted = false;
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
