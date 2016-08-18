using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    private ScreenFader sf;

    void Start() {
        sf = FindObjectOfType(typeof(ScreenFader)) as ScreenFader;
    }

	void Update()
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
            sf.EndScene(2);
		}
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
