using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;


public class Spelling : MonoBehaviour
{
    public string[] wordList;
    public Sprite[] objects;
    public int randomIndex;
    public string word;
    public TMP_Text displayText;
    public GameObject displaySprite;
    public string emptyWord = "";
    public char pickedLetter;
    [SerializeField] private int wordLen;
    [SerializeField] private int correctPlace = 0;

    private void Start()
    {
        ChooseWord();
        CheckMatch();
    }

    public void ChooseWord()
    {
        randomIndex = Random.Range(0, wordList.Length);
        word = wordList[randomIndex];
        wordLen = word.Length;
        displaySprite.GetComponent<Image>().sprite = objects[randomIndex];
        for (int i = 0; i < word.Length; i++)
        {
            emptyWord += "-";
        }
        displayText.SetText(emptyWord);
    }

    public void SetPickedLetter(char letter)
    {
        pickedLetter = letter;
        CheckMatch();
    }

    public void CheckMatch()
    {
        bool found = false;
        int i = 0;
        while (!found && i<word.Length )
        {
            if (word[i] == pickedLetter)
            {
                found = true;
                correctPlace++;
                word = ReplaceLetter(word, i,'*');
                emptyWord = UpdateDisplay(i, pickedLetter,emptyWord);
                displayText.SetText(emptyWord);
            }
            i++;
        }
    }

    private string ReplaceLetter(string word , int i, char c)
    {
        char[] convWord = word.ToCharArray();
        convWord[i] = c;
        string newString = new string(convWord);
        return newString;
    }

    private string UpdateDisplay(int i, char pickedLetter,string emptyword)
    {
        emptyword = ReplaceLetter(emptyWord, i, pickedLetter);
        Debug.Log(emptyword);
        return emptyword;
    }
}