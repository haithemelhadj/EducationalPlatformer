using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spelling : MonoBehaviour
{
    public string[] wordList;
    public Sprite[] objects; 
    public int randomIndex;
    public string word;
    
    void Start()
    {
        
    }

    void ChoseWord()
    {
        randomIndex = Random.Range(0, wordList.Length);
        word = wordList[randomIndex];
    }
}
