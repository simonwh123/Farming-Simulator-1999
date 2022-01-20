using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offeringMachine : MonoBehaviour
{
    
    public List<string> inventory;
    public List<string> offerID;

    //private void FixedUpdate()
    //{
    //    foreach(string itemInInventory in inventory)
    //    {

    //    }
    //}

    public void putInOffering()
    {
        foreach(string offer in offerID)
        {
            print(offer);
            if (inventory.Contains(offer))
            {
                GameObject.Find(offer).SetActive(true);
                inventory.Remove(offer);
                print(offer);
            }
        }
    }

    public void pickupOffering(string offeringToPickup)
    {
        inventory.Add(offeringToPickup);
    }

}
