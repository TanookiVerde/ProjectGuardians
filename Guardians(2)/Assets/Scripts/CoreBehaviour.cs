using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoreBehaviour : MonoBehaviour {

	public int life;

	void Start()
	{
        life = 2;
	}
    
    void Update()
    {
        switch(life) {
            case 0:
                SceneManager.LoadScene("GameOver");
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
		life--;
	}
    
    public void AddLife() {
        if (life == 1) life++;
    }
}
