using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoweUpHandler : MonoBehaviour {


    //private List>bool
    public bool[] Core = new bool[] { true, true, true, true, true };
    int e;
    public GameObject[] PwUps;
	// Update is called once per frame
	void Update () {
        e = Random.Range(1, 5);
        if(Core[e] == true) {
            PowerUp(e);
        }

    }

    public void Break(int i) {
        Core[i] = false;
    }
    public void PowerUp(int i) {
        Instantiate(PwUps[i]);
    }
}
