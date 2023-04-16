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
    public GameObject pickedFruit;
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
                pickedFruit.GetComponent<Image>().sprite = Fruits[i];
                break;
            }
        }        
    }

}
