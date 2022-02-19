using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigManager : MonoBehaviour
{
    public int pigsToSpawn;
    public GameObject pigObject;
    private float radius;
    public static int pigsAlive;
    public static bool allPigsAreDead;
    public static GameObject[] getPigCount;

    void Start()
    {
        radius = 2;
        pigsToSpawn = GameObject.Find("DayCount").GetComponent<dayCountScript>().day + 2;
        spawnPig();
        getPigCount = GameObject.FindGameObjectsWithTag("Enemy");
        pigsAlive = getPigCount.Length;
    }

    private void FixedUpdate()
    {
        if (pigsAlive <= 0)
        {
            allPigsAreDead = true;
        }
        else
        {
            allPigsAreDead = false;
        }
    }

    public void spawnPig()
    {
        for (var i = 0; i < pigsToSpawn; i++)
        {
            Instantiate(pigObject, Random.insideUnitSphere * radius + transform.position, Random.rotation);
        }
    }
}
