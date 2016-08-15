using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoreBehaviour : MonoBehaviour {

	public int life;
    private GameObject ad;

	void Start()
	{
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
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}
