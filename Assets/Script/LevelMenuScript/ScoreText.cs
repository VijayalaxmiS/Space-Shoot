using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public static int scoreValue = 0;
    public static int highscoreValue = 0;
    Text score;
    //Text highscore;
    // Updating Score value
    void Start()
    {
        score = GetComponent<Text>();
       // highscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE: " + scoreValue;
     //   highscore.text = highscore.text;
    }
}
