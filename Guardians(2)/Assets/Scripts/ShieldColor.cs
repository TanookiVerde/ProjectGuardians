using UnityEngine;
using System.Collections;

public class ShieldColor : MonoBehaviour {

	private enum ShieldColorState
	{
		RED,
		GREEN,
		BLUE,
        OMNI,
        FLASHING
	}

	//Acessa o enum
	private ShieldColorState shieldColor;

    private bool omni = false, ready;

    private float timeElapsed;

    private int state;

	// Use this for initialization
	void Start () 
	{
		shieldColor = ShieldColorState.RED;
        timeElapsed = 0;
        state = 0;
        ready = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (omni)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 5)
            {
                if (Time.frameCount % 10 == 0) OmniFlash();
                else OmniOn();
            }
            if (timeElapsed >= 8) {
                OmniOff();
            }
        }
        else
        {
            ColorChange();
        }
            switch (state){
                case 0:
                shieldColor = ShieldColorState.RED;
                break;
                case 1:
                shieldColor = ShieldColorState.GREEN;
                break;
                case 2:
                shieldColor = ShieldColorState.BLUE;
                break;

                default:
                    break;
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
                case ShieldColorState.FLASHING:
                    GetComponent<Animator>().Play("shield_flashing");
                    break;
            }
    }

	private void ColorChange()
	{
		if (Input.GetKey (KeyCode.J)) {
            state = 0;
		}
		if (Input.GetKey (KeyCode.K)) {
            state = 1;
		}
		if (Input.GetKey (KeyCode.L)) {
            state = 2;
		}
        if (Input.GetKey(KeyCode.O)) {
            shieldColor = ShieldColorState.OMNI;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !ready)
        {
            state++;
            ready = true;
            if (state >= 3) state -= 3;
        }
        if (Input.GetKeyUp(KeyCode.Space)) { 
                ready = false;
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

    public void OmniFlash() {
        shieldColor = ShieldColorState.FLASHING;
    }

	//Permite saber qual cor esta acionada
	//public 
}
