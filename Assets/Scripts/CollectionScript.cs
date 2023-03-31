using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    public bool canBeCollected = false;
    public KeyCode collectButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeCollected && Input.GetKeyDown(collectButton))
        {
            //add to inventory and destroy
            Debug.Log("Collected");
            //add objcet to inventory here
            Destroy(this.gameObject);            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canBeCollected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canBeCollected = false;
        }
    }
}
