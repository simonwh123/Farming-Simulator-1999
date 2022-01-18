using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    NavMeshAgent agent;
    int currentWaypoint = 0;

    public GameObject player;
    public GameObject tractor;

    public GameObject animal;
    public Animation anim;
    public AnimationClip animClip;

    public AudioSource pigSound;

    public bool chasingPlayer;

    public GameObject gameManager;
    public GameObject deadUI;

    enum EnemyStates
    {
        Patrolling,
        Aggro,
        Idle
    }

    [SerializeField] EnemyStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyStates.Idle;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = animal.GetComponent<Animation>();
        chasingPlayer = false;
        pigSound.pitch = Random.Range(0.8f, 1.2f);

        if (currentState == EnemyStates.Patrolling)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float distanceTractor = Vector3.Distance(transform.position, tractor.transform.position);

        if (gameManager.GetComponent<timeManager>().overMidnight == true)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                if (distance > 15)
                {
                    currentState = EnemyStates.Patrolling;
                }
                else
                {
                    currentState = EnemyStates.Aggro;
                }
            }
            else
            {
                if (distanceTractor > 20)
                {
                    currentState = EnemyStates.Patrolling;
                }
                else
                {
                    currentState = EnemyStates.Aggro;
                }
            }
        }
        else
        {
            currentState = EnemyStates.Idle;
        }


        // Patrolling behaviour
        if (currentState == EnemyStates.Patrolling)
        {
            if (pigSound.isPlaying == false)
            {
                pigSound.Play();
            }

            anim.clip = animClip;
            anim.Play();

            // Go to waypoints
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) <= 1.15f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
            agent.SetDestination(waypoints[currentWaypoint].position);
        }


        // Aggro behaviour
        if (currentState == EnemyStates.Aggro)
        { 
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                chasingPlayer = true;
                agent.destination = player.transform.position;
            }
            else
            {
                chasingPlayer = false;
                agent.destination = tractor.transform.position;
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
        if (other.gameObject.tag == "Player" && currentState == EnemyStates.Aggro)
        {
            player.SetActive(false);
            deadUI.SetActive(true);
        }

        if (other.gameObject.name == "Tractor" && currentState == EnemyStates.Aggro)
        {
            player.SetActive(false);
            tractor.SetActive(false);
            deadUI.SetActive(true);
        }
    }
}
