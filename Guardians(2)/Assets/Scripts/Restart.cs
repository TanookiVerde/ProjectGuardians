using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("GameState");
        }
    }
}
