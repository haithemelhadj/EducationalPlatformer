using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int isFull = 0;
    
    public void FruitCollected()
    {
        isFull = 1;
    }
}
