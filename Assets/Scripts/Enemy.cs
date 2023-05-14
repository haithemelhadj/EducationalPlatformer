using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float detectionDistance;

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


    private void OnCollisionEnter(Collision collision)//for some reason collision is not detected so i used trigger instead 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //reset scene
            Debug.Log("Game Over!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //reset scene
            Debug.Log("Game Over!!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
