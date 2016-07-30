using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public int actualScore = 10;
    
	//acessa componentes
	private ScoreManager score;
	private CoreBehaviour core;
	private PlayerController player;

	void Start()
	{
		core = FindObjectOfType (typeof(CoreBehaviour)) as CoreBehaviour;
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		score = FindObjectOfType (typeof(ScoreManager)) as ScoreManager;
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
		if (c.gameObject.tag == "pickup") 
		{
			c.GetComponent<CoreBehaviour>().SubtractLife ();
			Destroy (gameObject);
            
		} 
		else if (c.gameObject.tag == gameObject.tag)
		{
			Destroy (gameObject);
			score.AddScore();
        }
	} 

	void OnCollisionEnter2D (Collision2D c)
	{
		c.gameObject.GetComponent<PlayerController> ().SubtractLife ();
		Destroy (gameObject);
	}
}
