using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class offeringMachine : MonoBehaviour
{

    public GameObject bullet; // Bullet to spawn when offering stuff
    public GameObject insufficientText;
    public GameObject soundObject;
    public int offeringsInInventory;
    public int fuel;
    [SerializeField]
    private TextMeshProUGUI twigsText;

    private void Start()
    {
        twigsText.text = "Twigs: " + offeringsInInventory;
        offeringsInInventory = 0;
    }

    private void FixedUpdate()
    {
        twigsText.text = "Twigs: " + offeringsInInventory;
    }

    public void putInOffering()
    {
        // No items in inventory
        if (offeringsInInventory < 1)
        {
            insufficientText.SetActive(true);
            insufficientText.GetComponent<TextMeshProUGUI>().text = "No offerings";
            StartCoroutine("NoInventoryItems");
        }
        if (offeringsInInventory < 1 && fuel < 1)
        {
            insufficientText.SetActive(true);
            insufficientText.GetComponent<TextMeshProUGUI>().text = "No offerings and no fuel";
            StartCoroutine("NoInventoryItems");
        }
        if (fuel < 1)
        {
            insufficientText.SetActive(true);
            insufficientText.GetComponent<TextMeshProUGUI>().text = "No fuel";
            StartCoroutine("NoInventoryItems");
        }
        if (offeringsInInventory > 0 && fuel > 0)
        {
            StartCoroutine("PuttingInMachine");
        }
    }

    void enableOrDisableColliders(bool enableOrDisable)
    {
        GetComponent<SphereCollider>().enabled = enableOrDisable;
        GetComponent<BoxCollider>().enabled = enableOrDisable;
    }

    IEnumerator PuttingInMachine()
    {
        // Offer stuff
        soundObject.GetComponent<AudioSource>().Play();
        soundObject.GetComponent<AudioSource>().pitch = 1;
        offeringsInInventory -= 2;
        enableOrDisableColliders(false);
        fuel -= 50;

        yield return new WaitForSeconds(6);
        bullet.SetActive(true);
        bullet.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(2);
        soundObject.GetComponent<AudioSource>().Stop();
        enableOrDisableColliders(true);
    }

    IEnumerator NoInventoryItems()
    {
        yield return new WaitForSeconds(2);
        insufficientText.SetActive(false);
    }

    public void pickupOffering()
    {        
        offeringsInInventory += 1;
    }

}
