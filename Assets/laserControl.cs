using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserControl : MonoBehaviour
{
    public float wait;
    float timer;
    public GameObject laser;
    public bool isActive;
    private void Awake()
    {
        //laser = GameObject.Find("laser");        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = wait;
            laser.SetActive(isActive);
            isActive = !isActive;
        }
    }
}
