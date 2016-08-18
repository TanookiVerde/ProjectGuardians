using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoreBehaviour : MonoBehaviour {

	public int life;
    private GameObject ad;
    private ScreenFader fader;
    private LostGame lost;

    void Start()
	{
        lost = FindObjectOfType(typeof(LostGame)) as LostGame;
        fader = FindObjectOfType(typeof(ScreenFader)) as ScreenFader;
        ad = GameObject.FindWithTag("Finish");
        life = 2;
	}
    
    void Update()
    {
        switch(life) {
            case 0:
                GameOver();
                break;
            case 1:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                transform.GetChild(0).gameObject.SetActive(false);
                break;
            default:
                break;
        }        
    }

	public void SubtractLife()
	{
        if (life == 1) { 
            ad.GetComponent<PlayAudio>().PlayExplosion1();
            life--;
        }
        else life--;
	}
    
    public void AddLife() {
        if (life == 1) life++;
    }

    public void GameOver() {
        lost.dead = true;
        Time.timeScale = 0;
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        float start = Time.realtimeSinceStartup;
        float time = 3;
        fader.EndScene(2);
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
        SceneManager.LoadScene("GameOver");
    }
}
