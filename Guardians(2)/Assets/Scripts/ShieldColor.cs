using UnityEngine;
using System.Collections;

public class ShieldColor : MonoBehaviour {

	private enum ShieldColorState
	{
		RED,
		GREEN,
		BLUE,
        OMNI
	}

	//Acessa o enum
	private ShieldColorState shieldColor;

    private bool omni = false;

    private float timeElapsed;

	// Use this for initialization
	void Start () 
	{
		shieldColor = ShieldColorState.RED;
        timeElapsed = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (omni)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 5)
            {
                OmniOff();
            }
        }
        else
        {
            ColorChange();
        }
            switch (shieldColor)
            {
                case ShieldColorState.RED:
                    gameObject.tag = "Red";
                    GetComponent<Animator>().Play("shield_red");
                    break;
                case ShieldColorState.GREEN:
                    gameObject.tag = "Green";
                    GetComponent<Animator>().Play("shield_green");
                    break;
                case ShieldColorState.BLUE:
                    gameObject.tag = "Blue";
                    GetComponent<Animator>().Play("shield_blue");
                    break;
                case ShieldColorState.OMNI:
                    gameObject.tag = "Omni";
                    GetComponent<Animator>().Play("shield_omni");
                    break;
            }
    }

	private void ColorChange()
	{
		if (Input.GetKey (KeyCode.J)) {
			shieldColor = ShieldColorState.RED;
		}
		if (Input.GetKey (KeyCode.K)) {
			shieldColor = ShieldColorState.GREEN;
		}
		if (Input.GetKey (KeyCode.L)) {
			shieldColor = ShieldColorState.BLUE;
		}
        if (Input.GetKey(KeyCode.O)) {
            shieldColor = ShieldColorState.OMNI;
        }
    }

    public void OmniOn() {
        omni = true;
        timeElapsed = 0;
        shieldColor = ShieldColorState.OMNI;

    }
    
    public void OmniOff() {
        omni = false;
        shieldColor = ShieldColorState.RED;
    }

	//Permite saber qual cor esta acionada
	//public 
}
