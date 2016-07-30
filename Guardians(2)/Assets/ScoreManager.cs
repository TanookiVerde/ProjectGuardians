using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // A pontuacao do jogador.


    private Text text;                      // Referencia ao texto.


    void Start()
    {
        // Cria a referencia.
        text = GetComponent<Text>();

        // Zera a pontuacao.
        score = 0;
    }


    void Update()
    {
        // Define o texto exibido como Score: mais a pontuacao atual.
        text.text = "Score: " + score;
    }
}