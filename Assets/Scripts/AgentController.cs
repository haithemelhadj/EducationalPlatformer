using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public GameObject particles_2;
    //[SerializeField] private Legs legs;
    public Animator enemyAnim;
    public Material newMaterial;
    public Material oldMaterial;
    public Renderer objectRenderer;
    public GameObject particles;
    public float wanderSpeed = 5f; //movement speed mta3 agent w howa wendering 
    public float maxForce = 10f; //max force ynajem yamelha bech ybadel el deraction wala speed 
    public float detectionRadius = 10f; //radius which the agent can detect the player.
    public float avoidanceRadius = 6f; //radius which the agent can detect obstacles and avoid them.
    public float chaseSpeed = 10f; //determines how fast the agent moves when chasing the player.
    [SerializeField] private Movement playerScript;
    int lp;
   // public bool attackply = false ;

    private Vector3 targetPosition;
    private GameObject player;
    private float distance = 2.0f;
    [SerializeField] float attackDistance = 2.0f; 

    private void Start()
    {
        SetNewTargetPosition(); //method, which chooses a random position within a certain range
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (DetectPlayer())
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }

        AvoidObstacles();
        AttackPlayer();
    }

    private bool DetectPlayer()
    {
        //Physics.OverlapSphere() to get an array of colliders within the radius and checks if any of them belong to the player game object
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    //chase player
    private void ChasePlayer()
    {
        Move_Ani();
        Vector3 chaseDirection = (player.transform.position - transform.position).normalized;
        transform.LookAt(player.transform.position);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        Vector3 chaseForce = chaseDirection * chaseSpeed - GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().AddForce(chaseForce);
    }
    private void AttackPlayer()
    {
        distance =Vector3.Distance (player.transform.position, transform.position);
        if (distance <= attackDistance  && !playerScript.isAttacking)
        {
            playerScript.isAttacked= true;
            //attack player
            GetComponent<Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
            Debug.Log("Attacking");
            objectRenderer.material = newMaterial;
            playerScript.moveSpeed = 0;
            StartCoroutine(Explode(0.5f));
        }
    }
 /*   private void DestroyEnemy()
    {
        if (playerScript.isAttacking && legs.hitLeg)
        {
            enemyAnim.ResetTrigger("Move");
            Death_Ani();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(gameObject,1.0f);
        }
    }*/

    //search player
    private void Wander()
    {
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            SetNewTargetPosition();
        }

        Vector3 wanderForce = (targetPosition - transform.position).normalized * wanderSpeed - GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().AddForce(wanderForce);
    }

    private void AvoidObstacles()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, avoidanceRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Obstacle"))
            {
                Vector3 avoidanceDirection = (transform.position - collider.transform.position).normalized;
                float avoidanceWeight = Mathf.Clamp01(1f - Vector3.Distance(transform.position, collider.transform.position) / avoidanceRadius);
                GetComponent<Rigidbody>().AddForce(avoidanceDirection * maxForce * avoidanceWeight);
            }
        }
    }

    private void SetNewTargetPosition()
    {
        float wanderRange = 10f;
        float x = Random.Range(-wanderRange, wanderRange);
        float z = Random.Range(-wanderRange, wanderRange);
        targetPosition = new Vector3(x, transform.position.y, z);
    }

    IEnumerator Explode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(particles, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        lp = playerScript.lifePoints;
        lp--;
        playerScript.LifePoints(lp);

    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Leg") && playerScript.isAttacking)
        {
            playerScript.isAttacking = false;
            enemyAnim.ResetTrigger("Move");
            Death_Ani();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 0.2f);
            Instantiate(particles_2, transform.position, Quaternion.identity);
        }
    }

    //animations functions
    public void Idle_Ani()
    {
        enemyAnim.SetTrigger("Idle");
    }

    public void Move_Ani()
    {
        enemyAnim.SetTrigger("Move");
    }
    public void Death_Ani()
    {
        enemyAnim.SetTrigger("Death");
    }
}
