using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offeringMachine : MonoBehaviour
{

    public GameObject bullet; // Bullet to spawn when offering stuff
    public GameObject noOfferingsText;
    public GameObject soundObject;

    public void putInOffering()
    {

        StartCoroutine("PuttingInMachine");


            // No items in inventory
            noOfferingsText.SetActive(true);
            StartCoroutine("NoInventoryItems");
        
    }

    IEnumerator PuttingInMachine()
    {
        // Offer stuff
        soundObject.GetComponent<AudioSource>().Play();
        soundObject.GetComponent<AudioSource>().pitch = 1;
        gameObject.tag = "Untagged";

        yield return new WaitForSeconds(6);
        bullet.SetActive(true);
        bullet.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(2);
        soundObject.GetComponent<AudioSource>().Stop();
        gameObject.tag = "Interactable";
    }

    IEnumerator NoInventoryItems()
    {
        yield return new WaitForSeconds(2);
        noOfferingsText.SetActive(false);
    }

}
