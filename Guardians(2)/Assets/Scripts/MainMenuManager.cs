using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene ("GameState");
	}
}
