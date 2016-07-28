using UnityEngine;
using System.Collections;

public class ShieldColor : MonoBehaviour {

	private enum ShieldColorState
	{
		RED,
		GREEN,
		BLUE
	}

	//Acessa o enum
	private ShieldColorState shieldColor;

	// Use this for initialization
	void Start () 
	{
		shieldColor = ShieldColorState.RED;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ColorChange ();
		switch (shieldColor)
		{
			case ShieldColorState.RED:
				gameObject.tag = "Red";
				break;
			case ShieldColorState.GREEN:
				gameObject.tag = "Green";
				break;
			case ShieldColorState.BLUE:
				gameObject.tag = "Blue";
				break;
		}
	}

	private void ColorChange()
	{
		if (Input.GetKey (KeyCode.Keypad1)) {
			shieldColor = ShieldColorState.RED;
		}
		if (Input.GetKey (KeyCode.Keypad2)) {
			shieldColor = ShieldColorState.GREEN;
		}
		if (Input.GetKey (KeyCode.Keypad3)) {
			shieldColor = ShieldColorState.BLUE;
		}
	}
}
