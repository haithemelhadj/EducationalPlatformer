using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
   public Material newMaterial;
    public Material oldMaterial;
    public Renderer objectRenderer;
    Animator anim;
    [SerializeField]private Movement playerScript; 
    private Rigidbody rb;
    public Transform player;
    public float range = 5.0f;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float attackDistance = 2.0f; 
    private Vector3 initPos;
    [SerializeField]private bool attacked = false;
    [SerializeField] float distance;
    public AudioManganer enemyAudio;
    int lp;

    void Start()
    {
        initPos = transform.position;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        enemyAudio= GameObject.Find("Enemy Audio").GetComponent<AudioManganer>();


    }
    public void FixedUpdate()
    {
 
        distance = Vector3.Distance(transform.position, player.position);
        if (distance <= range)
        {
            Move_Ani();
            enemyAudio.PlayAudio(0, transform);
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * speed;
            transform.LookAt(player.position);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            if (distance <= 2.5f && distance >2.1f)
            {
                rb.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
                Damage_Ani();
            }
            if (distance <= attackDistance && !attacked)
            {
                objectRenderer.material = newMaterial;
                Debug.Log("Attack");

                // Reduce player's life points by 1
                lp = playerScript.lifePoints ;
                lp--;
                playerScript.LifePoints(lp);
                attacked = true;
                Damage_Ani();
            }
            if (attacked)
            {

                StartCoroutine(ReturnInitPos(1f));
            }
 
        }

        else
        {
            rb.velocity = Vector3.zero;
            Idle_Ani();
        }


    }
    
    IEnumerator ReturnInitPos(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = initPos;
        attacked = false;
        objectRenderer.material = oldMaterial;
    }

    public void Idle_Ani()
    {
        anim.SetTrigger("Idle");
    }

    public void Move_Ani()
    {
        anim.SetTrigger("Move");
    }

    public void Damage_Ani()
    {
        anim.SetTrigger("Damage");
    }

    public void Death_Ani()
    {
        anim.SetTrigger("Death");
    }
    public void Attack_Ani()
    {
        anim.SetTrigger("Attack");
    }

}
