using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private bool isColliding = false;
    [SerializeField] private Spelling spelling;
    [SerializeField] private bool isPickedUp = false;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E) && !isPickedUp)
        {
            Debug.Log("PICKED ITEM");
            spelling.SetPickedLetter(gameObject.name[0]);
            meshRenderer.enabled = false;
            isPickedUp = true;
        }
        else if (isPickedUp && !isColliding)
        {
            meshRenderer.enabled = true;
            isPickedUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
