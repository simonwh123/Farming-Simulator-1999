using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepScript : MonoBehaviour
{
    public bool moving;
    public AudioSource footstepSound;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving && footstepSound.isPlaying == false && Player.GetComponent<pauseScript>().paused == false)
        {         
            footstepSound.Play();           
        }

        if (!moving)
        {
            footstepSound.Stop();
        }
    }
}
