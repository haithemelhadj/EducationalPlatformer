using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHorizontal : MonoBehaviour
{
    public int modifier;
    public float distance;
    public float speed;
    private Vector3 goToPos;
    public float wait;
    private float timer;

    private void Start()
    {
        goToPos = transform.position + new Vector3(distance * modifier, 0f, 0f);
    }

    private void Update()
    {
        //timer = wait;

        if (timer <=0)
        {
            if (transform.position != goToPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, goToPos, speed * Time.deltaTime);
            }
            else
            {
                modifier *= -1;
                goToPos = transform.position + new Vector3(distance * modifier, 0f, 0f);
                timer = wait;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }

    /*
    public float spikeSpeed = 0.1f; // The speed at which the platform moves
    private float maxSpikeHeight; // The maximum height the platform can reach
    private float minSpikeHeight; // The minimum height the platform can reach
    public float addHeight = 1.0f;

    private bool goingUp; // Flag to indicate if the platform is moving up or down
    [SerializeField] private float timer; // Timer to control waiting time

    void Start()
    {
        spikeSpeed *= modifier;
        minSpikeHeight = transform.position.x;
        maxSpikeHeight = minSpikeHeight + (addHeight * modifier);
        goingUp = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            // Move the platform up or down depending on the flag
            if (goingUp)
            {
                transform.Translate(Vector3.forward * spikeSpeed * Time.deltaTime);
                // Check if the platform has reached the maximum height, and switch the flag if true
                if (transform.position.x >= maxSpikeHeight)
                {
                    goingUp = false;
                    modifier *= -1;
                    timer = 0.5f; // Wait 2 seconds before going down again
                }
            }
            else
            {
                transform.Translate(Vector3.back * spikeSpeed * Time.deltaTime);
                // Check if the platform has reached the minimum height, and switch the flag if true
                if (transform.position.x <= minSpikeHeight)
                {
                    goingUp = true;
                    modifier *= -1;
                    timer = 0.5f; // Wait 2 seconds before going up again
                }
            }
        }
        else
        {
            timer -= Time.deltaTime; // Keep decrementing the timer until it reaches 0
        }
    }
    */
}
