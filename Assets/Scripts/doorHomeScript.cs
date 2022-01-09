using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class doorHomeScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject notCompleteText;
    public TextMeshProUGUI dayText;

    private void Start()
    {
        dayText.text = "Day " + GameObject.Find("DayCount").GetComponent<dayCountScript>().day.ToString();
        StartCoroutine("deleteDayText");
    }

    public void goInside()
    {
        if (gameManager.GetComponent<TaskManager>().allTasksCompleted == true)
        {
            SceneManager.LoadScene("SleepScene");
            GameObject.Find("DayCount").GetComponent<dayCountScript>().day += 1;
        }
        else
        {
            StartCoroutine("deleteText");
            notCompleteText.SetActive(true);
        }
    }

    IEnumerator deleteDayText()
    {
        yield return new WaitForSeconds(3);
        dayText.enabled = false;
    }

    IEnumerator deleteText()
    {
        yield return new WaitForSeconds(3);
        notCompleteText.SetActive(false);
    }
}
