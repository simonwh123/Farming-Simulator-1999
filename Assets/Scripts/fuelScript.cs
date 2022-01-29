using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fuelScript : MonoBehaviour
{
    public float fuel;
    private float fuelUsage;
    public static bool isInCar;

    public MSVehicleControllerFree vehicleController;

    public static TextMeshProUGUI fuelText;

    // Start is called before the first frame update
    void Start()
    {
        fuel = 100;

        fuelText = GameObject.Find("FuelText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isInCar && vehicleController.KMh > 1)
        {
            fuelText.text = fuel.ToString("f0") + "%";
        }

        vehicleController = GetComponent<MSVehicleControllerFree>();

        if (GameObject.Find("Player") == null)
        {
            isInCar = true;
        }
        else
        {
            isInCar = false;
        }

        if (isInCar == true)
        {
            fuelText.enabled = true;
        }
        else
        {
            fuelText.enabled = false;
        }

        if (fuel < 0)
        {
            vehicleController.handBrakeTrue = true;
            vehicleController.TurnOnAndTurnOff();
            vehicleController.StartCoroutine("StartEngineCoroutine", false);
        }
        else
        {
            if (isInCar == true)
            {
                vehicleController.handBrakeTrue = false;
                fuel = fuel - fuelUsage;
            }
        }

        if (GameObject.Find("LadaCam") != null)
        {
            fuelUsage = vehicleController.KMh / 650;
        }
        else
        {
            fuelUsage = vehicleController.KMh / 310;
        }

    }

    public void pickupFuel()
    {
        fuel = 100;
    }
}
