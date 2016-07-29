using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {

    public int actualScore = 10;
    
	//acessa componentes


	void Start()
	{
		
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
			Destroy (c.gameObject);
			Destroy (gameObject);
            
		} 
		else if (c.gameObject.tag == gameObject.tag)
		{
			Destroy (gameObject);
            ScoreManager.score += actualScore;
        }
	} 
}
