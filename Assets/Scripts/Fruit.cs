using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    private bool isCollided = false;
    public PlayerInventory playerInventory;
    private void Start()
    {
        
    }
    private void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.E) && (isCollided))
            {
                playerInventory.FruitCollected();
                gameObject.SetActive(false);
            } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = true;
        }



            /*PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null && Input.GetKeyDown(KeyCode.E))
            {
                playerInventory.FruitCollected();
                gameObject.SetActive(false);
            }*/
    }
}