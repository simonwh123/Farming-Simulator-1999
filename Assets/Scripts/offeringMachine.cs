using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offeringMachine : MonoBehaviour
{
    
    public List<string> inventory;
    public List<string> offerID;
    public GameObject bullet; // Bullet to spawn when offering stuff
    public GameObject noOfferingsText;
    public GameObject soundObject;

    public void putInOffering()
    {
        if (inventory.Count > 0) // Check if inventory is not empty
        {
            StartCoroutine("PuttingInMachine");
        }
        else
        {
            // No items in inventory
            noOfferingsText.SetActive(true);
            StartCoroutine("NoInventoryItems");
        }
    }

    public void pickupOffering(string offeringToPickup)
    {
        inventory.Add(offeringToPickup);
    }

    IEnumerator PuttingInMachine()
    {
        // Offer stuff
        string offeringToSpawn = inventory[Random.Range(0, inventory.Count)];
        GameObject.Find(offeringToSpawn).GetComponent<Animation>().Play();
        inventory.Remove(offeringToSpawn);
        soundObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);
        bullet.SetActive(true);
        bullet.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(1);
        soundObject.GetComponent<AudioSource>().Stop();
    }

    IEnumerator NoInventoryItems()
    {
        yield return new WaitForSeconds(2);
        noOfferingsText.SetActive(false);
    }
}
