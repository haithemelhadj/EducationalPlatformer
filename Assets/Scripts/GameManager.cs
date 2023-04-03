using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //arrays containing Runestones
    public GameObject[] runeStone;
    //Arrays containing Fruits
    public GameObject[] fruit;

    public float Timer;
    public static float timeLeft;
    public Text timeLeftText;

    public static float currentScore;
    public float levelScore;
    public Text ScoreText;
    [SerializeField] public static int addedScore=1;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        CoolDownTimer();
        DiesplayTimer();
        DisplayScore();
    }

    public void DiesplayTimer()
    {
        //show UI
        float minutes = Mathf.Floor(timeLeft / 60);
        float seconds = Mathf.Floor(timeLeft % 60);
        timeLeftText.text= "Time : " + minutes+":"+seconds;
        if(seconds<10)
        {
            timeLeftText.text = "Time : " + minutes + ":0" + seconds;
        }
    }
    public void DisplayScore()
    {        
        ScoreText.text = "Score : " + currentScore +"/"+levelScore;
    }

    public void CoolDownTimer()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = Timer;
        }
    }

    public void CheckScore()
    {
        if(currentScore < levelScore)
        {
            // lose and reset level
            //rest scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //win and move to next scene
            //trigger lab animation
            //load next scene
        }
    }

}
