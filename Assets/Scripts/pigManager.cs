using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigManager : MonoBehaviour
{
    public int pigsToSpawn;
    public GameObject pigObject;
    private float radius;

    // Start is called before the first frame update
    void Awake()
    {
        radius = 2;
        pigsToSpawn = GameObject.Find("DayCount").GetComponent<dayCountScript>().day + 2;
        spawnPig();
    }

    public void spawnPig()
    {

        
        for (var i = 0; i < pigsToSpawn; i++)
        {
            //Instantiate(pigObject, spawnPos.position, spawnPos.rotation);
            Instantiate(pigObject, Random.insideUnitSphere * radius + transform.position, Random.rotation);
        }
    }
}
