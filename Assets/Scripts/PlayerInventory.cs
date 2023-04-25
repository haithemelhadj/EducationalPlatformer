using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int isFull = 0;
    public GameObject collectedItem;
    public Sprite[] Fruits;
    public GameObject pickedFruitImage;
    //public Transform DropFruit;
    [SerializeField] private Movement movement;

    private void Update()
    {
        //dropItem();
    }

    public void FruitCollected(GameObject item)
    {
        isFull = 1; 
        collectedItem= item;



        string fruit_tag;
        string fruit_Parent_Tag;

        fruit_tag = item.tag;//color
        fruit_Parent_Tag = item.transform.parent.gameObject.tag;//fruit type

        
        //apple_red == apple_red
        for (int i = 0; i < Fruits.Length; i++)
        {
            if (Fruits[i].name.ToLower() == fruit_Parent_Tag.ToLower() + "_" + fruit_tag.ToLower()) 
            {
                pickedFruitImage.GetComponent<Image>().sprite = Fruits[i];
                break;
            }
        }        
    }

    public void dropItem()
    {
        if (Input.GetKeyDown(KeyCode.A) && isFull == 1 && movement.isGrounded)
        {
            //collectedItem.transform.position = DropFruit.transform.position;
            //collectedItem.SetActive(true);
            //instantiate collected item in dropfruit position
            //Instantiate(collectedItem, DropFruit.transform.position, Quaternion.identity);


            isFull = 0;
            collectedItem = null;
        }
    }
        
}
