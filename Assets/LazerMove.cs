using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LazerMove : MonoBehaviour
{
    public float minPos = -1.0f;
    public float maxPos = 5.0f;
    public float moveSpeed = 1.0f;
    private bool movingUp = true;

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
            if (transform.position.y >= maxPos)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
            if (transform.position.y <= minPos)
            {
                movingUp = true;
            }
        }
    }
}




