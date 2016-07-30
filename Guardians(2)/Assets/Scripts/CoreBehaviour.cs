using UnityEngine;
using System.Collections;

public class CoreBehaviour : MonoBehaviour {

	private int life;

	void Start()
	{
		life = 2;
	}

	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		if (life == 0) 
		{
			Destroy (gameObject);
		}
	}

	public void SubtractLife()
	{
		life--;
	}
}
