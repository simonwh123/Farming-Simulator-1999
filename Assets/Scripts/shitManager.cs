using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitManager : MonoBehaviour
{
    private int randomNumber;

    public GameObject shit1;
    public GameObject shit2;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 3);

        if (randomNumber == 1)
        {
            shit1.SetActive(true);
        }
        else
        {
            shit2.SetActive(true);
        }
    }
}
