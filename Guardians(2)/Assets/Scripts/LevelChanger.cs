using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {

    ScreenFader fadeScr;
    public int SceneNumb;

    void Awake()
    {
        fadeScr = GameObject.FindObjectOfType<ScreenFader>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            fadeScr.EndScene(SceneNumb);
        }
    }
}
