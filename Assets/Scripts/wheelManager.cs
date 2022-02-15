using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelManager : MonoBehaviour
{
    public static int wheelInventory;
    public static int wheelsOnCar;
    public static bool canPlaceWheel;
    public GameObject fixedCar;

    private void FixedUpdate()
    {
        if (wheelsOnCar == 4)
        {
            Destroy(gameObject);
            fixedCar.SetActive(true);
        }

        if (wheelInventory > 0)
        {
            canPlaceWheel = true;
        }
        else
        {
            canPlaceWheel = false;
        }
    }

    public void pickupWheel()
    {
        wheelInventory += 1;
    }
}
