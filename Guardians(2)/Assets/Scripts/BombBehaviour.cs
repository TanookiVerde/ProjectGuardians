using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public int actualScore = 10;
    
	//acessa componentes
	private ScoreManager scorem;
	private CoreBehaviour core;
	private PlayerController player;

	void Start()
	{
		core = FindObjectOfType (typeof(CoreBehaviour)) as CoreBehaviour;
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
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
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core2":
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core3":
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core4":
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            case "Core5":
                c.GetComponent<CoreBehaviour>().SubtractLife();
                Destroy(gameObject);
                break;
            default:
                break;

        }
		if (c.gameObject.tag == gameObject.tag || c.gameObject.tag == "Omni")
		{
			Destroy (gameObject);
            ScoreManager.score += 10;
        }
	} 

	void OnCollisionEnter2D (Collision2D c)
	{
		c.gameObject.GetComponent<PlayerController> ().SubtractLife ();
		Destroy (gameObject);
	}
}
