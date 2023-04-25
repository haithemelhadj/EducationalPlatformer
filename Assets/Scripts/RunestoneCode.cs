using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunestoneCode : MonoBehaviour
{

    //[SerializeField] private GameObject Player;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private bool canPlaceFruit = false;
    [SerializeField] private GameObject droppedFruit;
    //[SerializeField] private GameObject slotFruit;
    private string parentTag;
    private string fruitParentTag;
    public AudioManganer audioManganer;

    public Sprite empty;
    public GameObject pickedFruit;

    private void Start()
    {
        parentTag = transform.parent.gameObject.tag; 
        //audioManganer = FindObjectOfType<AudioManganer>();
        //find object with name
        audioManganer = GameObject.Find("Audio Player").GetComponent<AudioManganer>();
        
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
                //Debug.Log("Correct Match!");
                //play good match audio
                audioManganer.PlayAudio(0, transform);
                
                GameManager.currentScore += GameManager.addedScore;
                canPlaceFruit = false;
                playerInventory.isFull = 0;


                pickedFruit.GetComponent<Image>().sprite = empty;

                playerInventory.collectedItem = null;
                //slotFruit.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                //UnityEngine.Debug.Log("Incorrect!");
                //play bad mismatch audio
                audioManganer.PlayAudio(1, transform);
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
