using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float detectionDistance;
    [SerializeField] private Movement playerScript;
    public GameObject particles;
    public GameObject particles2;
    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(10, player.position.y, player.position.x));
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionDistance)
        {
            agent.SetDestination(new Vector3(player.position.x+1, player.position.y, player.position.z ));

        }
        else
        {
            //go to start position
            agent.SetDestination(transform.position);
        }
    }
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leg") && playerScript.isAttacking)
        {
            playerScript.isAttacking = false;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 0.1f);
            Instantiate(particles, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("HitPoint"))
        {
            Debug.Log("Attack Player");
            Instantiate(particles2, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }
}
