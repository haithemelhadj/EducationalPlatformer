using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManganer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;


    //index 0 placed fruit correctly
    //index 1 placed fruit incorrectly


    public void PlayAudio(int index, Transform pos)
    {
        transform.position = pos.position;
        audioSource.clip = audioClips[index];
        if(audioSource.clip == null )
        {
            Debug.Log("error audio not found");
        }
        audioSource.loop = false;
        audioSource.Play();
    }
}
