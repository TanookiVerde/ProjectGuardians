using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScores : MonoBehaviour
{

    private Text textdisplay;
    private int score;
    private string pname;
    private int hscore;
    private bool newhscore;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        textdisplay = GetComponent<Text>();;
    }

    // Update is called once per frame
    void Update()
    {
        textdisplay.text = "High Scores: \n 1. " + PlayerPrefs.GetInt("HighScore1") + "\n 2. " + PlayerPrefs.GetInt("HighScore2") + "\n 3. " + PlayerPrefs.GetInt("HighScore3");
    }
}
