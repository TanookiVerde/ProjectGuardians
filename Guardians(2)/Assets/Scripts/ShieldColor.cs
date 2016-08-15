using UnityEngine;
using System.Collections;

public class ShieldColor : MonoBehaviour {

	private enum ShieldColorState
	{
		RED,
		GREEN,
		BLUE,
        OMNI,
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
                if (timeElapsed > 5 && timeElapsed < 5.5) OmniFlash();
                if (timeElapsed >= 5.5 && timeElapsed < 6) OmniFlash2();
                if (timeElapsed >= 6 && timeElapsed < 6.5) OmniFlash();
                if (timeElapsed >= 6.5 && timeElapsed < 7) OmniFlash2();
                if (timeElapsed >= 7 && timeElapsed < 7.5) OmniFlash();
                if (timeElapsed >= 7.5 && timeElapsed < 8) OmniFlash2();
            }
            if (timeElapsed >= 8)
            {
                OmniOff();
            }
            switch (shieldColor)
            {
                case ShieldColorState.RED:
                    GetComponent<Animator>().Play("shield_red");
                    break;
                case ShieldColorState.OMNI:
                    GetComponent<Animator>().Play("shield_omni");
                    break;
            }
        }
        else
        {
            ColorChange();
            switch (state)
            {
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
            }
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
        gameObject.tag = "Omni";
        shieldColor = ShieldColorState.OMNI;
    }
    
    public void OmniOff() {
        omni = false;
        shieldColor = ShieldColorState.RED;
    }

    public void OmniFlash() {
        shieldColor = ShieldColorState.RED;
    }
    public void OmniFlash2() {
        shieldColor = ShieldColorState.OMNI;
    }

	//Permite saber qual cor esta acionada
	//public 
}
