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
        
            if (Input.GetKeyDown(KeyCode.E) && (isCollided) /*&& playerInventory.isFull== 0*/)
            {
                playerInventory.FruitCollected();
                gameObject.SetActive(false);
                isCollided= false;
            } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = false;
        }
    }
}