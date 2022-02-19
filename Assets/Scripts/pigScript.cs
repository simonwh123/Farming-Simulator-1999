using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pigScript : MonoBehaviour
{
    public GameObject[] waypointList;
    private GameObject tempGO;
    NavMeshAgent agent;
    int currentWaypoint = 0;

    public GameObject player;
    public GameObject tractor;
    public GameObject lada;

    public GameObject animObject;
    public Animation anim;
    public AnimationClip animClip;

    public AudioSource pigSound;
    public AudioSource hitSound;

    public bool chasingPlayer;
    public bool dead;

    public GameObject gameManager;
    public GameObject deadUI;

    public Texture bloodyTexture;
    public Renderer animalRenderer;
    public GameObject mesh;

    enum EnemyStates
    {
        Patrolling,
        Aggro,
        Idle,
        Dead
    }

    [SerializeField] EnemyStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleWaypoints();
        currentState = EnemyStates.Idle;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = animObject.GetComponent<Animation>();
        chasingPlayer = false;
        pigSound.pitch = Random.Range(0.8f, 1.2f);

        if (currentState == EnemyStates.Patrolling)
        {
            agent.SetDestination(waypointList[currentWaypoint].transform.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        float distanceTractor = Vector3.Distance(transform.position, tractor.transform.position);
        float distanceLada = Vector3.Distance(transform.position, lada.transform.position);

        if (gameManager.GetComponent<timeManager>().overMidnight == true && dead == false && gameManager.GetComponent<TaskManager>().allTasksCompleted == false)
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
                if (GameObject.Find("TractorCam"))
                {
                    if (distanceTractor > 25)
                    {
                        currentState = EnemyStates.Patrolling;
                    }
                    else
                    {
                        currentState = EnemyStates.Aggro;
                    }
                }

                if (GameObject.Find("LadaCam"))
                {
                    if (distanceLada > 25)
                    {
                        currentState = EnemyStates.Patrolling;
                    }
                    else
                    {
                        currentState = EnemyStates.Aggro;
                    }
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
            setRigidbodyState(true);
            setColliderState(false);

            if (pigSound.isPlaying == false)
            {
                pigSound.Play();
            }

            anim.clip = animClip;
            anim.Play();

            // Go to waypoints
            if (Vector3.Distance(transform.position, waypointList[currentWaypoint].transform.position) <= 1.15f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypointList.Length)
                {
                    currentWaypoint = 0;
                }
            }
            agent.SetDestination(waypointList[currentWaypoint].transform.position);
        }


        // Aggro behaviour
        if (currentState == EnemyStates.Aggro)
        {
            setRigidbodyState(true);
            setColliderState(false);

            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                chasingPlayer = true;
                agent.destination = player.transform.position;
            }
            else
            {
                if (GameObject.Find("TractorCam"))
                {
                    chasingPlayer = false;
                    agent.destination = tractor.transform.position;
                }
                if (GameObject.Find("LadaCam"))
                {
                    chasingPlayer = false;
                    agent.destination = lada.transform.position;
                }
            }
            anim.clip = animClip;
            anim.Play();
            if (pigSound.isPlaying == false)
            {
                pigSound.Play();
            }
        }

        if (currentState == EnemyStates.Dead)
        {
            die();
        }
    }

    public void ShuffleWaypoints()
    {
        for (int i = 0; i < waypointList.Length; i++)
        {
            int rnd = Random.Range(0, waypointList.Length);
            tempGO = waypointList[rnd];
            waypointList[rnd] = waypointList[i];
            waypointList[i] = tempGO;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && currentState == EnemyStates.Aggro && dead == false)
        {
            player.SetActive(false);
            deadUI.SetActive(true);
        }

        if (other.gameObject.name == "Tractor" && currentState == EnemyStates.Aggro && dead == false)
        {
            player.SetActive(false);
            tractor.SetActive(false);
            deadUI.SetActive(true);
        }

        if (other.gameObject.name == "LadaBody" && currentState == EnemyStates.Aggro && dead == false)
        {
            player.SetActive(false);
            lada.SetActive(false);
            deadUI.SetActive(true);
        }
    }

    public void die()
    {
        animalRenderer.material.mainTexture = bloodyTexture;
        agent.enabled = false;
        anim.Stop();
        anim.enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
        currentState = EnemyStates.Dead;
        dead = true;
        pigSound.Stop();
    }

    public void setRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    public void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
}
