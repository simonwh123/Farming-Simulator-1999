using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beerScript : MonoBehaviour
{
    public bool drinking;
    public Animation drinkAnim;

    public void drinkBeer()
    {
        if (drinking == false)
        {
            StartCoroutine("drinkBeerC");
        }
    }

    IEnumerator drinkBeerC()
    {
        drinking = true;
        drinkAnim.Play();

        yield return new WaitForSeconds(5);
        drinking = false;
    }
}
