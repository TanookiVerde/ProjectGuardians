using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//controle de velocidade
	private float verticalSpeed;
	private float horizontalSpeed;

	//limites de movimento
	private float xMin = -6.75f;
	private float xMax = 7.6f;
	private float yMin = -4f;
	private float yMax = 4f;

	//acessa componentes
	private Rigidbody2D rb;

	void Start () 
	{
		verticalSpeed = 0.13f;
		horizontalSpeed = 0.15f;
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate () 
	{
		MovementControl ();
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, xMin, xMax), Mathf.Clamp (rb.position.y, yMin, yMax), 0f);
	}

	private void MovementControl()
	{
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate (horizontalSpeed, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate (-horizontalSpeed, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate (0f, verticalSpeed, 0f);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate (0f, -verticalSpeed, 0f);
		}
	}
}
