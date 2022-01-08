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
            print("no crops");
            foreach(GameObject task in taskList)
            {
                if (task.GetComponent<TaskID>().taskID == "harvest")
                {
                    task.SetActive(false);
                }
            }
        }
    }
}
