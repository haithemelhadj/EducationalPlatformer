using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPostionTouched : MonoBehaviour
{
    public Vector3 LastTouchedPosition;
    public Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Ground"))
        {
            LastTouchedPosition = transform.position;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag("Ground"))
        {
            LastTouchedPosition=transform.position;
        }
    }
}
