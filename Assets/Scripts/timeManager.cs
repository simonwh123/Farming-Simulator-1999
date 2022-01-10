using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timeManager : MonoBehaviour
{
    public GameObject sun;
    public GameObject ambienceObject;
    public GameObject lampLight;

    public GameObject footstepsObject;
    public GameObject tractor;
    public GameObject dayCount;

    public TextMeshProUGUI timerText;
    public bool overMidnight;

    private const int STARTINGTIMEFirst = 12;
    private const int STARTINGTIMELast = 00;

    private int firstNumber;
    private float lastNumber;

    // Start is called before the first frame update
    void Start()
    {
        overMidnight = false;

        firstNumber = STARTINGTIMEFirst;
        lastNumber = STARTINGTIMELast;

        dayCount = GameObject.Find("DayCount");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Increase time
        if (footstepsObject.GetComponent<footstepScript>().footstepSound.isPlaying == true) // Walk
        {
            lastNumber = lastNumber + Time.deltaTime * dayCount.GetComponent<dayCountScript>().day * 5;
        }
        if (tractor.GetComponent<MSVehicleControllerFree>().KMh > 1 && tractor.GetComponent<MSVehicleControllerFree>().isInsideTheCar == true) // Tractor
        {
            lastNumber = lastNumber + Time.deltaTime / tractor.GetComponent<MSVehicleControllerFree>().KMh * dayCount.GetComponent<dayCountScript>().day * 2;
        }

        // Make clock work properly
        if (lastNumber > 9)
        {
            timerText.text = firstNumber + ":" + lastNumber.ToString("f0");
        }
        else
        {
            timerText.text = firstNumber + ":" + "0" + lastNumber.ToString("f0");
        }

        if (lastNumber > 60)
        {
            lastNumber = 0;
            firstNumber = firstNumber + 1;
        }

        //Check if over midnight
        if (firstNumber >= 24)
        {
            onMidnight();
        }
    }

    public void onMidnight()
    {
        Camera.main.backgroundColor = Color.black;
        RenderSettings.fogColor = Color.black;
        overMidnight = true;
        timerText.text = "OVER MIDNIGHT";
        sun.SetActive(false);
        ambienceObject.SetActive(false);
        lampLight.SetActive(true);
    }

    public void goInside()
    {
        if (overMidnight)
        {
            SceneManager.LoadScene("SleepScene");
        }
    }
}
