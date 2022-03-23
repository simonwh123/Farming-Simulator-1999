using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class pigCircleScript : MonoBehaviour
{
    public AudioSource endingSound;
    public GameObject endingObject;
    private bool increaseVolume;
    private bool ending;
    public int pigsInCircle;
    private const float speedToFadeIn = 10;
    public PostProcessProfile ppProfile;
    public ChromaticAberration chromaticAberration;
    public Bloom bloom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            pigsInCircle += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            pigsInCircle -= 1;
        }
    }

    private void FixedUpdate()
    {
        if (pigsInCircle == pigManager.getPigCount.Length && ending == false)
        {
            StartCoroutine("startRitual");
        }


        if (ending == true && increaseVolume)
        {
            ppProfile.TryGetSettings(out chromaticAberration);
            ppProfile.TryGetSettings(out bloom);
            chromaticAberration.intensity.value += Time.deltaTime / speedToFadeIn;
            bloom.intensity.value += Time.deltaTime / speedToFadeIn;

            if (endingSound.volume < 1)
            {
                endingSound.volume += Time.deltaTime / speedToFadeIn;
            }
        }
    }

    IEnumerator startRitual()
    {
        ending = true;
        endingSound.Play();
        yield return new WaitForSeconds(5);
        increaseVolume = true;
        endingObject.SetActive(true);

        // Set pigs as children to endingObject
        foreach (GameObject pig in pigManager.getPigCount)
        {
            pig.transform.SetParent(endingObject.transform);
            pig.GetComponent<pigScript>().setRigidbodyState(true);
            pig.GetComponent<pigScript>().setColliderState(false);
        }
    }
}
