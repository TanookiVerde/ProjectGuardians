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

        gm = FindObjectOfType(typeof(GameManager)) as GameManager;
    }


    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (gm.bombCounter != 0)
            {
                truescore = (score + (Time.frameCount * gm.bombCounter));
                PlayerPrefs.SetInt("Score", truescore);
                textdisplay.text = "Score: " + truescore;
            }
            else
            {

                textdisplay.text = "Score: " + (score + (Time.frameCount));
            }
        }

        else textdisplay.text = "";
    }

	public void AddScore()
	{
		score += 2000;
	}
}