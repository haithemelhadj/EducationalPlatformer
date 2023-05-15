using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_AniTest : MonoBehaviour {

    Animator anim;
    private Rigidbody rb;
    public Transform player;
    public float range = 5.0f;
    [SerializeField] private float speed= 3.0f; 
    
	
	void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
		
	}
    public void FixedUpdate ()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= range) 
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * speed;
        }

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


}
