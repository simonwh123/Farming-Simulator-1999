using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject tractor;

    public GameObject animal;
    public Animation anim;
    public AnimationClip animClip;

    public AudioSource pigSound;

    public bool chasingPlayer;

    public GameObject gameManager;
    public GameObject deadUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = animal.GetComponent<Animation>();
        chasingPlayer = false;
        pigSound.pitch = Random.Range(0.8f, 1.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.GetComponent<timeManager>().overMidnight == true)
        {
            
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                chasingPlayer = true;
                GetComponent<NavMeshAgent>().destination = player.transform.position;
            }
            else
            {
                chasingPlayer = false;
                GetComponent<NavMeshAgent>().destination = tractor.transform.position;
            }
            anim.clip = animClip;
            anim.Play();
            if (pigSound.isPlaying == false)
            {
                pigSound.Play();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && chasingPlayer == true)
        {
            player.SetActive(false);
            deadUI.SetActive(true);
        }

        if (other.gameObject.name == "Tractor" && chasingPlayer == false)
        {
            GameObject.Find("DayCount").GetComponent<dayCountScript>().day = 1;
            tractor.SetActive(false);
            deadUI.SetActive(true);
        }
    }
}
