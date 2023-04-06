using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunestoneCode : MonoBehaviour
{

    //[SerializeField] private GameObject Player;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private bool canPlaceFruit = false;
    [SerializeField] private GameObject droppedFruit;
    //[SerializeField] private GameObject slotFruit;
    private string parentTag;
    private string fruitParentTag;


    private void Start()
    {
        parentTag = transform.parent.gameObject.tag;        
    }


    private void Update()
    {
        CheckMatch();
    }

    

    public void CheckMatch()
    {
        if (canPlaceFruit && Input.GetKeyDown(KeyCode.E))// mathabeya yenzel 3al E fi 3outh I
        {
            if (droppedFruit.CompareTag(gameObject.tag) && parentTag == fruitParentTag)
            {
                Debug.Log("Correct Match!");
                //play good match audio
                
                GameManager.currentScore += GameManager.addedScore;
                canPlaceFruit = false;
                playerInventory.isFull = 0;
                playerInventory.collectedItem = null;
                //slotFruit.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                UnityEngine.Debug.Log("Incorrect!");
                //play bad mismatch audio
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            if(playerInventory.isFull==1)
            {
                droppedFruit = playerInventory.collectedItem;

                if (droppedFruit.transform.parent != null)
                {
                    fruitParentTag = droppedFruit.transform.parent.gameObject.tag;
                }

                canPlaceFruit = true;
            }
        }
    }
    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPlaceFruit = false;
        }
    }
}
