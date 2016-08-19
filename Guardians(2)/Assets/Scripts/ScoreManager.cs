using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score, truescore;        // A pontuacao do jogador.

    private Text textdisplay;                      // Referencia ao texto.

    private GameManager gm;

    void Start()
    {
        // Cria a referencia.
        textdisplay = GetComponent<Text>();

        // Zera a pontuacao.
        score = 0;

        truescore = 0;

        gm = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    void FixedUpdate() {
        if (Time.frameCount % 4 == 0)
        {
            if (gm.bombCounter == 0)
                score++;
            else score += gm.bombCounter;
        }
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {

                truescore = score;
                PlayerPrefs.SetInt("Score", truescore);
                textdisplay.text = "Score: " + truescore;
        }

        else textdisplay.text = "";
    }

	public void AddScore()
	{
		score += 100;
	}
    
    public void AddScoreBig()
    {
        score += 1000;
    }
}