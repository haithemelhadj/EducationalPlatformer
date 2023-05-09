using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;


public class Spelling : MonoBehaviour
{
    public string[] wordList;   //list of already set words in the level
    public Sprite[] objects;    //list of sprites that will represent the words
    public int randomIndex;     //the random index to choose a random word
    public string word;         //save the chosen word here
    public Text displayText;    //text to display the word
    public GameObject displaySprite;//the sprite gameobject to display the chosen word
    public string emptyWord = "";//the player's word 
    public char pickedLetter; //the picked letter
    [SerializeField] private int wordLen;
    [SerializeField] private int correctPlace = 0;

    private void Start()
    {
        ChooseWord();//choose a random word from the list
        //CheckMatch();//check for what? picked letter is not even set
    }
    /*
    private void Update()
    {
        if (checkWholeWord())//if the player has guessed the whole word
        {
            Debug.Log("You Win");
        }
    }
    */ //this is extra
    public void ChooseWord()// choose random word from word list and set "-" for it's length
    {
        randomIndex = Random.Range(0, wordList.Length);
        word = wordList[randomIndex];
        //wordLen = word.Length;
        displaySprite.GetComponent<Image>().sprite = objects[randomIndex];
        for (int i = 0; i < word.Length; i++)
        {
            emptyWord += "-";
        }
        displayText.text = emptyWord;
        //displayText.SetText(emptyWord);
    }

    bool checkWholeWord()
    {
        for(int i = 0; i < word.Length; i++)
        {
            if (word[i] != '*')
            {
                return false;
            }
        }
        return true;
    }

    public void SetPickedLetter(char letter)//set the picked letter each time the player picks a letter and check if it's correct
    {
        pickedLetter = letter;
        CheckMatch();//check if the letter picked is picked correctly or not
    }

    public void CheckMatch()
    {
        bool found = false;
        int i = 0;
        while (!found && i<word.Length )
        {
            if (word[i] == pickedLetter)
            {
                found = true;// used to break out of loop
                correctPlace++;//used to check if the player has guessed the whole word
                word = ReplaceLetter(word, i,'*');//replace the correct letter with * so that it doesn't match again if the word has double letters
                emptyWord = UpdateDisplay(i, pickedLetter,emptyWord);//update the display text
                displayText.text = emptyWord;//update the display text
                //displayText.SetText(emptyWord);
            }
            i++;
        }//what if the letter is not correct what happens?

        /*
        //---------this is my way:
        int j;
        for (j = 0; j < word.Length; j++)
        {
            if (word[j]==pickedLetter)
            {
                correctPlace++;
                word = replace(word, j, '*');
                emptyWord = replace(emptyWord, j, pickedLetter);
                displayText.text = emptyWord;
                break;
            }
        }
        if (j < word.Length) 
        {
            Debug.Log("letter correct");
            Debug.Log(word);
            Debug.Log(emptyWord);
            if (checkWholeWord())
            {
                Debug.Log("You guessed the whole word!");                
            }

        }
        else
        {
            Debug.Log("letter not correct");
        }
        //----------
        */
    }

    //-----------------------
    private string ReplaceLetter(string word , int i, char c)//takes a word, a position and a letter then upadtes the word
    {
        char[] convWord = word.ToCharArray();
        convWord[i] = c;
        string newString = new string(convWord);
        return newString;
    }

    private string UpdateDisplay(int i, char pickedLetter,string emptyword)//takes a word, a position and a letter then calls another funtion??? why?
    {
        emptyword = ReplaceLetter(emptyWord, i, pickedLetter);
        Debug.Log(emptyword);
        return emptyword;
    }
    //-----------------------this is my way:
    //this does the same job of the past 2 functions
    string replace(string word, int position, char letter)
    {
        char[] chars = word.ToCharArray();
        chars[position]=letter;
        string newString = new string(chars);
        return newString;
    }
}