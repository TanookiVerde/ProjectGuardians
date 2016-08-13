using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeDisplay : MonoBehaviour
{
    public static int life;        // A pontuacao do jogador.
    private PlayerController pc;
    private Text textdisplay;                      // Referencia ao texto.


    void Start()
    {
        // Cria a referencia.
        textdisplay = GetComponent<Text>();

        // Zera a pontuacao.
        life = 5;

        pc = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }


    void Update()
    {
        life = pc.life;
        textdisplay.text = "Life: " + life;
    }
}