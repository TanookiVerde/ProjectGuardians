using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoweUpHandler : MonoBehaviour
{
    public GameObject[] PowerUps;
    private bool[] State = { true, true, true, true, true };
    int SelectedPowerUp;
    private float xMin = -6.5f;
    private float xMax = 7.35f;
    private float yMin = -3.5f;
    private float yMax = 3.5f;
    private float posX, posY;
    public bool generated;

    void Start() {
        generated = false;
    }

    void Update() {
        if(ScoreManager.score % 10000 == 0 && ScoreManager.score != 0 && !generated) {
            generated = true;
            GeneratePU();
        }
    }


    public void Break(int i) {
        State[i] = false;
    }

    public void GeneratePU() {
        SelectedPowerUp = Random.Range(0, 5);
        if (State[SelectedPowerUp] == false)
        {
           if(State[0] || State[1] || State[2] || State[3] || State[4])
            GeneratePU();
        }
        else
        {
            posX = Random.Range(xMax, xMin);
            posY = Random.Range(yMax, yMin);

            Instantiate(PowerUps[SelectedPowerUp], new Vector3(posX, posY, 0), Quaternion.identity);
        }
    }
}