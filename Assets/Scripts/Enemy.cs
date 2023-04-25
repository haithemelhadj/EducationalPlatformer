using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(10, player.position.y, player.position.x));
    }
    void Update()
    {
        agent.SetDestination(new Vector3(player.position.x+1, player.position.y, player.position.z ));
    }
}
