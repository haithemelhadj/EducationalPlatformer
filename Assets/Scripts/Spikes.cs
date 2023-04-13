using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float spikeSpeed = 0.1f; // The speed at which the platform moves
    private float maxSpikeHeight; // The maximum height the platform can reach
    private float minSpikeHeight; // The minimum height the platform can reach
    public float addHeight = 1.0f;

    private bool goingUp; // Flag to indicate if the platform is moving up or down
    [SerializeField] private float timer; // Timer to control waiting time

    void Start()
    {
        minSpikeHeight = transform.position.y;
        maxSpikeHeight = minSpikeHeight + addHeight;
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
                transform.Translate(Vector3.up * spikeSpeed * Time.deltaTime);
                // Check if the platform has reached the maximum height, and switch the flag if true
                if (transform.position.y >= maxSpikeHeight)
                {
                    goingUp = false;
                    timer = 0.5f; // Wait 2 seconds before going down again
                }
            }
            else
            {
                transform.Translate(Vector3.down * spikeSpeed * Time.deltaTime);
                // Check if the platform has reached the minimum height, and switch the flag if true
                if (transform.position.y <= minSpikeHeight)
                {
                    goingUp = true;
                    timer = 0.5f; // Wait 2 seconds before going up again
                }
            }
        }
        else
        {
            timer -= Time.deltaTime; // Keep decrementing the timer until it reaches 0
        }
    }

}

