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

    public GameObject animObject;
    public Animation anim;
    public AnimationClip animClip;

    public AudioSource pigSound;

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
        animalRenderer = mesh.GetComponent<Renderer>();
        currentState = EnemyStates.Idle;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = animObject.GetComponent<Animation>();
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

        if (gameManager.GetComponent<timeManager>().overMidnight == true && dead == false)
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
            setRigidbodyState(true);
            setColliderState(false);

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
            setRigidbodyState(true);
            setColliderState(false);

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

        if (currentState == EnemyStates.Dead)
        {
            die();
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

    void setRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
}
