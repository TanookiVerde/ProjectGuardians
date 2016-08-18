using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    private ScreenFader sf;

    void Start()
    {
        sf = FindObjectOfType(typeof(ScreenFader)) as ScreenFader;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            sf.EndScene(2);
        }
    }
}
