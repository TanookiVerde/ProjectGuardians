using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public int actualScore = 10;
    
	//acessa componentes
	private GameManager gm;
	private ScoreManager scorem;
	private CoreBehaviour core;
	private PlayerController player;
    private PoweUpHandler pu;

	void Start()
	{
		core = FindObjectOfType (typeof(CoreBehaviour)) as CoreBehaviour;
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
        pu = FindObjectOfType (typeof(PoweUpHandler)) as PoweUpHandler;
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
	}

	void Update () 
	{
		if (transform.position.x < -9) 
		{
			Destroy (gameObject);
		}
		transform.Translate (new Vector3 (-3f, 0f, 0f) * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D c)
	{
        switch(c.gameObject.tag) {
            case "Core1":
                pu.Break(0);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core2":
                pu.Break(1);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core3":
                pu.Break(2);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core4":
                pu.Break(3);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core5":
                pu.Break(4);
                pu.generated = false;
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            default:
                break;

        }
		if (c.gameObject.tag == gameObject.tag || c.gameObject.tag == "Omni")
		{
            pu.generated = false;
            Destroy (gameObject);
            ScoreManager.score += 10;
			gm.IncreaseBombCounter ();
        }
	} 

	void OnCollisionEnter2D (Collision2D c)
	{  
        if (c.gameObject.name == "player")
        {
            c.gameObject.GetComponent<PlayerController>().SubtractLife();
            Destroy(gameObject);
        }
	}
}
