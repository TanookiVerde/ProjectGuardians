using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

    private Text textdisplay;
    private int score;
    private string pname;
    private int hscore;
    private bool newhscore;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        textdisplay = GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score");
        isHighScore();
    }
	
	// Update is called once per frame
	void Update () {
        score = PlayerPrefs.GetInt("Score");
        if (newhscore)
            textdisplay.text = "Final Score:  " + score + "   New Highscore!";
        else
            textdisplay.text = "Final Score:  " + score;
    }

    public void isHighScore() {
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore1"))
        {
            PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
            PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("HighScore1"));
            PlayerPrefs.SetInt("HighScore1", score);
            PlayerPrefs.Save();
            newhscore = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore2"))
            {
                Debug.Log("2");
                PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));
                PlayerPrefs.SetInt("HighScore2", score);
                PlayerPrefs.Save();
                newhscore = true;
            }
            else 
            {
                if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore3"))
                {
                    Debug.Log("3");
                    PlayerPrefs.SetInt("HighScore3", score);
                    PlayerPrefs.Save();
                    newhscore = true;
                }

                else
                {
                    newhscore = false;
                }
            }          
        }
    }
}
