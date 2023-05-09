using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class laserScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //reset scene
            Debug.Log("Game Over");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
