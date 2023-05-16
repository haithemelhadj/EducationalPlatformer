using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSectionCheck : MonoBehaviour
{
    public bool nextCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextCheck = true;
        }
    }
}
