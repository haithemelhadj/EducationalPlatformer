using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

public class Spelling : MonoBehaviour
{
    public string[] wordList;
    public Sprite[] objects; 
    public int randomIndex;
    public string word;
    public TMP_Text displayText;
    public GameObject displaySprite; 
    string emptyWord = "";

    void Start()
    {
        ChoseWord();
    }

    void ChoseWord()
    {
        randomIndex = Random.Range(0, wordList.Length);
        word = wordList[randomIndex];

        displaySprite.GetComponent<Image>().sprite = objects[randomIndex];
        for (int i= 0; i< word.Length; i++) 
        {
            emptyWord += "-"; 
        }
        displayText.SetText(emptyWord);
    }
}
