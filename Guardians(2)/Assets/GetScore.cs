using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

    private Text textdisplay;
    private int score;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        textdisplay = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(PlayerPrefs.GetInt("Score"));
        score = PlayerPrefs.GetInt("Score");
        Debug.Log(score);
        textdisplay.text = "Final Score:  " + score;
    }
}
