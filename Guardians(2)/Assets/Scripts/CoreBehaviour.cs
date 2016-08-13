using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoreBehaviour : MonoBehaviour {

	public int life;
    public PoweUpHandler pu;

	void Start()
	{
        pu = FindObjectOfType(typeof(PoweUpHandler)) as PoweUpHandler;
        life = 2;
	}
    
    void Update()
    {
        if (life == 0)
        {
            SceneManager.LoadScene("GameOver");
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
