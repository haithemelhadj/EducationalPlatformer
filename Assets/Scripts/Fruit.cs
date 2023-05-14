using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    private bool isCollided = false;
    [SerializeField] private PlayerInventory playerInventory;


    private void Start()
    {
        
    }
    private void Update()
    {
            if ((isCollided) && playerInventory.isFull== 0 )//&& Input.GetKeyDown(KeyCode.E) )
            {
                 playerInventory.FruitCollected(gameObject);
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