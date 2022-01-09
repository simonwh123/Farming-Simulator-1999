using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fuelScript : MonoBehaviour
{
    public float fuel;
    private float fuelUsage;

    public MSVehicleControllerFree tractorController;

    public GameObject dayCount;

    public TextMeshProUGUI fuelText;

    // Start is called before the first frame update
    void Start()
    {
        fuel = 100;
        dayCount = GameObject.Find("DayCount");
    }

    // Update is called once per frame
    void Update()
    {
        fuelText.text = fuel.ToString("f0") + "%";

        tractorController = GetComponent<MSVehicleControllerFree>();

        print(fuel);

        if (tractorController.isInsideTheCar == true)
        {
            fuelText.enabled = true;
        }
        else
        {
            fuelText.enabled = false;
        }

        if (fuel < 0)
        {
            tractorController.currentGear = -1;
            tractorController.handBrakeTrue = true;
            tractorController._vehicleTorque.maxVelocityKMh = 0;
            tractorController._vehicleTorque.speedOfGear = 0;
            tractorController.forceEngineBrake = 100;
            tractorController.TurnOnAndTurnOff();
            tractorController.StartCoroutine("StartEngineCoroutine", false);
        }
        else
        {
            if (tractorController.isInsideTheCar == true)
            {
                fuel = fuel - fuelUsage;
            }
        }

        fuelUsage = tractorController.KMh * dayCount.GetComponent<dayCountScript>().day / 80;
    }

    public void pickupFuel()
    {
        fuel = 100;
    }
}
