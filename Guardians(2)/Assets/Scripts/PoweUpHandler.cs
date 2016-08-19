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
    public bool generated, tgenerated;
    public int pucount;
    private float timeElapsed;

    void Start() {
        generated = false;
        tgenerated = false;
        pucount = 0;
        timeElapsed = 0;
    }

    void FixedUpdate() {
        if(pucount == 18 && !generated) {
            pucount = 0;
            generated = true;
            GeneratePU();
        }
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 30 && !tgenerated) {
            GenerateToken();
            tgenerated = true;
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

    public void GenerateToken() {
        posX = Random.Range(xMax, 2);
        timeElapsed = 0;
        tgenerated = false;
        Instantiate(PowerUps[5], new Vector3(posX, -4, -2), Quaternion.identity);
    }
}