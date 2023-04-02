using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int isFull = 0;
    public GameObject collectedItem;
    public void FruitCollected(GameObject item)
    {
        isFull = 1; 
        collectedItem= item;

    }
}
