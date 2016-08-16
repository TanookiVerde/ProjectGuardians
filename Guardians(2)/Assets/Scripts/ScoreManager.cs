using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // A pontuacao do jogador.

    private Text textdisplay;                      // Referencia ao texto.


    void Start()
    {
        // Cria a referencia.
        textdisplay = GetComponent<Text>();

        // Zera a pontuacao.
        score = 0;
    }


    void Update()
    {
		textdisplay.text = "Score: " + score;
    }

	public void AddScore()
	{
		score += 2000;
	}
}