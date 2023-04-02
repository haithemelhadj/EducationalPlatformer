using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RunestoneCode : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private bool isCollided = false;
    [SerializeField] private GameObject droppedFruit;
    [SerializeField] private GameObject slotFruit;
    private string parentTag;
    private string fruitParentTag;
    

    private void Update()
    {
        if(Player!=null && Player.GetComponent<PlayerInventory>().isFull==1)
        {
            droppedFruit = Player.GetComponent<PlayerInventory>().collectedItem;
        }
        //droppedFruit = playerInventory.collectedItem;  <= this is wrong , you need to get the component from gameobject first
        // what?
        if (transform.parent != null)
        {
            parentTag = transform.parent.gameObject.tag;
        }
        if (droppedFruit != null && droppedFruit.transform.parent != null)
        {
            fruitParentTag = droppedFruit.transform.parent.gameObject.tag;
        }
        slotFruit = transform.GetChild(0).gameObject;
        // 
        CheckMatch();
    }

    public void CheckMatch()
    {
        if (isCollided && Input.GetKeyDown(KeyCode.I))
        {
            if (droppedFruit != null && droppedFruit.CompareTag(gameObject.tag) && parentTag == fruitParentTag)
            {
                UnityEngine.Debug.Log("Correct Match!");
                // Add currentScore script
                //currentScore() ; 
                playerInventory.isFull = 0;
                playerInventory.collectedItem = null;
                slotFruit.SetActive(true); 
            }
            else
            {
                UnityEngine.Debug.Log("Incorrect!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = true;
            Player = other.gameObject;
        }
    }
    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = false;
        }
    }
}
