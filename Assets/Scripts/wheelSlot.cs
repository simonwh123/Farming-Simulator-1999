using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSlot : MonoBehaviour
{
    public GameObject wheel;

    public void placeWheel()
    {
        if (wheelManager.canPlaceWheel == true)
        {
            wheel.SetActive(true);
            wheelManager.wheelInventory -= 1;
            wheelManager.wheelsOnCar += 1;
        }
    }
}
