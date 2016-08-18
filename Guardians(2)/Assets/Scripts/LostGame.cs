using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LostGame : MonoBehaviour
{

    public static int score, truescore;        // A pontuacao do jogador.

    private Text textdisplay;                      // Referencia ao texto.

    public bool dead;

    void Start()
    {
        // Cria a referencia.
        textdisplay = GetComponent<Text>();

        // Zera a pontuacao.
        score = 0;

        dead = false;
    }

    void Update()
    {
        if (dead)
        {
            textdisplay.text = "You Lost...";
        }
        else
        {

            textdisplay.text = "";
        }
    }
}