using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	void Update()
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			SceneManager.LoadScene ("GameState");
		}
	}
}
