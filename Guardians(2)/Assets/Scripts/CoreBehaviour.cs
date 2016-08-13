using UnityEngine;
using System.Collections;

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
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        if (life == 0)
        { 
            switch (gameObject.tag)
            {
                case "Core1":
                    pu.Break(0);
                    Destroy(gameObject);
                    break;
                case "Core2":
                    //pu.Break(1);
                    Destroy(gameObject);
                    break;
                case "Core3":
                    //pu.Break(2);
                    Destroy(gameObject);
                    break;
                case "Core4":
                    //pu.Break(3);
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                    break;
                case "Core5":
                    //pu.Break(4);
                    Destroy(gameObject);
                    break;
            }
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
