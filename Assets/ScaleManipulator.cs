using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManipulator : MonoBehaviour
{

    public float minScale;
    public float maxScale;
     bool isScalingUp=true;
    public float scaleSpeed;


    void Update()
    {
        if(isScalingUp)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
            if (transform.localScale.x >= maxScale)
            {
                isScalingUp = false;
                Debug.Log("isNotScalingUp");
            }
        }
        else
        {
            transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
            if (transform.localScale.x <= minScale)
            {
                isScalingUp = true;
                Debug.Log("isScalingUp");
            }
        }
    }
}
