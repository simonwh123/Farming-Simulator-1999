using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvestScript : MonoBehaviour
{
    public AudioSource harvestSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crop")
        {
            Destroy(other.gameObject);
            if (harvestSound.isPlaying == false)
            {
                harvestSound.Play();
            }
        }
    }
}
